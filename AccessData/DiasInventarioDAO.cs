using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de DiasInventarioDAO
/// </summary>
public class DiasInventarioDAO
{
    private static DiasInventarioDAO _instancia = null;

    public static DiasInventarioDAO instancia()
    {
        return _instancia == null ? new DiasInventarioDAO() : _instancia;
    }

    public DiasInventarioDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio from inventario_estatal order by anio desc";
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

    public List<CatalogoVO> seleccionarTrimestre(int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select distinct(trimestre) as trimestre,");
        str.Append(" case when trimestre=5 then 'Último Trimestre'");
        str.Append(" else concat(trimestre, ' Trimestre') end as descripcion ");
        str.Append(" from inventario_estatal where anio = " + anio);
        str.Append(" order by trimestre desc");
        List <CatalogoVO> trimestre = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            trimestre = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["trimestre"].ToString(),
                         descripcion = row["descripcion"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return trimestre;
    }

    public int seleccionarTrimestre()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select max(trimestre) as trimestre from inventario_estatal ");
        str.Append("where anio = (select max(anio)  from inventario_estatal) ");
        str.Append("and trimestre != 5");
        int trimestre = 0;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            trimestre = (from DataRow row in dt.Rows select (int)row["trimestre"]).ToList<int>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return trimestre;
    }

    public List<DiasInventarioVO> seleccionarEstatal(int anio, int trimestre)
    {      
        StringBuilder str = new StringBuilder();
        str.Append("select i.anio");
        str.Append(" ,i.trimestre");
        str.Append(" ,i.clave_entidad_federativa");
        str.Append(" ,e.descripcion as entidad");
        str.Append(" ,i.registro,construccion");
        str.Append(" ,i.venta");
        str.Append(" ,total");
        str.Append(" ,i.numero_vivienda ");
        str.Append(" from inventario_estatal i");
        str.Append(" inner join c_entidad_federativa e on e.clave = i.clave_entidad_federativa");
        str.Append(" where anio = " + anio );
        str.Append(" and trimestre = " + trimestre);
        str.Append(" and clave_entidad_federativa <> '00' ");
        List <DiasInventarioVO> lstEstatal = new List<DiasInventarioVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstEstatal = (from DataRow row in dt.Rows
                        select new DiasInventarioVO()
                        {
                            clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                            entidad = row["entidad"].ToString(),
                            registro = int.Parse(row["registro"].ToString()),
                            construccion = int.Parse(row["construccion"].ToString()),
                            venta = int.Parse(row["venta"].ToString()),
                            total = int.Parse(row["total"].ToString()),
                            numero_vivienda = int.Parse(row["numero_vivienda"].ToString()),
                        }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstEstatal;
    }

    public List<DiasInventarioVO> seleccionarMunicipal(int anio, int trimestre, string clave_entidad_federativa, int registro)
    {
        StringBuilder str = new StringBuilder();
        str.Append(" select COALESCE(i.anio," + anio+",i.anio) as anio ");
        str.Append(" ,COALESCE(i.trimestre," + trimestre + ",trimestre) as trimestre");
        str.Append(" , e.clave as clave_entidad_federativa");
        str.Append(" , e.descripcion as entidad");
        str.Append(" , m.clave_mun as clave_municipio");
        str.Append(" , m.descripcion as municipio");
        str.Append(" ,COALESCE(i.registro,0,i.registro)as registro");
        str.Append(" ,COALESCE(i.construccion,0,i.construccion)as construccion");
        str.Append(" ,COALESCE(i.venta,0,i.venta)as venta");
        str.Append(" ,COALESCE(i.total,0,i.total) as total");
        str.Append(" ,COALESCE(i.numero_vivienda,0,i.numero_vivienda)as numero_vivienda");
        str.Append(" from c_municipio m");
        str.Append(" left join inventario_municipal i");
        str.Append(" on m.clave_entidad_federativa = i.clave_entidad_federativa");
        str.Append(" and m.clave_mun = i.clave_municipio");
        if (registro.Equals(0)) { 
        str.Append(" and anio = " + anio + " and trimestre =" + trimestre);
        }
        str.Append(" inner join c_entidad_federativa e on e.clave = m.clave_entidad_federativa");
        str.Append(" where m.clave_entidad_federativa = '" + clave_entidad_federativa + "'");
        str.Append(" and m.clave_mun <> '000'");
        if (registro.Equals(1))
        {
            str.Append(" and anio = " + anio + " and trimestre =" + trimestre);
        }
        System.Diagnostics.Debug.WriteLine(str.ToString());

        /*str.Append("select i.anio");
        str.Append("  ,i.trimestre");
        str.Append("  ,i.clave_entidad_federativa");
        str.Append("  ,e.descripcion as entidad");
        str.Append("  ,i.clave_municipio");
        str.Append("  ,m.descripcion as municipio");
        str.Append("  ,i.registro");
        str.Append("  ,i.construccion");
        str.Append("  ,i.venta");
        str.Append("  ,i.registro + i.construccion + i.venta as total");
        str.Append("  ,i.numero_vivienda");
        str.Append("  from inventario_municipal i");
        str.Append("  inner join c_entidad_federativa e on e.clave = i.clave_entidad_federativa");
        str.Append("  inner join c_municipio m on m.clave = i.clave_municipio and m.clave_entidad_federativa = i.clave_entidad_federativa");
        str.Append("  where anio ="+ anio);
        str.Append("  and i.trimestre ="+ trimestre);
        str.Append("   and i.clave_entidad_federativa ="+clave_entidad_federativa);*/

        List<DiasInventarioVO> lstMunicipal = new List<DiasInventarioVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstMunicipal = (from DataRow row in dt.Rows
                          select new DiasInventarioVO()
                          {
                              clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                              clave_municipio = row["clave_municipio"].ToString(),
                              municipio = row["municipio"].ToString(),
                              registro = int.Parse(row["registro"].ToString()),
                              construccion = int.Parse(row["construccion"].ToString()),
                              venta = int.Parse(row["venta"].ToString()),
                              total = int.Parse(row["total"].ToString()),
                              numero_vivienda = int.Parse(row["numero_vivienda"].ToString()),
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstMunicipal;
    }
    #region TOTALES
    public DiasInventarioVO getTotalEstatal(int anio, int trimestre)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select i.anio");
        str.Append(" ,i.trimestre");
        str.Append(" ,i.clave_entidad_federativa");
        str.Append(" ,case when e.descripcion='No distribuido' then 'Nacional' else e.descripcion end as entidad");
        str.Append(" ,i.registro");
        str.Append(" ,i.construccion");
        str.Append(" ,i.venta");
        str.Append(" ,i.total as total");
        str.Append(" ,i.numero_vivienda");
        str.Append(" from inventario_estatal i");
        str.Append(" inner join c_entidad_federativa e on e.clave = i.clave_entidad_federativa");
        str.Append(" where anio=" + anio);
        str.Append(" and trimestre=" + trimestre);
        str.Append(" and clave_entidad_federativa = '00'");
        DiasInventarioVO total = null;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            total = (from DataRow row in dt.Rows
                   select new DiasInventarioVO()
                   {
                       clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                       entidad = row["entidad"].ToString(),
                       registro = int.Parse(row["registro"].ToString()),
                       construccion = int.Parse(row["construccion"].ToString()),
                       venta = int.Parse(row["venta"].ToString()),
                       total = int.Parse(row["total"].ToString()),
                       numero_vivienda = int.Parse(row["numero_vivienda"].ToString()),
                   }).ToList().First<DiasInventarioVO>();


        }
        catch (Exception ex)
        {
            var error = ex;
        }

        return total;
    }
    public DiasInventarioVO getTotalMunicipal(int anio, int trimestre, string clave_entidad_federativa)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select i.anio");
        str.Append(" ,i.trimestre");
        str.Append(" ,i.clave_entidad_federativa");
        str.Append(" ,e.descripcion as entidad");
        str.Append(" ,i.registro,construccion");
        str.Append(" ,i.venta");
        str.Append(" ,i.total as total");
        str.Append(" ,i.numero_vivienda ");
        str.Append(" from inventario_estatal i");
        str.Append(" inner join c_entidad_federativa e on e.clave = i.clave_entidad_federativa");
        str.Append(" where anio = " + anio);
        str.Append(" and trimestre = " + trimestre);
        str.Append(" and clave_entidad_federativa = '" + clave_entidad_federativa + "'");
        DiasInventarioVO total = null;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            total = (from DataRow row in dt.Rows
                   select new DiasInventarioVO()
                   {
                       clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                       entidad = row["entidad"].ToString(),
                       registro = int.Parse(row["registro"].ToString()),
                       construccion = int.Parse(row["construccion"].ToString()),
                       venta = int.Parse(row["venta"].ToString()),
                       total = int.Parse(row["total"].ToString()),
                       numero_vivienda = int.Parse(row["numero_vivienda"].ToString()),
                   }).ToList().First<DiasInventarioVO>();


        }
        catch (Exception ex)
        {
            var error = ex;
        }

        return total;
    }
    #endregion

}