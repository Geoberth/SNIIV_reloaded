using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de CatalogoDAO
/// </summary>
public class CatalogoDAO
{
    private static CatalogoDAO _instancia = null;

    public static CatalogoDAO instancia()
    {
        return _instancia == null ? new CatalogoDAO() : _instancia;
    }

    public CatalogoDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarRegion()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select id, descripcion from c_region where id != 9");
        List<CatalogoVO> lstRegion = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstRegion = (from DataRow row in dt.Rows
                          select new CatalogoVO()
                          {
                              id = row["id"].ToString(),
                              descripcion = row["descripcion"].ToString()
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstRegion;
    }

    public List<CatalogoVO> seleccionarEntidadFederativa()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select clave, descripcion from c_entidad_federativa where clave != '00'");
        List<CatalogoVO> lstEstados = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstEstados = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["clave"].ToString(),
                         descripcion = row["descripcion"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstEstados;
    }

    public List<CatalogoVO> seleccionarEntidadFederativa(int id_region)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select clave, descripcion from c_entidad_federativa where clave != '00' and id_region = " + id_region);
        List<CatalogoVO> lstEstados = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstEstados = (from DataRow row in dt.Rows
                          select new CatalogoVO()
                          {
                              id = row["clave"].ToString(),
                              descripcion = row["descripcion"].ToString()
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstEstados;
    }

    public List<CatalogoVO> seleccionarMunicipio(string clave_entidad_federativa)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select clave_mun, descripcion from c_municipio where clave_mun != '000' and clave_entidad_federativa = '" + clave_entidad_federativa + "' order by clave_mun");
        List<CatalogoVO> lstEstados = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstEstados = (from DataRow row in dt.Rows
                          select new CatalogoVO()
                          {
                              id = row["clave_mun"].ToString(),
                              descripcion = row["descripcion"].ToString()
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstEstados;
    }

    public List<CatalogoVO> seleccionarLocalidad(string clave_entidad_federativa, string clave_municipio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select clave, descripcion from c_localidad where clave != '000' and clave_entidad_federativa = '" + clave_entidad_federativa + "' and clave_municipio = '" + clave_municipio + "' order by clave");
        List<CatalogoVO> lstEstados = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstEstados = (from DataRow row in dt.Rows
                          select new CatalogoVO()
                          {
                              id = row["clave"].ToString(),
                              descripcion = row["descripcion"].ToString()
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstEstados;
    }

    public List<CatalogoVO> seleccionarFechasMapa()
    {
        //Selecciona la fecha del mapa
        StringBuilder str = new StringBuilder();

        str.Append("SELECT 'indigenas' AS id, 'Población indígena 2017' AS descripcion");

        str.Append(" UNION");
        str.Append(" SELECT 'pcus' AS id, 'PCU´s 2018' AS titulo");
        str.Append(" UNION");
        str.Append(" SELECT  'oferta' AS id, CONCAT('Oferta ', m.descripcion, ' ', anio) AS descripcion");
        str.Append(" FROM c_periodo_registro_vivienda");
        str.Append(" JOIN c_mes m on m.id = mes");
        str.Append(" WHERE actual = true");
        str.Append(" UNION");
        str.Append(" SELECT 'sisevive' AS id, CONCAT('SISEVIVE ', m.descripcion, ' ', EXTRACT(YEAR FROM fecha)) AS descripcion");
        str.Append(" FROM c_periodo_sisevive");
        str.Append(" JOIN c_mes m on m.id = EXTRACT(MONTH FROM fecha)");
        str.Append(" WHERE actual = true ");
        str.Append(" ORDER BY id ASC ;");

        System.Diagnostics.Debug.WriteLine(str.ToString());
        List<CatalogoVO> lstRegion = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstRegion = (from DataRow row in dt.Rows
                         select new CatalogoVO()
                         {
                             id = row["id"].ToString(),
                             descripcion = row["descripcion"].ToString()
                         }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstRegion;
    }
}