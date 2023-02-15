using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de RezagoDAO
/// </summary>
public class RezagoDAO
{
    private static RezagoDAO _instancia = null;

    public static RezagoDAO instancia()
    {
        return _instancia == null ? new RezagoDAO() : _instancia;
    }

    public RezagoDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public List<RezagoVO> getRezagoEstatal(int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select r.anio");
        str.Append(",r.clave_entidad_federativa as id_estado");
        str.Append(",e.descripcion as estado");
        str.Append(", r.con_rezago");
        str.Append(", r.sin_rezago");
        str.Append(",(r.con_rezago+ r.sin_rezago)as total");
        str.Append(" from rezago_estatal r ");
        str.Append("left join c_entidad_federativa e ");
        str.Append(" on r.clave_entidad_federativa = e.clave ");
        str.Append("where r.anio = " + anio);
        List<RezagoVO> lst = new List<RezagoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new RezagoVO()
                   {
                       anio = int.Parse(row["anio"].ToString()),
                       id_estado = row["id_estado"].ToString(),
                       estado = row["estado"].ToString(),
                       con_rezago = int.Parse(row["con_rezago"].ToString()),
                       sin_rezago = int.Parse(row["sin_rezago"].ToString()),
                       total = int.Parse(row["total"].ToString())
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public List<RezagoVO> getRezagoMunicipal(int anio, string clave_estado)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select r.anio");
        str.Append(",r.clave_entidad_federativa as id_estado");
        str.Append(",e.descripcion as estado");
        str.Append(", m.clave_mun as id_municipio ");
        str.Append(", m.descripcion as municipio");
        str.Append(", r.con_rezago");
        str.Append(", r.sin_rezago ");
        str.Append(",(r.con_rezago+ r.sin_rezago)as total");
        str.Append(" from rezago_municipal r ");
        str.Append(" left join c_entidad_federativa e ");
        str.Append(" on r.clave_entidad_federativa = e.clave ");
        str.Append(" left join c_municipio m ");
        str.Append(" on r.clave_entidad_federativa = m.clave_entidad_federativa ");
        str.Append(" and r.clave_municipio = m.clave_mun ");
        str.Append(" where r.anio = " + anio + " and r.clave_entidad_federativa = '" + clave_estado + "' order by municipio");
        List<RezagoVO> lst = new List<RezagoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                        select new RezagoVO()
                        {
                            anio = int.Parse(row["anio"].ToString()),
                            id_municipio = row["id_municipio"].ToString(),
                            municipio = row["municipio"].ToString(),
                            id_estado = row["id_estado"].ToString(),
                            estado = row["estado"].ToString(),
                            con_rezago = int.Parse(row["con_rezago"].ToString()),
                            sin_rezago = int.Parse(row["sin_rezago"].ToString()),
                            total = int.Parse(row["total"].ToString())
                        }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public List<CatalogoVO> seleccionarAnioMunicipal()
    {
        string str = "select distinct anio from rezago_municipal order by anio desc";
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

    public List<CatalogoVO> seleccionarAnioEstatal()
    {
        string str = "select distinct anio from rezago_estatal order by anio desc";
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

    public RezagoVO getTotalRezagoEstatal(int anio, string clave_entidad_federativa)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select r.anio");
        str.Append(",r.clave_entidad_federativa as id_estado");
        str.Append(",e.descripcion as estado");
        str.Append(", r.con_rezago");
        str.Append(", r.sin_rezago");
        str.Append(",(r.con_rezago+ r.sin_rezago)as total");
        str.Append(" from rezago_estatal r ");
        str.Append("left join c_entidad_federativa e ");
        str.Append(" on r.clave_entidad_federativa = e.clave ");
        str.Append(" where r.anio = " + anio);
        str.Append(" and r.clave_entidad_federativa= '" + clave_entidad_federativa +"'");
        RezagoVO total = null;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            total = (from DataRow row in dt.Rows
                     select new RezagoVO()
                     {
                         anio = int.Parse(row["anio"].ToString()),
                         id_estado = row["id_estado"].ToString(),
                         estado = row["estado"].ToString(),
                         con_rezago = int.Parse(row["con_rezago"].ToString()),
                         sin_rezago = int.Parse(row["sin_rezago"].ToString()),
                         total = int.Parse(row["total"].ToString())
                     }).ToList().First<RezagoVO>();


        }
        catch (Exception ex)
        {
            var error = ex;
        }

        return total;
    }
    public RezagoVO getTotalRezagoMunicipal(int anio, string clave_entidad_federativa,string clave_municipio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select r.anio");
        str.Append(",r.clave_entidad_federativa as id_estado");
        str.Append(",e.descripcion as estado");
        str.Append(", m.clave_mun as id_municipio");
        str.Append(", m.descripcion as municipio");
        str.Append(", r.con_rezago");
        str.Append(", r.sin_rezago ");
        str.Append(",(r.con_rezago+ r.sin_rezago)as total");
        str.Append(" from rezago_municipal r ");
        str.Append(" left join c_entidad_federativa e ");
        str.Append(" on r.clave_entidad_federativa = e.clave ");
        str.Append(" left join c_municipio m ");
        str.Append(" on r.clave_entidad_federativa = m.clave_entidad_federativa ");
        str.Append(" and r.clave_municipio = m.clave_mun ");
        str.Append(" where r.anio = " + anio);
        str.Append(" and r.clave_entidad_federativa = '" + clave_entidad_federativa + "'");
        str.Append(" and m.clave_mun = '" + clave_municipio + "'");
        str.Append(" order by m.descripcion");
        RezagoVO total = null;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            total = (from DataRow row in dt.Rows
                     select new RezagoVO()
                     {
                         anio = int.Parse(row["anio"].ToString()),
                         id_estado = row["id_estado"].ToString(),
                         estado = row["estado"].ToString(),
                         id_municipio = row["id_municipio"].ToString(),
                         municipio = row["municipio"].ToString(),
                         con_rezago = int.Parse(row["con_rezago"].ToString()),
                         sin_rezago = int.Parse(row["sin_rezago"].ToString()),
                         total = int.Parse(row["total"].ToString())
                     }).ToList().First<RezagoVO>();


        }
        catch (Exception ex)
        {
            var error = ex;
        }

        return total;
    }
}