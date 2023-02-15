using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de LevantamientoDAO
/// </summary>
public class LevantamientoDAO
{
    private static LevantamientoDAO _instancia = null;

    public static LevantamientoDAO instancia()
    {
        return _instancia == null ? new LevantamientoDAO() : _instancia;
    }

    public LevantamientoDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select id,descripcion from c_programa_reconstruccion order by id";
        List<CatalogoVO> programa = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            programa = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["id"].ToString(),
                         descripcion = row["descripcion"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return programa;
    }

    public List<CatalogoVO> seleccionarModalidad(int programa)
    {
        StringBuilder str = new StringBuilder();
        str.Append(" select 0 as id_modalidad,'Todo' as descripcion ");
        str.Append(" union all ");
        str.Append(" select distinct r.id_modalidad, mr.descripcion from reconstruccion r ");
        str.Append(" join c_modalidad_reconstruccion mr on mr.id = r.id_modalidad ");
        str.Append("  where mr.id_programa_reconstruccion = " + programa);
        List<CatalogoVO> modalidades = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            modalidades = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["id_modalidad"].ToString(),
                         descripcion = row["descripcion"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return modalidades;
    }

    public List<CatalogoVO> seleccionarMes(int modalidad, int programa)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select distinct r.id_mes, m.descripcion from reconstruccion r");
        str.Append(" join c_mes m on m.id = r.id_mes ");
        str.Append(" join c_modalidad_reconstruccion mr ");
        str.Append(" on mr.id = r.id_modalidad ");
        str.Append(" join c_programa_reconstruccion pr ");
        str.Append(" on pr.id = mr.id_programa_reconstruccion ");
        if (modalidad != 0)
        {
            str.Append(" where r.id_modalidad = " + modalidad);
        }
        else {
            str.Append(" where mr.id_programa_reconstruccion=" + programa);
        }

        
        List<CatalogoVO> meses = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            meses = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["id_mes"].ToString(),
                         descripcion = row["descripcion"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return meses;
    }

    public List<LevantamientoVO> seleccionarEstatal(int programa,int modalidad, int mes)
    {
        string str = "call sp_reconstruccion_estatal(" + programa + ", " +modalidad+ ", " + mes + ")";
        List<LevantamientoVO> lstEstatal = new List<LevantamientoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstEstatal = (from DataRow row in dt.Rows
                          select new LevantamientoVO()
                          {
                              clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                              entidad = row["entidad"].ToString(),
                              modalidad = row["modalidad"].ToString(),
                              programa = row["programa"].ToString(),
                              meta = int.Parse(row["meta"].ToString()),
                              avance = int.Parse(row["avance"].ToString()),
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstEstatal;
    }


    public List<LevantamientoVO> seleccionarMunicipal(int programa, int modalidad, int mes, string clave_estado)
    { 
        string str = "call sp_reconstruccion_municipal(" + programa + ", " + modalidad + ", " + mes + ", '" + clave_estado + "')";
        List<LevantamientoVO> lstMunicipal = new List<LevantamientoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstMunicipal = (from DataRow row in dt.Rows
                            select new LevantamientoVO()
                            {
                                clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                                clave_municipio = row["clave_municipio"].ToString(),
                                municipio = row["municipio"].ToString(),
                                modalidad = row["modalidad"].ToString(),
                                programa = row["programa"].ToString(),
                                meta = int.Parse(row["meta"].ToString()),
                                avance = int.Parse(row["avance"].ToString()),
                            }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstMunicipal;
    }
}