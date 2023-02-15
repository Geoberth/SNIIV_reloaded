using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de SiseviveDAO
/// </summary>
public class ReportePresidenciaDAO
{
    private static ReportePresidenciaDAO _instancia = null;

    public static ReportePresidenciaDAO instancia()
    {
        return _instancia == null ? new ReportePresidenciaDAO() : _instancia;
    }

    public ReportePresidenciaDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region DASHBOARD

    public DateTime seleccionarFecha()
    {
        //string str = "select TO_DATE(concat(anio, TO_CHAR(mes,'fm00'), '01'), 'YYYYMMDD') as fecha from c_periodo_presidencia where actual";
        string endMonth = "SELECT (date_trunc('month',concat(anio,'-',TO_CHAR(mes,'fm00'),'-', '01')::date)+ interval '1 month' - interval '1 day')::date as fecha from c_periodo_presidencia where actual";
        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(endMonth, Constante.BD_SNIIV);
            fecha = (from DataRow row in dt.Rows select (DateTime)row["fecha"]).ToList<DateTime>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return fecha;
    }

    public List<CatalogoVO> seleccionarAnio()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select distinct anio from reporte_presidencia ");
        str.Append(" order by anio desc ");
        List<CatalogoVO> meses = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            meses = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["anio"].ToString(),
                         descripcion = row["anio"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return meses;
    }

    public List<CatalogoVO> seleccionarPrograma(int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select id, descripcion from c_programa_presupuestal ");
        str.Append("where id in (select id_programa_presupuestal ");
        str.Append("from reporte_presidencia where anio = " + anio + ") and id != 4");
        List<CatalogoVO> catalogo = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
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

    public List<ReportePresidenciaVO> getKPIs(int programa, bool clave, int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select ");
        str.Append("fecha_aprobacion_comite_financiamiento as fecha, ");
        str.Append("numero_comite_financiamiento as comite, ");
        str.Append("m.descripcion as modalidad, ");
        str.Append("la.descripcion as linea_apoyo, ");
        str.Append("vp.descripcion as vertiente, ");
        str.Append("cre.descripcion as rango_edad, ");
        str.Append("g.descripcion as genero, ");
        str.Append("ef.clave as clave_estado, ");
        str.Append("ef.descripcion as estado, ");
        str.Append("mu.clave_mun as clave_municipio, ");
        str.Append("mu.descripcion as municipio, ");
        str.Append("beneficiarios, monto ");
        str.Append("from (select ");
        str.Append("fecha_aprobacion_comite_financiamiento, ");
        str.Append("numero_comite_financiamiento, ");
        str.Append("id_modalidad, ");
        str.Append("id_linea_apoyo, ");
        str.Append("id_vertiente, ");
        str.Append("id_rango_edad, ");
        str.Append("id_genero, ");
        str.Append("clave_entidad_federativa, ");
        str.Append("clave_municipio, ");
        str.Append("sum(COALESCE(beneficiario_comprometidos, 0)) as beneficiarios, ");
        str.Append("round(sum(COALESCE(dato_presupuestal_importe_aprobado, 0)), 2) as monto ");
        str.Append("from reporte_presidencia ");
        str.Append("where anio = " + anio);
        str.Append(" and id_programa_presupuestal = " + programa);
        if (programa != 5)
            str.Append(" and id_status = " + Constante.ACTIVO);
        str.Append(" group by ");
        str.Append("fecha_aprobacion_comite_financiamiento, ");
        str.Append("numero_comite_financiamiento, ");
        str.Append("id_modalidad, ");
        str.Append("id_linea_apoyo, ");
        str.Append("id_vertiente, ");
        str.Append("id_rango_edad, ");
        str.Append("id_genero, ");
        str.Append("clave_entidad_federativa, ");
        str.Append("clave_municipio ");
        str.Append("order by fecha_aprobacion_comite_financiamiento) t ");
        str.Append("join c_modalidad_presidencia m on m.id = t.id_modalidad ");
        str.Append("join c_linea_apoyo_presidencia la on la.id = t.id_linea_apoyo ");
        str.Append("join c_vertiente_presidencia vp on vp.id = t.id_vertiente ");
        str.Append("join c_genero g on g.id = t.id_genero ");
        str.Append("join c_rango_edad cre on t.id_rango_edad=cre.id ");
        str.Append("join c_entidad_federativa ef on ef.clave = t.clave_entidad_federativa ");
        str.Append("join c_municipio mu on mu.clave_mun = t.clave_municipio and mu.clave_entidad_federativa = ef.clave");
        List<ReportePresidenciaVO> KPIs = new List<ReportePresidenciaVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            if (clave)
            {
                KPIs = (from DataRow row in dt.Rows
                        select new ReportePresidenciaVO()
                        {
                            fecha = row["fecha"].ToString().Substring(0, 10),
                            comite = row["comite"].ToString(),
                            modalidad = row["modalidad"].ToString(),
                            linea_apoyo = row["linea_apoyo"].ToString(),
                            vertiente = row["vertiente"].ToString(),
                            rango_edad = row["rango_edad"].ToString(),
                            genero = row["genero"].ToString(),
                            clave_estado = row["clave_estado"].ToString(),
                            estado = row["estado"].ToString(),
                            clave_municipio = row["clave_municipio"].ToString(),
                            municipio = row["municipio"].ToString(),
                            beneficiarios = int.Parse(row["beneficiarios"].ToString()),
                            monto = decimal.Parse(row["monto"].ToString()),
                        }).ToList();
            }
            else {
                KPIs = (from DataRow row in dt.Rows
                        select new ReportePresidenciaVO()
                        {
                            fecha = row["fecha"].ToString().Substring(0, 10),
                            comite = row["comite"].ToString(),
                            modalidad = row["modalidad"].ToString(),
                            linea_apoyo = row["linea_apoyo"].ToString(),
                            vertiente = row["vertiente"].ToString(),
                            rango_edad = row["rango_edad"].ToString(),
                            genero = row["genero"].ToString(),
                            estado = row["estado"].ToString(),
                            municipio = row["municipio"].ToString(),
                            beneficiarios = int.Parse(row["beneficiarios"].ToString()),
                            monto = decimal.Parse(row["monto"].ToString()),
                        }).ToList();
            }
            
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    #endregion
}