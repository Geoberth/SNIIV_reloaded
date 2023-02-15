using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de SiseviveDAO
/// </summary>
public class ReportePnrDAO
{
    private static ReportePnrDAO _instancia = null;

    public static ReportePnrDAO instancia()
    {
        return _instancia == null ? new ReportePnrDAO() : _instancia;
    }

    public ReportePnrDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region DASHBOARD

    public DateTime seleccionarFecha()
    {
        string str = "select last_day(concat(anio, '-', mes, '-1')) as fecha from c_periodo_presidencia where actual = 1";
        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            fecha = (from DataRow row in dt.Rows select (DateTime)row["fecha"]).ToList<DateTime>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return fecha;
    }

    public List<CatalogoVO> seleccionarPrograma()
    {
        string str = "select id, descripcion from c_programa_presupuestal";
        List<CatalogoVO> catalogo = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            catalogo = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["id"].ToString(),
                         descripcion = row["descripcion"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return catalogo;
    }

    public ReportePnrVO listReporte()
    {
        string str = "call sp_cargar_reporte_pnr()";
        ReportePnrVO listReporte = new ReportePnrVO();
        List<listCMGVO> listCMG = new List<listCMGVO>();
        List<listCMRVO> listCMR = new List<listCMRVO>();
        List<listCMCAVO> listCMCA = new List<listCMCAVO>();
        

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);

            listCMG = (from DataRow row in dt.Rows
                        select new listCMGVO()
                        {


                            cveInmueble = row["cve_inmueble"].ToString(),
                            numComite = row["numero_comite_financiamiento"].ToString(),
                            strFeAprobacion = DateTime.Parse(row["fecha_aprobacion_comite_financiamiento"].ToString()).ToString("yyyy-MM-dd"),
                            denominacionProyecto = row["denominacion_proyecto"].ToString(),
                            descripcion = row["denominacion_proyecto"].ToString(),
                            strTipoDanio = row["cve_tipo_dano"].ToString(),
                            cveModalidad = row["cve_modalidad"].ToString(),
                            strIdInciso = row["cve_inciso"].ToString(),
                            strIdTipoApoyo = row["cve_tipo_apoyo"].ToString(),
                            strBeneficiario = row["genero"].ToString(),
                            strEdad = row["edad"].ToString(),
                            strSalario = row["salario"].ToString(),
                            strBenIndigenas = row["beneficiarios_indigenas"].ToString(),
                            strBenDiscapacitados = row["beneficiarios_discapacitados"].ToString(),
                            strLatitud = row["latitud"].ToString(),
                            strLongitud = row["longitud"].ToString(),
                            cveEstado = row["clave_entidad_federativa"].ToString(),
                            cveMunicipio = row["clave_municipio"].ToString(),
                            cveLocalidad = row["clave_localidad"].ToString(),
                            nombreDocEvidenciaFotoInicio = row["nombre_foto_inicio"].ToString(),
                            docBase64EvidenciaFotoInicio = row["foto_inicio"].ToString(),
                            nombreDocEvidenciaFotoProceso = row["nombre_foto_proceso"].ToString(),
                            docBase64EvidenciaFotoProceso = row["foto_proceso"].ToString(),
                            nombreDocEvidenciaFotoConcluida = row["nombre_foto_conclusion"].ToString(),
                            docBase64EvidenciaFotoConcluida = row["foto_conclusion"].ToString(),
                            nombreDocActaEntrega = row["acta_entrega"].ToString(),
                            docBase64ActaEntrega = row["documento_acta_entrega"].ToString(),
                            strCveCancelacion = row["id_cancelacion"].ToString(),
                            strJustificacionCancelacion = row["justificacion_cancelacion"].ToString(),
                            nombreDocCancelacion = row["nombre_documento_cancelacion"].ToString(),
                            docBase64Cancelacion = row["documento_cancelacion"].ToString(),

                        }).ToList();

            listCMR = (from DataRow row in dt.Rows
                         select new listCMRVO()
                         {
                             cveInmueble = row["cve_inmueble"].ToString(),
                             cveRecurso = row["cve_recurso"].ToString(),
                             strProgramado = row["dato_presupuestal_importe_aprobado"].ToString(),
                             strEjercido = row["dato_presupuestal_importe_ejercicio"].ToString(),
                             strAvanceFisico = row["avance_fisico"].ToString(),
                             anioMesInicio = row["fecha_inicio"].ToString(),
                             anioMesTermino = row["fecha_termino"].ToString(),
                             strMontoAutorizado = row["dato_presupuestal_importe_aprobado"].ToString(),

                         }).ToList();

            listCMCA = (from DataRow row in dt.Rows
                         select new listCMCAVO()
                         {
                             cveInmueble = row["cve_inmueble"].ToString(),
                             cveRecursoCalendario = row["cve_recurso"].ToString(),
                             mesProgramacion = row["fecha_inicio"].ToString(),
                             strMontoInversion = row["dato_presupuestal_importe_aprobado"].ToString(),
                         }).ToList();

            
            listReporte.listCMG = listCMG;
            listReporte.listCMR = listCMR;
            listReporte.listCMCA = listCMCA;


        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return listReporte;
    }

    #endregion
}