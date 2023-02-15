using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de ConaviDAO
/// </summary>
public class MetaDAO
{
    private static MetaDAO _instancia = null;

    public static MetaDAO instancia()
    {
        return _instancia == null ? new MetaDAO() : _instancia;
    }

    public MetaDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region DASHBOARD

    public List<MetaVO> getMetas(int anio)
    {
        string str = "call analisis.sp_get_metas(" + anio + ")";
        List<MetaVO> metas = new List<MetaVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            metas = (from DataRow row in dt.Rows
                             select new MetaVO()
                             {
                                 programa = row["programa"].ToString(),
                                 autorizado = int.Parse(row["autorizado"].ToString()),
                                 monto_autorizado = decimal.Parse(row["monto_autorizado"].ToString()),
                                 dispersado = int.Parse(row["dispersado"].ToString()),
                                 monto_dispersado = decimal.Parse(row["monto_dispersado"].ToString()),
                                 meta = int.Parse(row["meta"].ToString()),
                                 monto_meta = decimal.Parse(row["monto_meta"].ToString()),
                                 autorizado_meta = int.Parse(row["autorizado_meta"].ToString()),
                                 dispersado_autorizado = int.Parse(row["dispersado_autorizado"].ToString()),
                                 monto_autorizado_meta = int.Parse(row["monto_autorizado_meta"].ToString()),
                                 monto_dispersado_autorizado = int.Parse(row["monto_dispersado_autorizado"].ToString())
                             }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return metas;
    }
    public List<MetaVO> getMetasEstatal(int anio)
    {
        string str = "call analisis.sp_get_metas_estatal(" + anio + ")";
        List<MetaVO> metas = new List<MetaVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            metas = (from DataRow row in dt.Rows
                     select new MetaVO()
                     {
                         programa = row["programa"].ToString(),
                         estado = row["estado"].ToString(),
                         autorizado = int.Parse(row["autorizado"].ToString()),
                         monto_autorizado = decimal.Parse(row["monto_autorizado"].ToString()),
                         dispersado = int.Parse(row["dispersado"].ToString()),
                         monto_dispersado = decimal.Parse(row["monto_dispersado"].ToString()),
                         meta = int.Parse(row["meta"].ToString()),
                         monto_meta = decimal.Parse(row["monto_meta"].ToString()),
                         autorizado_meta = int.Parse(row["autorizado_meta"].ToString()),
                         dispersado_autorizado = int.Parse(row["dispersado_autorizado"].ToString()),
                         monto_autorizado_meta = int.Parse(row["monto_autorizado_meta"].ToString()),
                         monto_dispersado_autorizado = int.Parse(row["monto_dispersado_autorizado"].ToString())
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return metas;
    }

    #endregion

    public DataTable getExcel()
    {
        DataTable dt = new DataTable();
        try
        { dt = Generico.instancia().seleccionar("call analisis.sp_get_metas_estatal", Constante.BD_SNIIV); }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }
}