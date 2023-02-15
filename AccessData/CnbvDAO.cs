using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de CnbvDAO
/// </summary>
public class CnbvDAO
{
    private static CnbvDAO _instancia = null;

    public static CnbvDAO instancia()
    {
        return _instancia == null ? new CnbvDAO() : _instancia;
    }

    public CnbvDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region CUBO

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio from c_periodo_cnbv order by anio desc";
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

    public DateTime seleccionarFecha()
    {
        //string str = "select TO_DATE(concat(anio, TO_CHAR(mes,'fm00'), '01'), 'YYYYMMDD') as fecha from c_periodo_cnbv where actual";
        string endMonth = "SELECT (date_trunc('month',concat(anio,'-',TO_CHAR(mes,'fm00'),'-', '01')::date)+ interval '1 month' - interval '1 day')::date as fecha from c_periodo_cnbv where actual";

        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(endMonth, Constante.BD_SNIIV);
            fecha = (from DataRow row in dt.Rows select (DateTime)row["fecha"]).ToList<DateTime>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return fecha;
    }

    public int seleccionarMes()
    {
        string query = "SELECT mes from c_periodo_cnbv where actual";
        int mes = 0;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(query, Constante.BD_SNIIV);
            mes = (from DataRow row in dt.Rows select (int)row["mes"]).ToList<int>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return mes;
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
            case "esquema":
                lst[0] = "|s.descripcion as esquema";
                lst[1] = "|id_esquema";
                lst[2] = "|join c_esquema_cnbv s on f.id_esquema = s.id";
                break;
            case "estado":
                lst[0] = "|e.descripcion as estado";
                lst[1] = "|clave_estado";
                lst[2] = "|join c_entidad_federativa e on f.clave_estado = e.clave";
                break;
            case "genero":
                lst[0] = "|g.descripcion as sexo";
                lst[1] = "|id_genero";
                lst[2] = "|join c_genero g on f.id_genero = g.id";
                break;
            case "intermediario_financiero":
                lst[0] = "|i.descripcion as intermediario_financiero";
                lst[1] = "|clave_intermediario_financiero";
                lst[2] = "|join c_intermediario_financiero_cnbv i on f.clave_intermediario_financiero = i.id";
                break;
            case "linea_credito":
                lst[0] = "|l.descripcion as linea_credito";
                lst[1] = "|id_linea_credito";
                lst[2] = "|join c_linea_credito_cnbv l on f.id_linea_credito = l.id";
                break;
            case "mes":
                lst[0] = "|m.descripcion as mes";
                lst[1] = "|mes";
                lst[2] = "|join c_mes m on f.mes = m.id";
                break;
            case "modalidad":
                lst[0] = "|mo.descripcion as modalidad";
                lst[1] = "|id_modalidad";
                lst[2] = "|join c_modalidad_sniiv mo on f.id_modalidad = mo.id";
                break;
            case "municipio":
                lst[0] = "|mu.descripcion as municipio";
                lst[1] = "|clave_estado|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                break;
            case "poblacion_indigena":
                lst[0] = "|COALESCE(mu.poblacion_indigena, 'No distribuido') as poblacion_indigena";
                lst[1] = "|clave_estado|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                break;
            case "rango_edad":
                lst[0] = "|re.descripcion as grupo_edad";
                lst[1] = "|id_rango_edad";
                lst[2] = "|join c_rango_edad re on f.id_rango_edad = re.id";
                break;
            case "rango_salarial":
                lst[0] = "|rs.descripcion as rango_salarial";
                lst[1] = "|id_rango_salarial";
                lst[2] = "|join c_rango_salarial rs on f.id_rango_salarial = rs.id";
                break;
            case "valor_vivienda":
                lst[0] = "|vv.descripcion as valor_vivienda";
                lst[1] = "|id_valor_vivienda";
                lst[2] = "|join c_valor_vivienda vv on f.id_valor_vivienda = vv.id";
                break;
            default:
                lst[0] = "|COALESCE(mu.ambito, 'No distribuido') as zona";
                lst[1] = "|clave_estado|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
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
    protected bool isMunicipal(string clave_municipio)
    {
        return (clave_municipio == "0" || clave_municipio == Constante.FORMATO_MUNICIPAL) ? false : true;
    }

    public List<CnbvVO> getCubo(string anios, string clave_estado, string clave_municipio, string dimensiones)
    {
        string anio_inicio = anios.Split(',').First();
        string anio_fin = anios.Split(',').Last();

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

        List<CnbvVO> cubo = new List<CnbvVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",acciones,monto");
        query.Append(" from (select ");
        query.Append(strSubField);
        query.Append(",sum(acciones) as acciones,sum(monto) as monto");
        query.Append(" from cubo_cnbv_bak ");
        if (anio_inicio.Equals(anio_fin))
            query.Append("where anio = " + anio_inicio);
        else
            query.Append("where anio between " + anio_inicio + " and " + anio_fin);
        if (isEstatal(clave_estado))
            query.Append(" and clave_estado = '" + clave_estado + "'");
        if (isMunicipal(clave_municipio))
            query.Append(" and clave_municipio = '" + clave_municipio + "'");
        query.Append(" group by ");
        query.Append(strSubField);
        query.Append(") f ");
        query.Append(strTable);
        try
        {
            DataTable dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV);
            cubo = Util.instancia().ConvertDataTable<CnbvVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }
    /*
    public List<CnbvVO> getCubo(string anios, string dimensiones)
    {
        string anio_inicio = anios.Split(',').First();
        string anio_fin = anios.Split(',').Last();

        StringBuilder str = new StringBuilder();
        str.Append("select anio as año," + dimensiones + ",sum(monto) as monto,sum(acciones) as acciones");
        str.Append(" from cubo_cnbv_beta");
        if (anio_inicio.Equals(anio_fin))
            str.Append(" where anio = " + anio_inicio);
        else
            str.Append(" where anio = " + anio_inicio + " or anio = " + anio_fin);
        str.Append(" group by anio," + dimensiones);
        List<CnbvVO> cuboCnbv = new List<CnbvVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            cuboCnbv = Util.instancia().ConvertDataTable<CnbvVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cuboCnbv;
    }
    */
    #endregion
}