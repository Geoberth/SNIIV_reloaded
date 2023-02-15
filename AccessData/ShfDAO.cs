using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de ShfDAO
/// </summary>
public class ShfDAO
{
    private static ShfDAO _instancia = null;

    public static ShfDAO instancia()
    {
        return _instancia == null ? new ShfDAO() : _instancia;
    }

    public ShfDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region CUBO

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio from c_periodo_shf order by anio desc";
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
        string str = "select last_day(concat(anio, '-', mes, '-1')) as fecha from c_periodo_shf order by anio desc , mes desc limit 1";
        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
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
            case "esquema":
                lst[0] = "|s.descripcion as esquema";
                lst[1] = "|id_esquema";
                lst[2] = "|join c_producto_presentar_ef_shf s on f.id_esquema = s.id";
                break;
            case "estado":
                lst[0] = "|e.descripcion as estado";
                lst[1] = "|clave_entidad_federativa";
                lst[2] = "|join c_entidad_federativa e on f.clave_entidad_federativa = e.clave";
                break;
            case "genero":
                lst[0] = "|g.descripcion as genero";
                lst[1] = "|id_genero";
                lst[2] = "|join c_genero g on f.id_genero = g.id";
                break;
            case "intermediario_financiero":
                lst[0] = "|i.descripcion as intermediario_financiero";
                lst[1] = "|id_intermediario_financiero";
                lst[2] = "|join c_tipo_institucion_shf i on f.id_intermediario_financiero = i.id";
                break;
            case "mes":
                lst[0] = "|m.descripcion as mes";
                lst[1] = "|mes";
                lst[2] = "|join c_mes m on f.mes = m.id";
                break;
            case "modalidad":
                lst[0] = "|mo.descripcion as modalidad";
                lst[1] = "|id_modalidad";
                lst[2] = "|join c_tipo_vivienda_fonhapo mo on f.id_modalidad = mo.id";
                break;
            case "municipio":
                lst[0] = "|mu.descripcion as municipio";
                lst[1] = "|clave_entidad_federativa|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_entidad_federativa = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                break;
            case "poblacion_indigena":
                lst[0] = "|COALESCE(mu.poblacion_indigena, 'No distribuido') as poblacion_indigena";
                lst[1] = "|clave_entidad_federativa|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_entidad_federativa = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                break;
            case "rango_edad":
                lst[0] = "|re.descripcion as rango_edad";
                lst[1] = "|id_rango_edad";
                lst[2] = "|join c_rango_edad re on f.id_rango_edad = re.id";
                break;
            case "rango_salarial":
                lst[0] = "|rs.descripcion as rango_salarial";
                lst[1] = "|id_rango_salarial";
                lst[2] = "|join c_rango_salarial rs on f.id_rango_salarial = rs.id";
                break;
            case "tipo_ingreso":
                lst[0] = "|l.descripcion as tipo_ingreso";
                lst[1] = "|id_tipo_ingreso";
                lst[2] = "|join c_tipo_ingreso_shf l on f.id_tipo_ingreso = l.id";
                break;
            case "valor_vivienda":
                lst[0] = "|vv.descripcion as valor_vivienda";
                lst[1] = "|id_valor_vivienda";
                lst[2] = "|join c_valor_vivienda vv on f.id_valor_vivienda = vv.id";
                break;
            default:
                lst[0] = "|COALESCE(mu.ambito, 'No distribuido') as zona";
                lst[1] = "|clave_entidad_federativa|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_entidad_federativa = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
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

    public List<ShfVO> getCubo(string anios, string clave_estado, string clave_municipio, string dimensiones)
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

        List<ShfVO> cubo = new List<ShfVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",acciones,monto");
        query.Append(" from (select ");
        query.Append(strSubField);
        query.Append(",sum(acciones) as acciones,sum(monto) as monto");
        query.Append(" from cubo_shf ");
        if (anio_inicio.Equals(anio_fin))
            query.Append("where anio = " + anio_inicio);
        else
            query.Append("where anio between " + anio_inicio + " and " + anio_fin);
        if (isEstatal(clave_estado))
            query.Append(" and clave_entidad_federativa = '" + clave_estado + "'");
        if (isMunicipal(clave_municipio))
            query.Append(" and clave_municipio = '" + clave_municipio + "'");
        query.Append(" group by ");
        query.Append(strSubField);
        query.Append(") f ");
        query.Append(strTable);
        try
        {
            DataTable dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV);
            cubo = Util.instancia().ConvertDataTable<ShfVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }
    #endregion
}