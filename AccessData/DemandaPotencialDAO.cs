using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de DemandaPotencialDAO
/// </summary>
public class DemandaPotencialDAO
{
    private static DemandaPotencialDAO _instancia = null;

    public static DemandaPotencialDAO instancia()
    {
        return _instancia == null ? new DemandaPotencialDAO() : _instancia;
    }

    public DemandaPotencialDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio as anio from c_periodo_demanda_potencial order by anio desc";
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
        str.Append("select c.mes, m.descripcion from c_periodo_demanda_potencial c");
        str.Append(" join c_mes m on m.id = c.mes");
        str.Append(" where c.anio = " + anio);
        str.Append(" order by c.mes desc ");
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

    public DataTable seleccionarEstatal(int anio, int mes)
    {
        string str = "call sp_demanda_potencial_estatal(" + anio + ", " + mes + ")";
        DataTable dt = new DataTable();

        try
        {
            dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }

    public DataTable seleccionarMunicipal(int anio, int mes, string clave_estado)
    {
        string str = "call sp_demanda_potencial_municipal(" + anio + ", " + mes + ", '" + clave_estado + "')";
        DataTable dt = new DataTable();

        try
        {
            dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }

    #region TOTALES

    public Option getTotalEstatal(int anio, int mes)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select e.descripcion as estado, sum(valor) as total");
        str.Append(" from demanda_potencial_infonavit d");
        str.Append(" join c_entidad_federativa e on e.clave = d.clave_entidad_federativa");
        str.Append(" where d.anio = " + anio + " and d.mes = " + mes + " and d.id_salario_infonavit = 9999");
        str.Append(" group by e.descripcion");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = int.Parse(row["total"].ToString()),
                       name = row["estado"].ToString()
                   }).ToList();
            Serie serie = new Serie("demanda_potencial_estatal", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getTotalMunicipal(int anio, int mes, string clave_estado)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select m.descripcion as municipio, sum(valor) as total");
        str.Append(" from demanda_potencial_infonavit d");
        str.Append(" join c_entidad_federativa e on e.clave = d.clave_entidad_federativa");
        str.Append(" join c_municipio m on m.clave_entidad_federativa = e.clave and m.clave = d.clave_municipio");
        str.Append(" where d.anio = " + anio + " and d.mes = " + mes + " and e.clave = '" + clave_estado + "' and d.id_salario_infonavit = 9999");
        str.Append(" group by m.descripcion");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = int.Parse(row["total"].ToString()),
                       name = row["municipio"].ToString()
                   }).ToList();
            Serie serie = new Serie("demanda_potencial_municipal", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    #endregion
}