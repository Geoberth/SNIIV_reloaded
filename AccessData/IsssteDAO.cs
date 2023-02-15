using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de IsssteDAO
/// </summary>
public class IsssteDAO
{
    private static IsssteDAO _instancia = null;

    public static IsssteDAO instancia()
    {
        return _instancia == null ? new IsssteDAO() : _instancia;
    }

    public IsssteDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region CUBO

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio from c_periodo_issste order by anio desc";
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
        str.Append("select c.mes, m.descripcion from c_periodo_issste c");
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

    public DateTime seleccionarFecha()
    {
        //string str = "select TO_DATE(concat(anio, TO_CHAR(mes,'fm00'), '01'), 'YYYYMMDD') as fecha from c_periodo_issste where actual";
        string endMonth = "SELECT (date_trunc('month',concat(anio,'-',TO_CHAR(mes,'fm00'),'-', '01')::date)+ interval '1 month' - interval '1 day')::date as fecha from c_periodo_issste where actual";
        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(endMonth, Constante.BD_SNIIV);
            fecha = (from DataRow row in dt.Rows select (DateTime)row["fecha"]).ToList<DateTime>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return fecha;
    }

    public string[] crearConsulta(string parametro)
    {
        string[] lst = new string[3];
        switch (parametro)
        {
            case "anio":
                lst[0] = "|anio as año";
                lst[1] = "|anio";
                lst[2] = "|";
                break;
            case "estado":
                lst[0] = "|e.descripcion as estado";
                lst[1] = "|clave_entidad_federativa";
                lst[2] = "|join c_entidad_federativa e on f.clave_entidad_federativa = e.clave";
                break;
            case "genero":
                lst[0] = "|g.descripcion as sexo";
                lst[1] = "|id_genero";
                lst[2] = "|join c_genero g on f.id_genero = g.id";
                break;
            case "nombramiento":
                lst[0] = "|n.descripcion as nombramiento";
                lst[1] = "|id_nombramiento";
                lst[2] = "|join c_nombramiento n on f.id_nombramiento = n.id";
                break;
            /* case "municipio":
                 lst[0] = "|mu.descripcion as municipio";
                 lst[1] = "|clave_entidad_federativa|clave_municipio";
                 lst[2] = "|join c_municipio mu on f.clave_entidad_federativa = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                 break;
             case "rango_edad":
                 lst[0] = "|re.abreviacion as rango_edad";
                 lst[1] = "|clave_rango_edad";
                 lst[2] = "|join c_rango_edad_imss re on f.clave_rango_edad = re.clave";
                 break;*/
            case "rango_salarial":
                lst[0] = "|rs.descripcion as rango_salarial";
                lst[1] = "|id_rango_salarial";
                lst[2] = "|join c_rango_salarial rs on f.id_rango_salarial = rs.id";
                break;
            case "rango_antiguedad":
                lst[0] = "|ra.descripcion as rango_antiguedad";
                lst[1] = "|id_rango_antiguedad";
                lst[2] = "|join c_rango_antiguedad ra on f.id_rango_antiguedad = ra.id";
                break;
            case "sector":
                lst[0] = "|se.descripcion as sector";
                lst[1] = "|id_sector";
                lst[2] = "|join c_sector se on f.id_sector = se.id";
                break;
            /*case "rango_vsm":
                lst[0] = "|rs.abreviacion as rango_vsm";
                lst[1] = "|clave_rango_vsm";
                lst[2] = "|join c_rango_vsm_imss rs on f.clave_rango_vsm = rs.clave";
                break;
            case "rango_uma":
                lst[0] = "|ru.abreviacion as rango_uma";
                lst[1] = "|clave_rango_uma";
                lst[2] = "|join c_rango_uma_imss ru on f.clave_rango_uma = ru.clave";
                break;
            case "sector_economico":
                lst[0] = "|t.descripcion as sector_economico";
                lst[1] = "|id_sector_economico_2";
                lst[2] = "|join c_sector_economico_2 t on f.id_sector_economico_2 = t.id";
                break;
            */
            default: // rango_salarial
                lst[0] = "|rs.descripcion as rango_salarial";
                lst[1] = "|id_rango_salarial";
                lst[2] = "|join c_rango_salarial rs on f.id_rango_salarial = rs.id";
                break;
        }
        return lst;
    }

    public string limpiarConsulta(string cadena, string separador)
    {
        HashSet<string> hs = new HashSet<string>(cadena.TrimStart('|').Split('|'));
        return string.Join(separador, hs);
    }

    protected bool isEstatal(string clave_estado)
    {
        return (clave_estado == "0" || clave_estado == Constante.FORMATO_ESTATAL) ? false : true;
    }
    /* protected bool isMunicipal(string clave_municipio)
     {
         return (clave_municipio == "0" || clave_municipio == Constante.FORMATO_MUNICIPAL) ? false : true;
     }
     */
    public List<IsssteVO> getCubo(string periodo, string clave_estado, string dimensiones)
    {
        string anio = periodo.Split(',').First();
        //string mes = periodo.Split(',').Last();

        string[] lstDimensiones = dimensiones.Split(',');
        string[] lst = new string[3];

        StringBuilder field = new StringBuilder();
        StringBuilder subField = new StringBuilder();
        StringBuilder table = new StringBuilder();
        foreach (string dimension in lstDimensiones)
        {
            lst = crearConsulta(dimension);
            field.Append(lst[0]);
            subField.Append(lst[1]);
            table.Append(lst[2]);
        }
        string strField = limpiarConsulta(field.ToString(), ",");
        string strSubField = limpiarConsulta(subField.ToString(), ",");
        string strTable = limpiarConsulta(table.ToString(), " ");

        List<IsssteVO> cubo = new List<IsssteVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",trabajadores");
        query.Append(" from (select ");
        query.Append(strSubField);
        query.Append(",sum(trabajadores) as trabajadores");
        query.Append(" from cubo_issste ");
        query.Append("where anio = " + anio); // + " and mes = " + mes
        if (isEstatal(clave_estado))
            query.Append(" and clave_entidad_federativa = '" + clave_estado + "'");
        /*if (isMunicipal(clave_municipio))
            query.Append(" and clave_municipio = '" + clave_municipio + "'");*/
        query.Append(" group by ");
        query.Append(strSubField);
        query.Append(") f ");
        query.Append(strTable);
        try
        {
            DataTable dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV);
            cubo = Util.instancia().ConvertDataTable<IsssteVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }

    #endregion

    #region DASHBOARD

    public List<IsssteVO> getKPIs(int anio)
    {
        List<IsssteVO> KPIs = new List<IsssteVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select e.descripcion as estado, n.descripcion as nombramiento, g.descripcion as genero, rs.descripcion as rango_salarial, s.descripcion as sector, trabajadores");
        query.Append(" from (");
        query.Append(" select clave_entidad_federativa, id_nombramiento, id_genero, id_rango_salarial, id_sector, sum(trabajadores) as trabajadores");
        query.Append(" from cubo_issste");
        query.Append(" where anio = " + anio);
        query.Append(" group by clave_entidad_federativa, id_nombramiento, id_genero, id_rango_salarial, id_sector");
        query.Append(" ) t");
        query.Append(" join c_entidad_federativa e on e.clave = t.clave_entidad_federativa");
        query.Append(" join c_nombramiento n on n.id = t.id_nombramiento");
        query.Append(" join c_genero g on g.id = t.id_genero");
        query.Append(" join c_rango_salarial rs on rs.id = t.id_rango_salarial");
        query.Append(" join c_sector s on s.id = t.id_sector");

        try
        {
            DataTable dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new IsssteVO()
                    {
                        estado = row["estado"].ToString(),
                        nombramiento = row["nombramiento"].ToString(),
                        sexo = row["genero"].ToString(),
                        rango_salarial = row["rango_salarial"].ToString(),
                        sector = row["sector"].ToString(),
                        trabajadores = UInt32.Parse(row["trabajadores"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    #endregion

}