using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de ParqueHabitacionalDAO
/// </summary>
public class ParqueHabitacionalDAO
{
    private static ParqueHabitacionalDAO _instancia = null;

    public static ParqueHabitacionalDAO instancia()
    {
        return _instancia == null ? new ParqueHabitacionalDAO() : _instancia;
    }

    public ParqueHabitacionalDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio from parque_habitacional order by anio desc";
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

    public List<ParqueHabitacionalVO> seleccionarEstatal(int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT ph.clave_entidad_federativa");
        str.Append(" ,e.descripcion as entidad");
        str.Append(" ,sum(ph.habitada) as habitada");
        str.Append(" ,sum(ph.deshabitada) as deshabitada");
        str.Append(" ,sum(ph.uso_temporal) as uso_temporal");
        str.Append(" ,sum(ph.total) as total");
        str.Append(" from parque_habitacional ph");
        str.Append(" INNER JOIN c_entidad_federativa e");
        str.Append(" on e.clave = ph.clave_entidad_federativa");
        str.Append(" WHERE ph.anio = "+ anio );
        str.Append(" GROUP BY ph.clave_entidad_federativa, e.descripcion");
        List <ParqueHabitacionalVO> lstEstatal = new List<ParqueHabitacionalVO>();
        System.Diagnostics.Debug.WriteLine(str.ToString());
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            
            lstEstatal = (from DataRow row in dt.Rows
                        select new ParqueHabitacionalVO()
                        {
                            clave_area_geoestadistica = row["clave_entidad_federativa"].ToString(),
                            area_geoestadistica = row["entidad"].ToString(),
                            habitada = row["habitada"].ToString() == ""? 0:int.Parse(row["habitada"].ToString()),
                            deshabitada = row["deshabitada"].ToString() == "" ? 0 : int.Parse(row["deshabitada"].ToString()),
                            uso_temporal = row["uso_temporal"].ToString() == "" ? 0 : int.Parse(row["uso_temporal"].ToString()),
                            total = int.Parse(row["total"].ToString())
                        }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstEstatal;
    }

    public List<ParqueHabitacionalVO> seleccionarMunicipal(int anio, string clave_entidad_federativa)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT ph.clave_municipio , m.descripcion as municipio, ");
        str.Append("sum(ph.habitada) as habitada, ");
        str.Append("sum(ph.deshabitada) as deshabitada, ");
        str.Append("sum(ph.uso_temporal) as uso_temporal, ");
        str.Append("sum(ph.total) as total ");
        str.Append("from parque_habitacional ph ");
        str.Append("join c_entidad_federativa e on e.clave = ph.clave_entidad_federativa ");
        str.Append("join c_municipio m on m.clave_mun = ph.clave_municipio ");
        str.Append("and m.clave_entidad_federativa = ph.clave_entidad_federativa ");
        str.Append("WHERE anio = " + anio + " AND ph.clave_entidad_federativa = '" + clave_entidad_federativa + "' ");
        str.Append("GROUP BY ph.clave_municipio, m.descripcion");
        System.Diagnostics.Debug.WriteLine(str.ToString());
        List <ParqueHabitacionalVO> lstMunicipal = new List<ParqueHabitacionalVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstMunicipal = (from DataRow row in dt.Rows
                          select new ParqueHabitacionalVO()
                          {
                              clave_area_geoestadistica = row["clave_municipio"].ToString(),
                              area_geoestadistica = row["municipio"].ToString(),
                              habitada = row["habitada"].ToString() == ""? 0: int.Parse(row["habitada"].ToString()),
                              deshabitada = row["deshabitada"].ToString() == "" ? 0 : int.Parse(row["deshabitada"].ToString()),
                              uso_temporal = row["uso_temporal"].ToString() == "" ? 0 : int.Parse(row["uso_temporal"].ToString()),
                              total = row["total"].ToString() == "" ? 0 : int.Parse(row["total"].ToString())
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstMunicipal;
    }
    


    #region TOTALES
    /*
    public Option getTotalEstatal(int anio)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();

        str.Append(" SELECT ph.clave_entidad_federativa ");
        str.Append(" ,e.descripcion as estado ");
        str.Append(" ,sum(ph.habitada) as habitadas ");
        str.Append(" ,sum(ph.deshabitada) as deshabitadas ");
        str.Append(" ,sum(ph.uso_temporal) as uso_temporal ");
        str.Append(" ,sum(ph.total) as total ");
        str.Append(" from parque_habitacional ph ");
        str.Append(" INNER JOIN sniiv.c_entidad_federativa e ");
        str.Append(" on e.clave = ph.clave_entidad_federativa ");
        str.Append(" WHERE ph.anio = " + anio);
        str.Append(" GROUP BY ph.clave_entidad_federativa; ");
        List <Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = int.Parse(row["total"].ToString()),
                       name = row["estado"].ToString()
                   }).ToList();
            Serie serie = new Serie("parqueHabitacional", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    
    public Option getTotalMunicipal(int anio, string clave_entidad_federativa)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("  SELECT ph.clave_entidad_federativa");
        str.Append("  , e.descripcion as estado");
        str.Append("  , ph.clave_municipio");
        str.Append("  , m.descripcion as municipio");
        str.Append("  , ph.habitada");
        str.Append("  , ph.deshabitada");
        str.Append("  , ph.uso_temporal");
        str.Append("  , ph.total");
        str.Append("  from parque_habitacional ph");
        str.Append("      INNER JOIN sniiv.c_entidad_federativa e");
        str.Append("  ON e.clave = ph.clave_entidad_federativa");
        str.Append("  INNER JOIN sniiv.c_municipio m");
        str.Append("  ON m.clave = ph.clave_municipio");
        str.Append("  AND m.clave_entidad_federativa = ph.clave_entidad_federativa");
        str.Append("  WHERE anio =" + anio);
        str.Append("  AND ph.clave_entidad_federativa = " + clave_entidad_federativa);
        str.Append("  GROUP BY ph.clave_municipio;");

        List <Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = int.Parse(row["total"].ToString()),
                       name = row["municipio"].ToString()
                   }).ToList();
            Serie serie = new Serie("parqueHabitacional", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    */
    #endregion
    
}