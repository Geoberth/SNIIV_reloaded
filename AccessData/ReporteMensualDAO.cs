using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de ReporteMensualDAO
/// </summary>
public class ReporteMensualDAO
{
    private static ReporteMensualDAO _instancia = null;

    public static ReporteMensualDAO instancia()
    {
        return _instancia == null ? new ReporteMensualDAO() : _instancia;
    }

    public ReporteMensualDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio as anio from reporte_mensual order by anio desc";
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

    public List<CatalogoVO> seleccionarMes(int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select c.mes, m.descripcion from reporte_mensual c");
        str.Append(" join c_mes m on m.id = c.mes");
        str.Append(" where c.anio = " + anio);
        str.Append(" order by c.mes desc");
        List<CatalogoVO> meses = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            meses = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["mes"].ToString(),
                         descripcion = row["descripcion"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return meses;
    }

    /*
    public List<ReporteMensualVO> seleccionar()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select id, anio, mes, url_pdf, url_youtube, url_ppt");
        str.Append(" from reporte_mensual");
        str.Append(" order by anio desc");
        List <ReporteMensualVO> reportes = new List<ReporteMensualVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            reportes = (from DataRow row in dt.Rows
                            select new ReporteMensualVO()
                            {
                                id = int.Parse(row["id"].ToString()),
                                anio = int.Parse(row["anio"].ToString()),
                                mes = int.Parse(row["mes"].ToString()),
                                url_pdf = row["url_pdf"].ToString(),
                                url_youtube = row["url_youtube"].ToString(),
                                url_ppt = row["url_ppt"].ToString()
                            }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return reportes;
    }
    */
}