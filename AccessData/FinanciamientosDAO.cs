using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de FinanciamientosDAO
/// </summary>
public class FinanciamientosDAO
{
    private static FinanciamientosDAO _instancia = null;

    public static FinanciamientosDAO instancia()
    {
        return _instancia == null ? new FinanciamientosDAO() : _instancia;
    }

    public FinanciamientosDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region DASHBOARD
    public List<FinanciamientosVO> getKPIs()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select m.descripcion as modalidad, o.siglas as organismo, acciones, round(monto) as monto ");
        str.Append("from (select id_modalidad, clave_organismo, sum(acciones) as acciones, sum(monto) as monto ");
        str.Append("from cubo_financiamientos where anio = (select anio from c_periodo_financiamientos where actual) ");
        str.Append("group by id_modalidad, clave_organismo) f ");
        str.Append("join c_modalidad_sniiv m on f.id_modalidad = m.id ");
        str.Append("join c_organismo o on f.clave_organismo = o.clave");
        List<FinanciamientosVO> KPIs = new List<FinanciamientosVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new FinanciamientosVO()
                    {
                        modalidad = row["modalidad"].ToString(),
                        organismo = row["organismo"].ToString(),
                        acciones = UInt32.Parse(row["acciones"].ToString()),
                        monto = decimal.Parse(row["monto"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    public List<FinanciamientosVO> getKPIs2()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select e.descripcion as estado, o.siglas as organismo, ");
        str.Append("tc.descripcion as tipo_credito, m.descripcion as modalidad, ");
        str.Append("g.descripcion as genero, re.descripcion as rango_edad, rs.descripcion as rango_salarial, ");
        str.Append("round(monto) as monto, acciones from cubo_financiamientos_rpt t ");
        str.Append("join c_entidad_federativa e on e.clave = t.clave_estado ");
        str.Append("join c_organismo o on o.clave = t.clave_organismo ");
        str.Append("join c_tipo_credito tc on tc.id = t.id_tipo_credito ");
        str.Append("join c_modalidad_sniiv m on m.id = tc.id_modalidad ");
        str.Append("join c_genero g on g.id = t.id_genero ");
        str.Append("join c_rango_edad re on re.id = t.id_rango_edad ");
        str.Append("join c_rango_salarial rs on rs.id = t.id_rango_salarial");
        List<FinanciamientosVO> KPIs = new List<FinanciamientosVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new FinanciamientosVO()
                    {
                        estado = row["estado"].ToString(),
                        organismo = row["organismo"].ToString(),
                        tipo_credito = row["tipo_credito"].ToString(),
                        modalidad = row["modalidad"].ToString(),
                        sexo = row["genero"].ToString(),
                        grupo_edad = row["rango_edad"].ToString(),
                        rango_salarial = row["rango_salarial"].ToString(),
                        acciones = UInt32.Parse(row["acciones"].ToString()),
                        monto = decimal.Parse(row["monto"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    //Semanal
    public List<SemanalVO> getKPIsSemanalFinanciamientos(int id_region)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select e.descripcion as estado, o.siglas as organismo, acciones, monto as monto ");
        str.Append("from( ");
        str.Append("select clave_estado, clave_organismo, sum(acciones) as acciones, sum(monto) as monto ");
        str.Append("from cubo_semanal ");
        str.Append("where anio = (select max(anio) from cubo_semanal)");
        if (id_region != 0)
            str.Append(" and id_region = " + id_region);
        str.Append(" group by clave_estado, clave_organismo ");
        str.Append(") f ");
        str.Append("join c_entidad_federativa e on e.clave = f.clave_estado ");
        str.Append("join c_organismo o on o.clave = f.clave_organismo");
        List<SemanalVO> KPIs = new List<SemanalVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new SemanalVO()
                    {
                        estado = row["estado"].ToString(),
                        organismo = row["organismo"].ToString(),
                        acciones = UInt32.Parse(row["acciones"].ToString()),
                        monto = decimal.Parse(row["monto"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }
    public List<SemanalVO> getKPIsSemanalHipotecario(int id_region)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select e.descripcion as estado, o.siglas as organismo, m.descripcion as modalidad, acciones, monto as monto ");
        str.Append("from ( ");
        str.Append("select clave_estado, clave_organismo, id_modalidad, sum(acciones) as acciones, sum(monto) as monto ");
        str.Append("from cubo_semanal ");
        str.Append("where clave_organismo != '06610' and anio = (select max(anio) from cubo_semanal)");
        if (id_region != 0)
            str.Append(" and id_region = " + id_region);
        str.Append(" group by clave_estado, clave_organismo, id_modalidad ");
        str.Append(") f ");
        str.Append("join c_entidad_federativa e on e.clave = f.clave_estado ");
        str.Append("join c_organismo o on o.clave = f.clave_organismo ");
        str.Append("join c_modalidad_sniiv m on m.id = f.id_modalidad");
        List<SemanalVO> KPIs = new List<SemanalVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new SemanalVO()
                    {
                        estado = row["estado"].ToString(),
                        organismo = row["organismo"].ToString(),
                        modalidad = row["modalidad"].ToString(),
                        acciones = UInt32.Parse(row["acciones"].ToString()),
                        monto = decimal.Parse(row["monto"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    public string getSemanaMinMax(int anio)
    {
        string str = "select concat(min(semana), ',', max(semana)) as semanas from cubo_semanal where anio = " + anio;
        string semanas = string.Empty;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            semanas = dt.Rows[0][0].ToString();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return semanas;
    }
    #endregion

    #region CUBO
    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio from c_periodo_financiamientos order by anio desc";
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
        //string str = "select TO_DATE(concat(anio, TO_CHAR(mes,'fm00'), '01'), 'YYYYMMDD') as fecha from c_periodo_financiamientos where actual";
        string endMonth = "SELECT (date_trunc('month',concat(anio,'-',TO_CHAR(mes,'fm00'),'-', '01')::date)+ interval '1 month' - interval '1 day')::date as fecha from c_periodo_financiamientos where actual";
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
        string query = "SELECT mes from c_periodo_financiamientos where actual";
        int mes =  0;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(query, Constante.BD_SNIIV);
            mes = (from DataRow row in dt.Rows select (int)row["mes"]).ToList<int>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return mes;
    }
    public string[] crearConsulta(string parametro) {
        string[] lst = new string[3];
        switch (parametro) {
            case "anio":
                lst[0] = "|anio as año";
                lst[1] = "|anio";
                lst[2] = "|";
                break;
            case "destino_credito":
                lst[0] = "|dc.descripcion as destino_credito";
                lst[1] = "|id_destino_credito";
                lst[2] = "|join c_destino_credito dc on f.id_destino_credito = dc.id";
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
            case "grupo_organismo":
                lst[0] = "|go.descripcion as grupo_organismo";
                lst[1] = "|id_grupo_organismo";
                lst[2] = "|join c_grupo_organismo go on f.id_grupo_organismo = go.id";
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
            case "organismo":
                lst[0] = "|o.siglas as organismo";
                lst[1] = "|clave_organismo";
                lst[2] = "|join c_organismo o on f.clave_organismo = o.clave";
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
            case "tipo_credito":
                lst[0] = "|tc.descripcion as tipo_credito";
                lst[1] = "|id_tipo_credito";
                lst[2] = "|join c_tipo_credito tc on f.id_tipo_credito = tc.id";
                break;
            case "valor_vivienda":
                lst[0] = "|vv.descripcion as valor_vivienda";
                lst[1] = "|id_valor_vivienda";
                lst[2] = "|join c_valor_vivienda vv on f.id_valor_vivienda = vv.id";
                break;
            case "vivienda_sustentable":
                lst[0] = "|vs.descripcion as vivienda_sustentable";
                lst[1] = "|id_vivienda_sustentable";
                lst[2] = "|join c_vivienda_sustentable vs on f.id_vivienda_sustentable = vs.id";
                break;
            default:
                lst[0] = "|COALESCE(mu.ambito, 'No distribuido') as zona";
                lst[1] = "|clave_estado|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                break;
        }
        return lst;
    }
    public string limpiarConsulta(string cadena, string separador) {
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
    public List<FinanciamientosVO> getCubo(string anios, string clave_estado, string clave_municipio, string dimensiones)
    {
        string anio_inicio = anios.Split(',').First();
        string anio_fin = anios.Split(',').Last();

        string[] lstDimensiones = dimensiones.Split(',');
        string[] lst = new string[3];
        
        StringBuilder field = new StringBuilder();
        StringBuilder subField = new StringBuilder();
        StringBuilder table = new StringBuilder();
        foreach (string dimension in lstDimensiones) {
            lst = crearConsulta(dimension);
            field.Append(lst[0]);
            subField.Append(lst[1]);
            table.Append(lst[2]);
        }
        string strField = limpiarConsulta(field.ToString(), ",");
        string strSubField = limpiarConsulta(subField.ToString(), ",");
        string strTable = limpiarConsulta(table.ToString(), " ");

        List<FinanciamientosVO> cubo = new List<FinanciamientosVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",acciones,monto");
        query.Append(" from (select ");
        query.Append(strSubField);
        query.Append(",sum(acciones) as acciones,sum(monto) as monto");
        query.Append(" from cubo_financiamientos ");
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
        System.Diagnostics.Debug.WriteLine(query.ToString());
        try
        {
            DataTable dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV);
            cubo = Util.instancia().ConvertDataTable<FinanciamientosVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }

    //Semanal
    public List<CatalogoVO> seleccionarAnioSemanal()
    {
        string str = "select distinct EXTRACT(YEAR FROM fecha) as anio from c_periodo_semanal order by anio desc";
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
    public DateTime seleccionarFechaSemanal()
    {
        string str = "select fecha from c_periodo_semanal where actual";

        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            fecha = (from DataRow row in dt.Rows select (DateTime)row["fecha"]).ToList<DateTime>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return fecha;
    }
    public List<SemanalVO> getCubo(string anios, string clave_estado, string dimensiones)
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
            lst = crearConsulta2(dimension);
            field.Append(lst[0]);
            subField.Append(lst[1]);
            table.Append(lst[2]);
        }
        string strField = limpiarConsulta(field.ToString(), ",");
        string strSubField = limpiarConsulta(subField.ToString(), ",");
        string strTable = limpiarConsulta(table.ToString(), " ");

        List<SemanalVO> cubo = new List<SemanalVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",acciones,monto");
        query.Append(" from (select ");
        query.Append(strSubField);
        query.Append(",sum(acciones) as acciones, sum(monto) as monto");
        query.Append(" from cubo_semanal ");
        if (anio_inicio.Equals(anio_fin))
            query.Append("where anio = " + anio_inicio);
        else
            query.Append("where anio between " + anio_inicio + " and " + anio_fin);
        if (isEstatal(clave_estado)) {
            string cvl_estado = clave_estado.Equals("-1") ? Constante.FORMATO_ESTATAL : clave_estado;
            query.Append(" and clave_estado = '" + cvl_estado + "'");
        }
        query.Append(" group by ");
        query.Append(strSubField);
        query.Append(") f ");
        query.Append(strTable);
        try
        {
            DataTable dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV);
            cubo = Util.instancia().ConvertDataTable<SemanalVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }
    public string[] crearConsulta2(string parametro)
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
                lst[1] = "|clave_estado";
                lst[2] = "|join c_entidad_federativa e on f.clave_estado = e.clave";
                break;
            case "modalidad":
                lst[0] = "|mo.descripcion as modalidad";
                lst[1] = "|id_modalidad";
                lst[2] = "|join c_modalidad_semanal mo on f.id_modalidad = mo.id";
                break;
            case "organismo":
                lst[0] = "|o.siglas as organismo";
                lst[1] = "|clave_organismo";
                lst[2] = "|join c_organismo o on f.clave_organismo = o.clave";
                break;
            /*
            case "subprograma":
                lst[0] = "|tc.descripcion as subprograma";
                lst[1] = "|id_subprograma";
                lst[2] = "|join c_tipo_credito tc on f.id_subprograma = tc.id";
                break;
            */
            case "region":
                lst[0] = "|r.descripcion as region";
                lst[1] = "|id_region";
                lst[2] = "|join c_region r on f.id_region = r.id";
                break;
            case "tipo_modalidad":
                lst[0] = "|tm.descripcion as tipo_modalidad";
                lst[1] = "|id_tipo_modalidad";
                lst[2] = "|join c_tipo_modalidad tm on f.id_tipo_modalidad = tm.id";
                break;
            default:
                lst[0] = "|semana";
                lst[1] = "|semana";
                lst[2] = "|";
                break;
        }
        return lst;
    }
    #endregion

    #region TEMÁTICO
    public Option getMes(string clave_estado, int anio, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        opt.legend = new List<string> { anioAnterior.ToString(), anio.ToString() };
        StringBuilder str = new StringBuilder();
        str.Append("select COALESCE(c.anio, " + anioAnterior + ") as anio, m.descripcion as mes, COALESCE(c." + metrica + ", 0) as " + metrica);
        str.Append(" from (select anio, mes, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos");
        str.Append(" where anio = " + anioAnterior);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, mes) c");
        str.Append(" right join c_mes m on c.mes = m.id");
        str.Append(" union");
        str.Append(" select COALESCE(c.anio, " + anio + ") as anio, m.descripcion as mes, COALESCE(c." + metrica + ", 0) as " + metrica + "");
        str.Append(" from (select anio, mes, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos");
        str.Append(" where anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, mes) c");
        str.Append(" right join c_mes m on c.mes = m.id");
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
    public Option getOrganismo(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        opt.legend = new List<string> { anio.ToString() };
        StringBuilder str = new StringBuilder();
        str.Append("select o.siglas as organismo,sum(" + metrica+") "+metrica);
        str.Append(" from cubo_financiamientos f");
        str.Append(" join c_organismo o on f.clave_organismo = o.clave");
        str.Append(" where anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by clave_organismo");
        str.Append(" order by "+metrica+" desc");
        str.Append(" limit 7;");
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["organismo"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.xAxis = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getModalidad(string clave_estado, int anio, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select m.descripcion as modalidad, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos");
        str.Append(" join c_modalidad_sniiv m on id_modalidad = m.id");
        str.Append(" where anio = " + anio + " and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by id_modalidad;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["modalidad"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getGrupoOrganismo(string clave_estado, int anio, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select go.descripcion as grupo_organismo, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos f");
        str.Append(" join c_grupo_organismo go on f.id_grupo_organismo = go.id");
        str.Append(" where anio = " + anio + " and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by id_grupo_organismo;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["grupo_organismo"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getRangoEdad(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select re.descripcion as rango_edad, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos f");
        str.Append(" join c_rango_edad re on f.id_rango_edad = re.id");
        str.Append(" where anio = " + anio + " and id_rango_edad!=0 and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by id_rango_edad;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["rango_edad"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getRangoSalarial(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select rs.descripcion as rango_salarial, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos f");
        str.Append(" join c_rango_salarial rs on f.id_rango_salarial = rs.id");
        str.Append(" where anio = " + anio + " and id_rango_salarial!=0 and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by id_rango_salarial;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["rango_salarial"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getValorVivienda(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select vv.descripcion as valor_vivienda, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos f");
        str.Append(" join c_valor_vivienda vv on f.id_valor_vivienda = vv.id");
        str.Append(" where anio = " + anio + " and id_valor_vivienda!=0 and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by id_valor_vivienda;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["valor_vivienda"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getPoblacionIndigena(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select COALESCE(mu.poblacion_indigena, 'No distribuido') as poblacion_indigena, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos f");
        str.Append(" join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave");
        str.Append(" where anio = " + anio + " and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by poblacion_indigena;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["poblacion_indigena"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getGenero(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select g.descripcion as genero, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos f");
        str.Append(" join c_genero g on f.id_genero = g.id");
        str.Append(" where anio = " + anio + " and id_genero!=0 and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by id_genero;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["genero"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getZona(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select COALESCE(mu.ambito, 'No distribuido') as zona, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos f");
        str.Append(" join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave");
        str.Append(" where anio = " + anio + " and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by zona;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["zona"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getTipoCredito(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select tc.descripcion tipo_credito, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos f");
        str.Append(" join c_tipo_credito tc on f.id_tipo_credito = tc.id");
        str.Append(" where anio = " + anio + " and id_tipo_credito!=0 and " + metrica + " != 0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by tipo_credito;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["tipo_credito"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getOrganismoTipoCredito(string clave_estado,int anio,string metrica)
    {
        string[] legends = { "Cofinanciamientos y subsidios", "Credito individual" };
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select o.siglas as organismo,'Cofinanciamientos y subsidios' tipo_credito," + metrica);
        str.Append(" from (select clave_organismo,sum(" + metrica + ") "+metrica);
        str.Append(" 	from cubo_financiamientos");
        str.Append(" 	where anio=" + anio + " and (id_tipo_credito=1 or id_tipo_credito=3 or id_tipo_credito=5)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append(" 	group by clave_organismo) f");
        str.Append(" join c_organismo o on f.clave_organismo = o.clave");
        str.Append(" union");
        str.Append(" select o.siglas as organismo,'Credito individual' tipo_credito," + metrica);
        str.Append(" from (select clave_organismo,sum(" + metrica + ") "+metrica);
        str.Append(" 	from cubo_financiamientos");
        str.Append(" 	where anio=" + anio + " and (id_tipo_credito=2 or id_tipo_credito=4 or id_tipo_credito=6 or id_tipo_credito=7)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append(" 	group by clave_organismo) f");
        str.Append(" join c_organismo o on f.clave_organismo = o.clave;");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["tipo_credito"].ToString() == legends[0]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["organismo"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["tipo_credito"].ToString() == legends[1]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["organismo"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            var lstXaxis = new HashSet<string>(data0.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data1.Select(x => x.name).ToList<string>());
            opt.xAxis = lstXaxis.ToList<string>();
            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getModalidadTipoCredito(string clave_estado, int anio, string metrica)
    {
        string[] legends = { "Cofinanciamientos y subsidios", "Credito individual" };
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        /*
        str.Append(" select mo.descripcion as modalidad,'Cofinanciamientos y subsidios' tipo_credito," + metrica);
        str.Append(" from (select id_modalidad,sum(" + metrica + ") " + metrica);
        str.Append(" 	from cubo_financiamientos");
        str.Append(" 	where anio=" + anio + " and (id_tipo_credito=1 or id_tipo_credito=3 or id_tipo_credito=5)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append(" 	group by id_modalidad) f");
        str.Append(" join c_modalidad_sniiv mo on f.id_modalidad = mo.id");
        str.Append(" union");
        str.Append(" select mo.descripcion as modalidad,'Credito individual' tipo_credito," + metrica);
        str.Append(" from (select id_modalidad,sum(" + metrica + ") " + metrica);
        str.Append(" 	from cubo_financiamientos");
        str.Append(" 	where anio=" + anio + " and (id_tipo_credito=2 or id_tipo_credito=4 or id_tipo_credito=6 or id_tipo_credito=7)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append(" 	group by id_modalidad) f");
        str.Append(" join c_modalidad_sniiv mo on f.id_modalidad = mo.id;");
        */
        str.Append("select m.descripcion as modalidad, t.descripcion as tipo_credito, " + metrica);
        str.Append(" from (select id_modalidad, id_tipo_credito, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_financiamientos");
        str.Append(" where anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append(" group by id_modalidad, id_tipo_credito) f");
        str.Append(" join c_modalidad_sniiv m on f.id_modalidad = m.id");
        str.Append(" join c_tipo_credito t on f.id_tipo_credito = t.id");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["tipo_credito"].ToString() == legends[0]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["tipo_credito"].ToString() == legends[1]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            var lstXaxis = new HashSet<string>(data0.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data1.Select(x => x.name).ToList<string>());
            opt.xAxis = lstXaxis.ToList<string>();
            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getDestinoCredito(string clave_estado, int anio, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select dc.descripcion as destino_credito,"+metrica);
        str.Append(" from (select id_destino_credito, sum(" + metrica + ") as " + metrica);
        str.Append("    from cubo_financiamientos");
        str.Append("     where anio="+anio+" and id_destino_credito in (1,2,4,5,6)");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_destino_credito) f");
        str.Append(" join c_destino_credito dc on f.id_destino_credito = dc.id");
        str.Append(" union");
        str.Append(" select 'Otros' destino_credito,sum("+ metrica +") "+ metrica);
        str.Append(" from cubo_financiamientos");
        str.Append(" where anio = " + anio + " and id_destino_credito not in (1,2,4,5,6)");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieActual = (from DataRow row in dt.Rows
                           select new Data()
                           {
                               value = float.Parse(row[metrica].ToString()),
                               name = row["destino_credito"].ToString()
                           }).ToList();
            var lstLegend = new HashSet<string>(serieActual.Select(x => x.name).ToList<string>());
            opt.legend = lstLegend.ToList<string>();
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getModalidadDestinoCredito(string clave_estado, int anio, string metrica)
    {
        string[] legends = { "Vivienda nueva", "Vivienda existente", "En arrendamiento", "Autoproducción", "Con disponibilidad de terreno", "Mejoramientos", "Pago de pasivos", "Liquidez", "Adquisición de suelo", "Urbanización para uso habitacional", "Lotes con servicios", "Insumos para vivienda", "Reconstrucción", "Garantias", "Programas institucionales", "Contragarantías", "No especificado"};
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select 'Viviendas nuevas' modalidad,dc.descripcion destino_credito,COALESCE("+ metrica +",0) " + metrica);
        str.Append(" from (select 'nueva',id_destino_credito,sum("+ metrica +") "+ metrica);
        str.Append("    from cubo_financiamientos f");
        str.Append("    where anio="+ anio +" and id_modalidad=1");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by id_modalidad,id_destino_credito) f");
        str.Append(" right join c_destino_credito dc on f.id_destino_credito = dc.id");
        str.Append(" union ");
        str.Append(" select 'Viviendas existentes' modalidad,dc.descripcion destino_credito,COALESCE(" + metrica + ",0) " + metrica);
        str.Append(" from (select 'existente',id_destino_credito,sum(" + metrica + ") " + metrica);
        str.Append("    from cubo_financiamientos f");
        str.Append("    where anio=" + anio + " and id_modalidad=2");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by id_modalidad,id_destino_credito) f");
        str.Append(" right join c_destino_credito dc on f.id_destino_credito = dc.id");
        str.Append(" union ");
        str.Append(" select 'Mejoramientos' modalidad,dc.descripcion destino_credito,COALESCE(" + metrica + ",0) " + metrica);
        str.Append(" from (select 'mejoramientos',id_destino_credito,sum(" + metrica + ") " + metrica);
        str.Append("    from cubo_financiamientos f");
        str.Append("    where anio=" + anio + " and id_modalidad=3");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by id_modalidad,id_destino_credito) f");
        str.Append(" right join c_destino_credito dc on f.id_destino_credito = dc.id");
        str.Append(" union ");
        str.Append(" select 'Otros programas' modalidad,dc.descripcion destino_credito,COALESCE(" + metrica + ",0) " + metrica);
        str.Append(" from (select 'otros',id_destino_credito,sum(" + metrica + ") " + metrica);
        str.Append("    from cubo_financiamientos f");
        str.Append("    where anio=" + anio + " and id_modalidad= 4");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by id_modalidad,id_destino_credito) f");
        str.Append(" right join c_destino_credito dc on f.id_destino_credito = dc.id;");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        List<Data> data2 = new List<Data>();
        List<Data> data3 = new List<Data>();
        List<Data> data4 = new List<Data>();
        List<Data> data5 = new List<Data>();
        List<Data> data6 = new List<Data>();
        List<Data> data7 = new List<Data>();
        List<Data> data8 = new List<Data>();
        List<Data> data9 = new List<Data>();
        List<Data> data10 = new List<Data>();
        List<Data> data11 = new List<Data>();
        List<Data> data12 = new List<Data>();
        List<Data> data13 = new List<Data>();
        List<Data> data14 = new List<Data>();
        List<Data> data15 = new List<Data>();
        List<Data> data16 = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[0]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[1]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            data2 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[2]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie2 = new Serie(legends[2], data2, type, type);
            data3 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[3]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie3 = new Serie(legends[3], data3, type, type);
            data4 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[4]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie4 = new Serie(legends[4], data4, type, type);
            data5 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[5]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie5 = new Serie(legends[5], data5, type, type);
            data6 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[6]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie6 = new Serie(legends[6], data6, type, type);
            data7 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[7]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie7 = new Serie(legends[7], data7, type, type);
            data8 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[8]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie8 = new Serie(legends[8], data8, type, type);
            data9 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[9]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie9 = new Serie(legends[9], data9, type, type);
            data10 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[10]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie10 = new Serie(legends[10], data10, type, type);
            data11 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[11]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie11 = new Serie(legends[11], data11, type, type);
            data12 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[12]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie12 = new Serie(legends[12], data12, type, type);
            data13 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[13]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie13 = new Serie(legends[13], data13, type, type);
            data14 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[14]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie14 = new Serie(legends[14], data14, type, type);
            data15 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[15]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie15 = new Serie(legends[15], data15, type, type);
            data16 = (from DataRow row in dt.Rows
                     where row["destino_credito"].ToString() == legends[16]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["modalidad"].ToString(),
                     }).ToList();
            Serie serie16 = new Serie(legends[16], data16, type, type);
            var lstXaxis = new HashSet<string>(data0.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data1.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data2.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data3.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data4.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data5.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data6.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data7.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data8.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data9.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data10.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data11.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data12.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data13.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data14.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data15.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data16.Select(x => x.name).ToList<string>());
            opt.xAxis = lstXaxis.ToList<string>();
            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.series.Add(serie2);
            opt.series.Add(serie3);
            opt.series.Add(serie4);
            opt.series.Add(serie5);
            opt.series.Add(serie6);
            opt.series.Add(serie7);
            opt.series.Add(serie8);
            opt.series.Add(serie9);
            opt.series.Add(serie10);
            opt.series.Add(serie11);
            opt.series.Add(serie12);
            opt.series.Add(serie13);
            opt.series.Add(serie14);
            opt.series.Add(serie15);
            opt.series.Add(serie16);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getAnioTipoCredito(string clave_estado, int anio, string metrica)
    {
        int anioInicial = anio - 5;
        string[] legends = { "Cofinanciamientos y subsidios", "Credito individual" };
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        for (int i=anioInicial; i <= anio; i++)
        {
            str.Append(" select "+ i +" anio,tc.descripcion tipo_credito,COALESCE(sum(" + metrica + "),0) " + metrica);
            str.Append(" from (select anio,id_tipo_credito,sum(" + metrica + ") " + metrica);
            str.Append(" 	from cubo_financiamientos");
            str.Append(" 	where anio = "+ i);
            if (!clave_estado.Equals("00"))
                str.Append("    and clave_estado = '" + clave_estado + "'");
            str.Append(" 	group by anio,id_tipo_credito) f");
            str.Append(" right join c_tipo_credito tc on f.id_tipo_credito = tc.id");
            str.Append(" group by tipo_credito");
            if (i < anio)
                str.Append(" union");
        }
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["tipo_credito"].ToString() == legends[0]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["anio"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["tipo_credito"].ToString() == legends[1]
                     select new Data()
                     {
                         value = float.Parse(row[metrica].ToString()),
                         name = row["anio"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            var lstXaxis = new HashSet<string>(data0.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data1.Select(x => x.name).ToList<string>());
            opt.xAxis = lstXaxis.ToList<string>();
            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    //Semanal
    public List<SemanalVO> getSemanalFinanciamientos(int id_region, string clave_estado, int anio, string semanas, string organismo)
    {
        int semana_inicio = Convert.ToInt16(semanas.Split(',').First());
        int semana_fin = Convert.ToInt16(semanas.Split(',').Last());
        int anioAnterior = anio - 1;
        StringBuilder str = new StringBuilder();
        str.Append("select anio, o.siglas as organismo, semana, acciones, monto as monto");
        str.Append(" from (");
        str.Append(" select anio, clave_organismo, semana, sum(acciones) as acciones, sum(monto) as monto");
        str.Append(" from cubo_semanal");
        str.Append(" where (anio = " + anio + " or anio = " + anioAnterior + ")");
        if (!organismo.Equals("0"))
            str.Append(" and clave_organismo = '" + organismo + "'");
        if (id_region != 0) {
            str.Append(" and id_region = " + id_region);
            if (!clave_estado.Equals("0"))
                str.Append(" and clave_estado = '" + clave_estado + "'");
        }
        str.Append(" and semana between " + semana_inicio + " and " + semana_fin);
        str.Append(" group by anio, clave_organismo, semana");
        str.Append(" ) f");
        str.Append(" join c_organismo o on o.clave = f.clave_organismo");

        List<SemanalVO> financiamientos = new List<SemanalVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            financiamientos = (from DataRow row in dt.Rows
                            select new SemanalVO()
                            {
                                año = Int32.Parse(row["anio"].ToString()),
                                organismo = row["organismo"].ToString(),
                                semana = Int32.Parse(row["semana"].ToString()),
                                acciones = Int32.Parse(row["acciones"].ToString()),
                                monto = decimal.Parse(row["monto"].ToString())
                            }).ToList();
            for (int i = semana_inicio; i <= semana_fin; i++)
            {
                financiamientos.Add(new SemanalVO() { año = anio, organismo = string.Empty, semana = i, acciones = 0, monto = 0 });
                financiamientos.Add(new SemanalVO() { año = anioAnterior, organismo = string.Empty, semana = i, acciones = 0, monto = 0 });
            }
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return financiamientos;
    }
    public List<SemanalVO> getSemanalHipotecario(int id_region, string clave_estado, int anio, string semanas, string organismo)
    {
        int semana_inicio = Convert.ToInt16(semanas.Split(',').First());
        int semana_fin = Convert.ToInt16(semanas.Split(',').Last());
        int anioAnterior = anio - 1;
        StringBuilder str = new StringBuilder();
        str.Append("select anio, o.siglas as organismo,");
        str.Append(" case when m.id != 3 then 'Créditos hipotecarios' else m.descripcion end as modalidad,");
        str.Append(" semana, acciones, monto as monto");
        str.Append(" from (");
        str.Append(" select anio, clave_organismo, id_modalidad, semana, sum(acciones) as acciones, sum(monto) as monto");
        str.Append(" from cubo_semanal");
        str.Append(" where (anio = " + anio + " or anio = " + anioAnterior + ")");
        if (!organismo.Equals("0"))
            str.Append(" and clave_organismo = '" + organismo + "'");
        if (id_region != 0)
        {
            str.Append(" and id_region = " + id_region);
            if (!clave_estado.Equals("0"))
                str.Append(" and clave_estado = '" + clave_estado + "'");
        }
        str.Append(" and clave_organismo != '06610'");
        str.Append(" and semana between " + semana_inicio + " and " + semana_fin);
        str.Append(" group by anio, clave_organismo, id_modalidad, semana");
        str.Append(" ) f");
        str.Append(" join c_organismo o on o.clave = f.clave_organismo");
        str.Append(" join c_modalidad_sniiv m on m.id = f.id_modalidad");
        List<SemanalVO> financiamientos = new List<SemanalVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            financiamientos = (from DataRow row in dt.Rows
                               select new SemanalVO()
                               {
                                   año = Int32.Parse(row["anio"].ToString()),
                                   organismo = row["organismo"].ToString(),
                                   modalidad = row["modalidad"].ToString(),
                                   semana = Int32.Parse(row["semana"].ToString()),
                                   acciones = Int32.Parse(row["acciones"].ToString()),
                                   monto = decimal.Parse(row["monto"].ToString())
                               }).ToList();
            for (int i = semana_inicio; i <= semana_fin; i++)
            {
                financiamientos.Add(new SemanalVO() { año = anio, organismo = string.Empty, semana = i, acciones = 0, monto = 0 });
                financiamientos.Add(new SemanalVO() { año = anioAnterior, organismo = string.Empty, semana = i, acciones = 0, monto = 0 });
            }
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return financiamientos;
    }
    #endregion
}