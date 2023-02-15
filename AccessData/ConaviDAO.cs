using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de ConaviDAO
/// </summary>
public class ConaviDAO
{
    private static ConaviDAO _instancia = null;

    public static ConaviDAO instancia()
    {
        return _instancia == null ? new ConaviDAO() : _instancia;
    }

    public ConaviDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region DASHBOARD

    public DateTime seleccionarFecha()
    {
        //string str = "select fecha from c_periodo_conavi_semanal where actual";
        string endMonth = "SELECT (date_trunc('month',fecha)+ interval '1 month' - interval '1 day')::date as fecha from c_periodo_conavi_semanal where actual";
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
        string query = "SELECT cast(extract(month from fecha) as integer) as mes from c_periodo_conavi_semanal where actual";
        int mes = 0;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(query, Constante.BD_SNIIV);
            mes = (from DataRow row in dt.Rows select (int)row["mes"]).ToList<int>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return mes;
    }

    public List<ConaviVO> getKPIs()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select m.descripcion as modalidad, t.descripcion as programa_presupuestal, acciones, round(monto) as monto ");
        str.Append("from (select id_modalidad, id_programa_presupuestal, sum(acciones) as acciones, sum(monto) as monto ");
        str.Append("from cubo_conavi_bak ");
        str.Append("where anio = (select extract(year from fecha) from c_periodo_conavi_semanal where actual = true) ");
        str.Append("group by id_modalidad, id_programa_presupuestal) s ");
        str.Append("join c_subprograma_sniiv m on m.id = s.id_modalidad ");
        str.Append("join c_programa_presupuestal t on t.id = s.id_programa_presupuestal");
        List<ConaviVO> KPIs = new List<ConaviVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new ConaviVO()
                    {
                        modalidad = row["modalidad"].ToString(),
                        programa_presupuestal = row["programa_presupuestal"].ToString(),
                        acciones = Int32.Parse(row["acciones"].ToString()),
                        monto = decimal.Parse(row["monto"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    public List<ConaviVO> getKPIs2()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select e.descripcion as estado, ");
        str.Append("g.descripcion as genero, re.descripcion as rango_edad, rs.descripcion as rango_salarial, ");
        str.Append("pp.descripcion as programa_presupuestal, tv.descripcion as tipo_vivienda, ");
        str.Append("round(monto) as monto, acciones from ");
        str.Append("(select clave_estado, id_genero, id_rango_edad, id_rango_salarial, id_programa_presupuestal, id_tipo_vivienda, ");
        str.Append("sum(monto) as monto, sum(acciones) as acciones ");
        str.Append("from cubo_conavi_bak where anio = (select extract(year from fecha) from c_periodo_conavi_semanal where actual = true) ");
        str.Append("group by clave_estado, ");
        str.Append("id_genero, id_rango_edad, id_rango_salarial, ");
        str.Append("id_programa_presupuestal, id_tipo_vivienda) t ");
        str.Append("join c_entidad_federativa e on e.clave = t.clave_estado ");
        str.Append("join c_genero g on g.id = t.id_genero ");
        str.Append("join c_rango_edad re on re.id = t.id_rango_edad ");
        str.Append("join c_rango_salarial rs on rs.id = t.id_rango_salarial ");
        str.Append("left join c_programa_presupuestal pp on pp.id = t.id_programa_presupuestal ");
        str.Append("join c_tipo_vivienda tv on tv.id = t.id_tipo_vivienda");
        List<ConaviVO> KPIs = new List<ConaviVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new ConaviVO()
                    {
                        estado = row["estado"].ToString(),
                        sexo = row["genero"].ToString(),
                        grupo_edad = row["rango_edad"].ToString(),
                        rango_salarial = row["rango_salarial"].ToString(),
                        // valor_vivienda = row["valor_vivienda"].ToString(),
                        programa_presupuestal = row["programa_presupuestal"].ToString(),
                        tipo_vivienda = row["tipo_vivienda"].ToString(),
                        acciones = Int32.Parse(row["acciones"].ToString()),
                        monto = decimal.Parse(row["monto"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    #endregion

    #region CUBO

    public List<CatalogoVO> seleccionarAnioSemanal()
    {
        string str = "select distinct date_part('year', fecha) as anio from c_periodo_conavi_semanal order by anio desc";
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

    protected string[] crearConsulta(string parametro)
    {
        string[] lst = new string[4];
        switch (parametro)
        {
            case "anio":
                lst[0] = "|anio as año";
                lst[1] = "|anio";
                lst[2] = "|";
                lst[3] = "|";
                break;
            case "desarrollo_certificado":
                lst[0] = "|d.descripcion as desarrollo_certificado";
                lst[1] = "|id_dc";
                lst[2] = "|join c_dc d on f.id_dc = d.id";
                lst[3] = "| and id_programa_presupuestal = 4";
                break;
            case "esquema":
                lst[0] = "|s.descripcion as esquema";
                lst[1] = "|id_esquema";
                lst[2] = "|join c_esquema_conavi s on f.id_esquema = s.id";
                lst[3] = "| and id_programa_presupuestal = 4";
                break;
            case "estado":
                lst[0] = "|e.descripcion as estado";
                lst[1] = "|clave_estado";
                lst[2] = "|join c_entidad_federativa e on f.clave_estado = e.clave";
                lst[3] = "|";
                break;
            case "entidad_ejecutora":
                lst[0] = "|ee.descripcion as entidad_ejecutora";
                lst[1] = "|id_ee";
                lst[2] = "|join c_ee ee on f.id_ee = ee.id";
                lst[3] = "| and id_programa_presupuestal = 4";
                break;
            case "genero":
                lst[0] = "|g.descripcion as sexo";
                lst[1] = "|id_genero";
                lst[2] = "|join c_genero g on f.id_genero = g.id";
                lst[3] = "|";
                break;
            case "mes":
                lst[0] = "|m.descripcion as mes";
                lst[1] = "|mes";
                lst[2] = "|join c_mes m on f.mes = m.id";
                lst[3] = "|";
                break;
            case "modalidad":
                lst[0] = "|mo.descripcion as modalidad";
                lst[1] = "|id_modalidad";
                lst[2] = "|join c_subprograma_sniiv mo on f.id_modalidad = mo.id";
                lst[3] = "|";
                break;
            case "municipio":
                lst[0] = "|mu.descripcion as municipio";
                lst[1] = "|clave_estado|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                lst[3] = "|";
                break;
            case "organismo_ejecutor_obra":
                lst[0] = "|o.descripcion as organismo_ejecutor_obra";
                lst[1] = "|id_oeo";
                lst[2] = "|join c_oeo o on f.id_oeo = o.id";
                lst[3] = "| and id_programa_presupuestal = 4";
                break;
            case "pcu":
                lst[0] = "|p.descripcion as pcu";
                lst[1] = "|id_pcu";
                lst[2] = "|join c_pcu p on f.id_pcu = p.id";
                lst[3] = "| and id_programa_presupuestal = 4";
                break;
            case "poblacion_indigena":
                lst[0] = "|COALESCE(mu.poblacion_indigena, 'No distribuido') as poblacion_indigena";
                lst[1] = "|clave_estado|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                lst[3] = "|";
                break;
            case "rango_edad":
                lst[0] = "|re.descripcion as grupo_edad";
                lst[1] = "|id_rango_edad";
                lst[2] = "|join c_rango_edad re on f.id_rango_edad = re.id";
                lst[3] = "|";
                break;
            case "rango_salarial":
                lst[0] = "|rs.descripcion as rango_salarial";
                lst[1] = "|id_rango_salarial";
                lst[2] = "|join c_rango_salarial rs on f.id_rango_salarial = rs.id";
                lst[3] = "|";
                break;
            case "tipo_entidad_ejecutora":
                lst[0] = "|t.descripcion as tipo_entidad_ejecutora";
                lst[1] = "|id_tipo_ee";
                lst[2] = "|join c_tipo_ee_sniiv t on f.id_tipo_ee = t.id";
                lst[3] = "| and id_programa_presupuestal = 4";
                break;
            case "tipo_vivienda":
                lst[0] = "|tv.descripcion as tipo_vivienda";
                lst[1] = "|id_tipo_vivienda";
                lst[2] = "|join c_tipo_vivienda tv on f.id_tipo_vivienda = tv.id";
                lst[3] = "| and id_programa_presupuestal = 4";
                break;
            case "valor_vivienda":
                lst[0] = "|vv.descripcion as valor_vivienda";
                lst[1] = "|id_valor_vivienda";
                lst[2] = "|join c_valor_vivienda vv on f.id_valor_vivienda = vv.id";
                lst[3] = "|"; //"| and id_programa_presupuestal = 4";
                break;
            case "vivienda_sustentable":
                lst[0] = "|vs.descripcion as vivienda_sustentable";
                lst[1] = "|id_vivienda_sustentable";
                lst[2] = "|join c_vivienda_sustentable vs on f.id_vivienda_sustentable = vs.id";
                lst[3] = "| and id_programa_presupuestal = 4";
                break;
            case "programa_presupuestal":
                lst[0] = "|pp.descripcion as programa_presupuestal";
                lst[1] = "|id_programa_presupuestal";
                lst[2] = "|join c_programa_presupuestal pp on f.id_programa_presupuestal = pp.id";
                lst[3] = "|";
                break;
            case "linea_apoyo":
                lst[0] = "|cl.descripcion as linea_apoyo";
                lst[1] = "|id_linea_apoyo";
                lst[2] = "|join c_linea_apoyo_presidencia cl on f.id_linea_apoyo = cl.id";
                lst[3] = "|";
                break;
            default:
                lst[0] = "|COALESCE(mu.ambito, 'No distribuido') as zona";
                lst[1] = "|clave_estado|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                lst[3] = "|";
                break;
        }
        return lst;
    }

    protected string limpiarConsulta(string cadena, string separador)
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

    public List<ConaviVO> getCubo(string anios, string clave_estado, string clave_municipio, string dimensiones)
    {
        string anio_inicio = anios.Split(',').First();
        string anio_fin = anios.Split(',').Last();

        string[] lstDimensiones = dimensiones.Split(',');
        string[] lst = new string[4];

        StringBuilder field = new StringBuilder();
        StringBuilder subField = new StringBuilder();
        StringBuilder table = new StringBuilder();
        StringBuilder cond = new StringBuilder();
        foreach (string dimension in lstDimensiones)
        {
            lst = crearConsulta(dimension);
            field.Append(lst[0]);
            subField.Append(lst[1]);
            table.Append(lst[2]);
            cond.Append(lst[3]);
        }
        string strField = limpiarConsulta(field.ToString(), ",");
        string strSubField = limpiarConsulta(subField.ToString(), ",");
        string strTable = limpiarConsulta(table.ToString(), " ");
        string strCond = limpiarConsulta(cond.ToString(), " ");

        List<ConaviVO> cubo = new List<ConaviVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",acciones,monto");
        query.Append(" from (select ");
        query.Append(strSubField);
        query.Append(",sum(acciones) as acciones,sum(monto) as monto");
        query.Append(" from cubo_conavi_bak ");
        if (anio_inicio.Equals(anio_fin))
            query.Append("where anio = " + anio_inicio);
        else
            query.Append("where anio between " + anio_inicio + " and " + anio_fin);
        if (isEstatal(clave_estado))
            query.Append(" and clave_estado = '" + clave_estado + "'");
        if (isMunicipal(clave_municipio))
            query.Append(" and clave_municipio = '" + clave_municipio + "'");
        query.Append(strCond);
        query.Append(" group by ");
        query.Append(strSubField);
        query.Append(") f ");
        query.Append(strTable);
        try
        {
            DataTable dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV);
            cubo = Util.instancia().ConvertDataTable<ConaviVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }

    /*
    public List<ConaviVO> getCubo(string anios, string dimensiones)
    {
        string anio_inicio = anios.Split(',').First();
        string anio_fin = anios.Split(',').Last();

        StringBuilder str = new StringBuilder();
        str.Append("select anio as año," + dimensiones + ",sum(monto) as monto,sum(acciones) as acciones");
        str.Append(" from cubo_conavi");
        if (anio_inicio.Equals(anio_fin))
            str.Append(" where anio = " + anio_inicio);
        else
            str.Append(" where anio = " + anio_inicio + " or anio = " + anio_fin);
        str.Append(" group by anio," + dimensiones);
        List<ConaviVO> cuboConavi = new List<ConaviVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            cuboConavi = Util.instancia().ConvertDataTable<ConaviVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cuboConavi;
    }
    */
    #endregion

    #region TEMÁTICO

    //Actualmente apunta a cubo_conavi (semanal), deberá apuntar a los datos mensuales
    //Cambiará el campo dependiendo la métrica

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio from c_periodo_conavi order by anio desc";
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

    public Option getMes(string clave_estado, int anio, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        opt.legend = new List<string> { anioAnterior.ToString(), anio.ToString() };
        StringBuilder str = new StringBuilder();
        //En caso de tener una mejor idea, favor cambiar lógica
        str.Append("select COALESCE(c.anio, " + anioAnterior + ") as anio, m.descripcion as mes, COALESCE(c." + metrica + ", 0) as " + metrica);
        str.Append(" from (select anio, mes, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi_bak");
        str.Append(" where anio = " + anioAnterior);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, mes) c");
        str.Append(" right join c_mes m on c.mes = m.id");
        str.Append(" union");
        str.Append(" select COALESCE(c.anio, " + anio + ") as anio, m.descripcion as mes, COALESCE(c." + metrica + ", 0) as " + metrica + "");
        str.Append(" from (select anio, mes, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi_bak");
        str.Append(" where anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, mes) c");
        str.Append(" right join c_mes m on c.mes = m.id");
        /*str.Append("select anio, mes, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi");
        str.Append(" where (anio = " + anioAnterior + " or (anio = " + anio + " and id_mes <= " + mes + "))");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, mes order by anio, id_mes");*/
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row[metrica].ToString()),
                                 name = row["mes"].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["mes"].ToString()
                           }).ToList();
            List<string> lstMes = new List<string>(new string[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" });
            opt.xAxis = lstMes;
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            Serie serie1 = new Serie(anioAnterior.ToString(), serieAnterior);
            opt.series.Add(serie0);
            opt.series.Add(serie1);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getModalidad(string clave_estado, int anio, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select anio, m.descripcion as modalidad, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi_bak");
        str.Append(" join c_subprograma_sniiv m on id_modalidad = m.id");
        str.Append(" where anio in (" + anioAnterior + ", " + anio + ") and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, modalidad");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row[metrica].ToString()),
                                 name = row["modalidad"].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["modalidad"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            lstLegend.UnionWith(serieAnterior.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            Serie serie1 = new Serie(anioAnterior.ToString(), serieAnterior);
            opt.series.Add(serie0);
            opt.series.Add(serie1);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getTipoEe(string clave_estado, int anio, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select anio, e.leyenda as entidad_ejecutora, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi_bak");
        str.Append(" join c_tipo_ee_sniiv e on id_tipo_ee = e.id");
        str.Append(" where anio in (" + anioAnterior + ", " + anio + ") and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, id_tipo_ee");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row[metrica].ToString()),
                                 name = row["entidad_ejecutora"].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["entidad_ejecutora"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            lstLegend.UnionWith(serieAnterior.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            Serie serie1 = new Serie(anioAnterior.ToString(), serieAnterior);
            opt.series.Add(serie0);
            opt.series.Add(serie1);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getTipoMunicipio(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select COALESCE(m.ambito, 'No distribuido') as tipo_municipio, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi_bak");
        str.Append(" join c_entidad_federativa e on e.clave = clave_estado");
        str.Append(" join c_municipio m on m.clave = clave_municipio and m.clave_entidad_federativa = e.clave");
        str.Append(" where anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by tipo_municipio");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = float.Parse(row[metrica].ToString()),
                       name = row["tipo_municipio"].ToString()
                   }).ToList();
            opt.legend = lst.Select(x => x.name).ToList<string>();
            Serie serie = new Serie("tipo_municipio", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getDistribucion(string clave_estado, int anio, string dimension)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select anio, r.descripcion as " + dimension + ", sum(acciones) as acciones");
        str.Append(" from cubo_conavi_bak");
        str.Append(" join c_" + dimension + " r on r.id = id_" + dimension);
        str.Append(" where anio in (" + anioAnterior + ", " + anio + ") and id_" + dimension + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, id_" + dimension);
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row["acciones"].ToString()),
                                 name = row[dimension].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row["acciones"].ToString()),
                               name = row[dimension].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            lstLegend.UnionWith(serieAnterior.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            Serie serie1 = new Serie(anioAnterior.ToString(), serieAnterior);
            opt.series.Add(serie0);
            opt.series.Add(serie1);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getValorVivienda(string clave_estado, int anio, string dimension)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        opt.legend = new List<string> { anioAnterior.ToString(), anio.ToString() };
        StringBuilder str = new StringBuilder();
        str.Append(" select COALESCE(anio, " + anioAnterior + ") as anio, e.descripcion as " + dimension + ", COALESCE(monto, 0) as monto");
        str.Append(" from");
        str.Append("    (select anio, id_" + dimension + ", sum(monto) as monto");
        str.Append("    from cubo_conavi_bak");
        str.Append("    where anio = " + anioAnterior);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by anio, id_" + dimension + ") t");
        str.Append(" right join c_" + dimension + " e on e.id = id_" + dimension);
        str.Append(" where e.id != 0");
        str.Append(" union");
        str.Append(" select COALESCE(anio, " + anio + ") as anio, e.descripcion as " + dimension + ", COALESCE(monto, 0) as monto");
        str.Append(" from");
        str.Append("    (select anio, id_" + dimension + ", sum(monto) as monto");
        str.Append("    from cubo_conavi_bak");
        str.Append("    where anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by anio, id_" + dimension + ") t");
        str.Append(" right join c_" + dimension + " e on e.id = id_" + dimension);
        str.Append(" where e.id != 0");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row["monto"].ToString()),
                                 name = row[dimension].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row["monto"].ToString()),
                               name = row[dimension].ToString()
                           }).ToList();
            var lstXaxis = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(serieAnterior.Select(x => x.name).ToList<string>());
            opt.xAxis = lstXaxis.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            Serie serie1 = new Serie(anioAnterior.ToString(), serieAnterior);
            opt.series.Add(serie0);
            opt.series.Add(serie1);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getGenero(string clave_estado, int anio, string dimension)
    {
        string hombre = "Hombre";
        string mujer = "Mujer";
        Option opt = new Option();
        opt.legend = new List<string> { hombre, mujer };
        StringBuilder str = new StringBuilder();
        //En caso de tener una mejor idea, favor cambiar lógica
        str.Append(" select e.descripcion as genero, s.descripcion as " + dimension + ",");
        str.Append(" round(COALESCE(sum(acciones) * 100 / (");
        str.Append("    select sum(acciones)");
        str.Append("    from cubo_conavi_bak");
        str.Append("    where id_" + dimension + " = s.id and anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    ), 0),2) as porcentaje");
        str.Append(" from");
        str.Append("    (select id_genero, id_" + dimension + ", sum(acciones) as acciones");
        str.Append("    from cubo_conavi_bak");
        str.Append("    where anio = " + anio + " and id_genero = " + 1);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by id_" + dimension + ") t");
        str.Append(" right join c_" + dimension + " s on s.id = id_" + dimension);
        str.Append(" join c_genero e on e.id = COALESCE(id_genero, " + 1 + ")");
        str.Append(" where s.id != 0");
        str.Append(" group by s.id, acciones");
        str.Append(" union");
        str.Append(" select e.descripcion as genero, s.descripcion as " + dimension + ",");
        str.Append(" round(COALESCE(sum(acciones) * 100 / (");
        str.Append("    select sum(acciones)");
        str.Append("    from cubo_conavi_bak");
        str.Append("    where id_" + dimension + " = s.id and anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    ), 0),2) as porcentaje");
        str.Append(" from");
        str.Append("    (select id_genero, id_" + dimension + ", sum(acciones) as acciones");
        str.Append("    from cubo_conavi_bak");
        str.Append("    where anio = " + anio + " and id_genero = " + 2);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by id_" + dimension + ") t");
        str.Append(" right join c_" + dimension + " s on s.id = id_" + dimension);
        str.Append(" join c_genero e on e.id = COALESCE(id_genero, " + 2 + ")");
        str.Append(" where s.id != 0");
        str.Append(" group by s.id, acciones");
        List<Data> serieHombre = new List<Data>();
        List<Data> serieMujer = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieHombre = (from DataRow row in dt.Rows
                             where row["genero"].ToString() == hombre
                             select new Data()
                             {
                                 value = float.Parse(row["porcentaje"].ToString()),
                                 name = row[dimension].ToString()
                             }).ToList();
            serieMujer = (from DataRow row in dt.Rows
                           where row["genero"].ToString() == mujer
                           select new Data()
                           {
                               value = float.Parse(row["porcentaje"].ToString()),
                               name = row[dimension].ToString()
                           }).ToList();
            var lstXaxis = new HashSet<string>(serieHombre.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(serieMujer.Select(x => x.name).ToList<string>());
            opt.xAxis = lstXaxis.ToList<string>();
            Serie serie0 = new Serie(hombre, serieHombre);
            Serie serie1 = new Serie(mujer, serieMujer);
            opt.series.Add(serie0);
            opt.series.Add(serie1);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getProgramaPresupuestal(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select COALESCE(p.descripcion, 'No distribuido') as programa_presupuestal, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi_bak");
        str.Append(" join c_programa_presupuestal p");
        str.Append(" on p.id=id_programa_presupuestal");
        str.Append(" where anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by programa_presupuestal");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = float.Parse(row[metrica].ToString()),
                       name = row["programa_presupuestal"].ToString()
                   }).ToList();
            opt.legend = lst.Select(x => x.name).ToList<string>();
            Serie serie = new Serie("programa_presupuestal", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getLineaApoyo(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select COALESCE(l.descripcion, 'No distribuido') as linea_apoyo, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi_bak");
        str.Append(" join c_linea_apoyo_presidencia l");
        str.Append(" on l.id=id_linea_apoyo");
        str.Append(" where anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by linea_apoyo;");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = float.Parse(row[metrica].ToString()),
                       name = row["linea_apoyo"].ToString()
                   }).ToList();
            opt.legend = lst.Select(x => x.name).ToList<string>();
            Serie serie = new Serie("linea_apoyo", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    #endregion

    #region METAS

    public DataTable seleccionarMeta(int anio)
    {
        StringBuilder query = new StringBuilder();
        query.Append("SELECT t.estado, ");
        query.Append("SUM(CASE WHEN t.mes = 'ene' THEN t.acciones ELSE 0 END) AS eneAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'feb' THEN t.acciones ELSE 0 END) AS febAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'mar' THEN t.acciones ELSE 0 END) AS marAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'abr' THEN t.acciones ELSE 0 END) AS abrAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'may' THEN t.acciones ELSE 0 END) AS mayAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'jun' THEN t.acciones ELSE 0 END) AS junAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'jul' THEN t.acciones ELSE 0 END) AS julAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'ago' THEN t.acciones ELSE 0 END) AS agoAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'sep' THEN t.acciones ELSE 0 END) AS sepAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'oct' THEN t.acciones ELSE 0 END) AS octAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'nov' THEN t.acciones ELSE 0 END) AS novAcciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'dic' THEN t.acciones ELSE 0 END) AS dicAcciones, ");
        query.Append("t.total_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'ene' THEN t.avance_acciones ELSE 0 END) AS ene_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'feb' THEN t.avance_acciones ELSE 0 END) AS feb_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'mar' THEN t.avance_acciones ELSE 0 END) AS mar_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'abr' THEN t.avance_acciones ELSE 0 END) AS abr_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'may' THEN t.avance_acciones ELSE 0 END) AS may_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'jun' THEN t.avance_acciones ELSE 0 END) AS jun_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'jul' THEN t.avance_acciones ELSE 0 END) AS jul_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'ago' THEN t.avance_acciones ELSE 0 END) AS ago_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'sep' THEN t.avance_acciones ELSE 0 END) AS sep_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'oct' THEN t.avance_acciones ELSE 0 END) AS oct_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'nov' THEN t.avance_acciones ELSE 0 END) AS nov_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'dic' THEN t.avance_acciones ELSE 0 END) AS dic_acciones, ");
        query.Append("ROUND(100 - (SUM(CASE WHEN t.mes = 'ene' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'feb' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'mar' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'abr' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'may' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'jun' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'jul' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'ago' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'sep' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'oct' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'nov' THEN t.avance_acciones ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'dic' THEN t.avance_acciones ELSE 0 END)), 2) AS restante_acciones, ");
        query.Append("SUM(CASE WHEN t.mes = 'ene' THEN t.monto ELSE 0 END) AS eneMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'feb' THEN t.monto ELSE 0 END) AS febMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'mar' THEN t.monto ELSE 0 END) AS marMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'abr' THEN t.monto ELSE 0 END) AS abrMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'may' THEN t.monto ELSE 0 END) AS mayMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'jun' THEN t.monto ELSE 0 END) AS junMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'jul' THEN t.monto ELSE 0 END) AS julMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'ago' THEN t.monto ELSE 0 END) AS agoMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'sep' THEN t.monto ELSE 0 END) AS sepMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'oct' THEN t.monto ELSE 0 END) AS octMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'nov' THEN t.monto ELSE 0 END) AS novMonto, ");
        query.Append("SUM(CASE WHEN t.mes = 'dic' THEN t.monto ELSE 0 END) AS dicMonto, ");
        query.Append("t.total_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'ene' THEN t.avance_monto ELSE 0 END) AS ene_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'feb' THEN t.avance_monto ELSE 0 END) AS feb_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'mar' THEN t.avance_monto ELSE 0 END) AS mar_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'abr' THEN t.avance_monto ELSE 0 END) AS abr_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'may' THEN t.avance_monto ELSE 0 END) AS may_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'jun' THEN t.avance_monto ELSE 0 END) AS jun_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'jul' THEN t.avance_monto ELSE 0 END) AS jul_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'ago' THEN t.avance_monto ELSE 0 END) AS ago_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'sep' THEN t.avance_monto ELSE 0 END) AS sep_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'oct' THEN t.avance_monto ELSE 0 END) AS oct_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'nov' THEN t.avance_monto ELSE 0 END) AS nov_monto, ");
        query.Append("SUM(CASE WHEN t.mes = 'dic' THEN t.avance_monto ELSE 0 END) AS dic_monto, ");
        query.Append("ROUND(100 - (SUM(CASE WHEN t.mes = 'ene' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'feb' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'mar' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'abr' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'may' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'jun' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'jul' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'ago' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'sep' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'oct' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'nov' THEN t.avance_monto ELSE 0 END) + ");
        query.Append("SUM(CASE WHEN t.mes = 'dic' THEN t.avance_monto ELSE 0 END)), 2) AS restante_monto ");
        query.Append("FROM (SELECT ");
        query.Append("e.clave AS clave_estado, ");
        query.Append("e.abreviacion AS estado, ");
        query.Append("m.abreviatura AS mes, ");
        query.Append("SUM(c.acciones) AS acciones, ");
        query.Append("SUM(c.monto) AS monto, ");
        query.Append("ROUND((SUM(c.acciones) * 100) / mt.acciones, 2) AS avance_acciones, ");
        query.Append("ROUND((SUM(c.monto) * 100) / mt.monto, 2) AS avance_monto, ");
        query.Append("mt.acciones AS total_acciones, ");
        query.Append("mt.monto AS total_monto ");
        query.Append("FROM (SELECT clave_estado, mes, SUM(acciones) AS acciones, SUM(monto) AS monto ");
        query.Append("FROM cubo_conavi_bak ");
        query.Append("WHERE anio = " + anio + " ");
        query.Append("GROUP BY clave_estado , mes ) c ");
        query.Append("JOIN c_entidad_federativa e ON e.clave = c.clave_estado ");
        query.Append("JOIN c_mes m ON m.id = c.mes ");
        query.Append("JOIN meta mt ON mt.clave = '06100' AND mt.anio = " + anio + " AND mt.clave_entidad_federativa = c.clave_estado ");
        query.Append("GROUP BY e.clave, e.abreviacion, m.abreviatura, mt.acciones, mt.monto) t ");
        query.Append("GROUP BY t.estado, total_acciones, total_monto ");
        DataTable dt = new DataTable();

        try { dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV); }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }

    public List<CatalogoVO> seleccionarAnioMeta()
    {
        string str = "select distinct anio from meta where clave = '06100' order by anio desc";
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

    #endregion
}