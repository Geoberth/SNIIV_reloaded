using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de ConaviDAO
/// </summary>
public class BeneficiarioAnalisisDAO
{
    private static BeneficiarioAnalisisDAO _instancia = null;

    public static BeneficiarioAnalisisDAO instancia()
    {
        return _instancia == null ? new BeneficiarioAnalisisDAO() : _instancia;
    }

    public BeneficiarioAnalisisDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region DASHBOARD

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct year(fecha) as anio from analisis.c_periodo order by anio desc";
        List<CatalogoVO> anios = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            anios = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["anio"].ToString(),
                         descripcion = row["anio"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return anios;
    }

    public List<BeneficiarioAnalisisVO> getKPIs(int anio)
    {
        string str = "call analisis.sp_cargar_kpis_beneficiario(" + anio + ")";
        List<BeneficiarioAnalisisVO> beneficiarios = new List<BeneficiarioAnalisisVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            beneficiarios = (from DataRow row in dt.Rows
                             select new BeneficiarioAnalisisVO()
                             {
                                 programa = row["programa"].ToString(),
                                 grupo = row["grupo"].ToString(),
                                 estado = row["estado"].ToString(),
                                 municipio = row["municipio"].ToString(),
                                 linea = row["linea"].ToString(),
                                 sesion = row["sesion"].ToString(),
                                 fecha = row["fecha"].ToString().Substring(0, 10),
                                 monto = decimal.Parse(row["monto"].ToString()),
                                 acciones = UInt32.Parse(row["acciones"].ToString())
                             }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return beneficiarios;
    }

    public List<BeneficiarioAnalisisVO> getBeneficiarios(int anio, int id_programa)
    {
        string str = "call analisis.sp_get_beneficiarios(" + anio + "," + id_programa + ")";
        List<BeneficiarioAnalisisVO> beneficiarios = new List<BeneficiarioAnalisisVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            beneficiarios = (from DataRow row in dt.Rows
                    select new BeneficiarioAnalisisVO()
                    {
                        curp = row["curp"].ToString(),
                        //paterno = row["primer_apellido"].ToString(),
                        //materno = row["segundo_apellido"].ToString(),
                        //nombre = row["nombre"].ToString(),
                        estado = row["estado"].ToString(),
                        municipio = row["municipio"].ToString(),
                        programa = row["programa"].ToString(),
                        grupo = row["grupo"].ToString(),
                        linea = row["linea"].ToString(),
                        sesion = row["sesion"].ToString(),
                        //acu = row["acu"].ToString(),
                        fecha = row["fecha_sesion"].ToString().Substring(0, 10),
                        monto_autorizado = decimal.Parse(row["monto_autorizado"].ToString()),
                        monto_dispersado = decimal.Parse(row["monto_dispersado"].ToString()),
                        estatus = row["estatus"].ToString(),
                        estatus_pago = row["estatus_pago"].ToString(),
                        monto_dispersar = decimal.Parse(row["monto_dispersar"].ToString()),
                        //monto_reintegrado = decimal.Parse(row["monto_reintegrado"].ToString())
                        proceso = row["proceso"].ToString(),
                        obra = row["obra"].ToString(),
                        supervisor = row["supervisor"].ToString(),
                        proyecto = row["proyecto"].ToString(),
                        capacitacion = row["capacitacion"].ToString()
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return beneficiarios;
    }

    public DataTable getExcel(int id_programa)
    {
        DataTable dt = new DataTable();
        try
        { dt = Generico.instancia().seleccionar("call analisis.sp_get_beneficiarios(" + id_programa + ")", Constante.BD_SNIIV); }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }

    #endregion
}