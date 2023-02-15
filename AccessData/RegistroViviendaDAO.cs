using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de RegistroViviendaDAO
/// </summary>
public class RegistroViviendaDAO
{
    private static RegistroViviendaDAO _instancia = null;

    public static RegistroViviendaDAO instancia()
    {
        return _instancia == null ? new RegistroViviendaDAO() : _instancia;
    }

    public RegistroViviendaDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    #region DASHBOARD

    public List<RegistroViviendaVO> getKPIs()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select tv.descripcion as tipo_vivienda, p.descripcion as pcu, vsm.descripcion as segmento, viviendas ");
        str.Append("from (select id_tipo_vivienda, id_pcu, id_segmento, sum(viviendas) as viviendas ");
        str.Append("from cubo_registro_vivienda_bak ");
        str.Append("where anio = (select anio from c_periodo_registro_vivienda where actual) ");
        str.Append("group by id_tipo_vivienda, id_pcu, id_segmento) t ");
        str.Append("join c_tipo_vivienda tv on t.id_tipo_vivienda = tv.id ");
        str.Append("join c_pcu p on t.id_pcu = p.id ");
        str.Append("join c_valor_vivienda_vsm vsm on t.id_segmento = vsm.id");
        List <RegistroViviendaVO> KPIs = new List<RegistroViviendaVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new RegistroViviendaVO()
                    {
                        pcu = row["pcu"].ToString(),
                        tipo_vivienda = row["tipo_vivienda"].ToString(),
                        segmento = row["segmento"].ToString(),
                        viviendas = UInt32.Parse(row["viviendas"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    #endregion

    public DateTime seleccionarFecha()
    {
        //string str = "select TO_DATE(concat(anio, TO_CHAR(mes,'fm00'), '01'), 'YYYYMMDD') as fecha from c_periodo_registro_vivienda where actual";
        string endMonth = "SELECT (date_trunc('month',concat(anio,'-',TO_CHAR(mes,'fm00'),'-', '01')::date)+ interval '1 month' - interval '1 day')::date as fecha from c_periodo_registro_vivienda where actual";
        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(endMonth, Constante.BD_SNIIV);
            fecha = (from DataRow row in dt.Rows select (DateTime)row["fecha"]).ToList<DateTime>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return fecha;
    }

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct anio from c_periodo_registro_vivienda order by anio desc";
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

    public int seleccionarMes()
    {
        string query = "SELECT mes from c_periodo_registro_vivienda where actual";
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
            case "estado":
                lst[0] = "|e.descripcion as estado";
                lst[1] = "|clave_estado";
                lst[2] = "|join c_entidad_federativa e on f.clave_estado = e.clave";
                break;
            case "mes":
                lst[0] = "|m.descripcion as mes";
                lst[1] = "|mes";
                lst[2] = "|join c_mes m on f.mes = m.id";
                break;
            case "municipio":
                lst[0] = "|mu.descripcion as municipio";
                lst[1] = "|clave_estado|clave_municipio";
                lst[2] = "|join c_municipio mu on f.clave_estado = mu.clave_entidad_federativa and f.clave_municipio = mu.clave_mun";
                break;
            case "pcu":
                lst[0] = "|p.descripcion as pcu";
                lst[1] = "|id_pcu";
                lst[2] = "|join c_pcu p on f.id_pcu = p.id";
                break;
            case "segmento":
                lst[0] = "|vsm.descripcion as segmento";
                lst[1] = "|id_segmento";
                lst[2] = "|join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id";
                break;
            case "segmento_uma":
                lst[0] = "|uma.descripcion as segmento_uma";
                lst[1] = "|id_segmento_uma";
                lst[2] = "|join c_valor_vivienda_uma uma on f.id_segmento_uma = uma.id";
                break;
            case "tipo_vivienda":
                lst[0] = "|tv.descripcion as tipo_vivienda";
                lst[1] = "|id_tipo_vivienda";
                lst[2] = "|join c_tipo_vivienda tv on f.id_tipo_vivienda = tv.id";
                break;
            case "superficie":
                lst[0] = "|s.descripcion as superficie";
                lst[1] = "|id_superficie";
                lst[2] = "|join c_superficie s on f.id_superficie = s.id";
                break;
            default:
                lst[0] = "|r.descripcion as recamara";
                lst[1] = "|id_recamara";
                lst[2] = "|join c_recamara r on f.id_recamara = r.id";
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

    public List<RegistroViviendaVO> getCubo(string anios, string clave_estado, string clave_municipio, string dimensiones)
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

        List<RegistroViviendaVO> cubo = new List<RegistroViviendaVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",viviendas");
        query.Append(" from (select ");
        query.Append(strSubField);
        query.Append(",sum(viviendas) as viviendas");
        query.Append(" from cubo_registro_vivienda_bak ");
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
            cubo = Util.instancia().ConvertDataTable<RegistroViviendaVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }

    /*
    public List<RegistroViviendaVO> getCubo(string anios, string dimensiones)
    {
        string anio_inicio = anios.Split(',').First();
        string anio_fin = anios.Split(',').Last();

        StringBuilder str = new StringBuilder();
        str.Append("select anio as año," + dimensiones + ",viviendas");
        str.Append(" from cubo_registro_vivienda ");
        if (anio_inicio.Equals(anio_fin))
            str.Append(" where anio = " + anio_inicio);
        else
            str.Append(" where anio = " + anio_inicio + " or anio = " + anio_fin);
        //str.Append(" group by anio," + dimensiones);
        List<RegistroViviendaVO> cuboConavi = new List<RegistroViviendaVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            cuboConavi = Util.instancia().ConvertDataTable<RegistroViviendaVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cuboConavi;
    }
    */
    #region TEMATICO
    public List<CatalogoVO> seleccionarAnioTematico()
    {
        string str = "select distinct anio from c_periodo_registro_vivienda where anio > 2013 order by anio desc";
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
    public Option getMes(string clave_estado, int anio)
    {
        int anioInicial = anio - 2;
        int anioAnterior = anio - 1;
        Option opt = new Option();
        opt.legend = new List<string> { anioInicial.ToString(), anioAnterior.ToString(), anio.ToString() };
        StringBuilder str = new StringBuilder();
        str.Append("select COALESCE(anio,"+anioInicial+") anio,m.descripcion mes,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select anio,mes,sum(viviendas) viviendas");
        str.Append(" from cubo_registro_vivienda_bak");
        str.Append(" where anio = "+anioInicial+"");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio,mes) f");
        str.Append(" right join c_mes m on f.mes = m.id");
        str.Append(" union");
        str.Append(" select COALESCE(anio," + anioAnterior + ") anio,m.descripcion mes,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select anio,mes,sum(viviendas) viviendas");
        str.Append(" from cubo_registro_vivienda_bak");
        str.Append(" where anio = " + anioAnterior + "");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio,mes) f");
        str.Append(" right join c_mes m on f.mes = m.id");
        str.Append(" union");
        str.Append(" select COALESCE(anio," + anio + ") anio,m.descripcion mes,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select anio,mes,sum(viviendas) viviendas");
        str.Append(" from cubo_registro_vivienda_bak");
        str.Append(" where anio = " + anio + "");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio,mes) f");
        str.Append(" right join c_mes m on f.mes = m.id");
        List<Data> serieInicial = new List<Data>();
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieInicial = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioInicial.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row["viviendas"].ToString()),
                                 name = row["mes"].ToString()
                             }).ToList();
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row["viviendas"].ToString()),
                                 name = row["mes"].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row["viviendas"].ToString()),
                               name = row["mes"].ToString()
                           }).ToList();
            List<string> lstMes = new List<string>(new string[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" });
            opt.xAxis = lstMes;
            Serie serie2 = new Serie(anioInicial.ToString(), serieInicial);
            Serie serie1 = new Serie(anioAnterior.ToString(), serieAnterior);
            Serie serie0 = new Serie(anio.ToString(), serieActual);
            opt.series.Add(serie2);
            opt.series.Add(serie1);
            opt.series.Add(serie0);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getComparativoInteranual(string clave_estado, int anio)
    {
        int anioInicial = anio - 2;
        int anioAnterior = anio - 1;
        string type = "bar";
        string[] legends = { anioAnterior.ToString(), anio.ToString() };
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select anio,concat('enero a ',(select cm.descripcion from c_periodo_registro_vivienda f join c_mes cm on f.mes=cm.id where actual=1)) periodo,sum(viviendas) viviendas");
        str.Append(" from cubo_registro_vivienda_bak f");
        str.Append(" where anio between " + anioAnterior + " and " + anio + " and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append(" and f.clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio");
        str.Append(" union");
        str.Append(" select "+anioAnterior+ " anio,(select cm.descripcion from c_periodo_registro_vivienda f join c_mes cm on f.mes=cm.id where actual=1) periodo,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select mes,sum(viviendas) as viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak");
        str.Append(" 	where anio="+anioAnterior+ " and mes = (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" ) f");
        str.Append(" left join c_mes m on f.mes = m.id");
        str.Append(" union");
        str.Append(" select " + anio + " anio,(select cm.descripcion from c_periodo_registro_vivienda f join c_mes cm on f.mes=cm.id where actual=1) periodo,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select mes,sum(viviendas) as viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak");
        str.Append(" 	where anio=" + anio + " and mes = (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" ) f");
        str.Append(" left join c_mes m on f.mes = m.id");
        str.Append(" union");
        str.Append(" select "+anioAnterior+ " anio,'Últimos 12 meses' periodo,sum(viviendas) viviendas");
        str.Append(" from cubo_registro_vivienda_bak f");
        str.Append(" where ((anio = " + anioInicial + " and mes > (select mes from c_periodo_registro_vivienda where actual =1))");
        str.Append(" or (anio = " + anioAnterior + " and mes <= (select mes from c_periodo_registro_vivienda where actual =1)))");
        if (!clave_estado.Equals("00"))
            str.Append(" and f.clave_estado = '" + clave_estado + "'");
        str.Append(" union");
        str.Append(" select " + anio + " anio,'Últimos 12 meses' periodo,sum(viviendas) viviendas");
        str.Append(" from cubo_registro_vivienda_bak f");
        str.Append(" where ((anio = " + anioAnterior + " and mes > (select mes from c_periodo_registro_vivienda where actual =1))");
        str.Append(" or (anio = " + anio + " and mes <= (select mes from c_periodo_registro_vivienda where actual =1)))");
        if (!clave_estado.Equals("00"))
            str.Append(" and f.clave_estado = '" + clave_estado + "'");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["anio"].ToString() == anioAnterior.ToString()
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["periodo"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["anio"].ToString() == anio.ToString()
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["periodo"].ToString(),
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
    public Option getValorVivienda(string clave_estado, int anio)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("SELECT anio,vsm.descripcion,SUM(viviendas) AS viviendas");
        str.Append(" FROM cubo_registro_vivienda_bak f");
        str.Append(" JOIN c_valor_vivienda_vsm vsm ON f.id_segmento = vsm.id");
        str.Append(" WHERE anio BETWEEN "+anioAnterior+" AND " +anio+ " and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append(" AND clave_estado = '" + clave_estado + "'");
        str.Append(" GROUP BY anio,id_segmento;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row["viviendas"].ToString()),
                                 name = row["descripcion"].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row["viviendas"].ToString()),
                               name = row["descripcion"].ToString()
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
    public Option getSuperficie(string clave_estado, int anio)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("SELECT anio,s.descripcion AS superficie,SUM(viviendas) AS viviendas");
        str.Append(" FROM cubo_registro_vivienda_bak f");
        str.Append(" JOIN c_superficie s ON f.id_superficie = s.id");
        str.Append(" WHERE anio BETWEEN " + anioAnterior + " AND " + anio + " and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append(" AND clave_estado = '" + clave_estado + "'");
        str.Append(" GROUP BY anio,id_superficie;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row["viviendas"].ToString()),
                                 name = row["superficie"].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row["viviendas"].ToString()),
                               name = row["superficie"].ToString()
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
    public Option getTipoVivienda(string clave_estado, int anio)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("SELECT anio,tv.descripcion as tipo_vivienda,sum(viviendas) as viviendas");
        str.Append(" FROM cubo_registro_vivienda_bak f");
        str.Append(" JOIN c_tipo_vivienda tv ON f.id_tipo_vivienda = tv.id");
        str.Append(" WHERE anio BETWEEN " + anioAnterior + " AND " + anio + " and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append(" AND clave_estado = '" + clave_estado + "'");
        str.Append(" GROUP BY anio,tipo_vivienda;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row["viviendas"].ToString()),
                                 name = row["tipo_vivienda"].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row["viviendas"].ToString()),
                               name = row["tipo_vivienda"].ToString()
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
    public Option getPCU(string clave_estado, int anio)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("SELECT anio,p.descripcion AS pcu,SUM(viviendas) AS viviendas");
        str.Append(" FROM cubo_registro_vivienda_bak f");
        str.Append(" JOIN c_pcu p ON f.id_pcu = p.id");
        str.Append(" WHERE anio BETWEEN " + anioAnterior + " AND " + anio + " and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append(" AND clave_estado = '" + clave_estado + "'");
        str.Append(" GROUP BY anio,id_pcu;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row["viviendas"].ToString()),
                                 name = row["pcu"].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row["viviendas"].ToString()),
                               name = row["pcu"].ToString()
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
    public Option getPCUValorVivienda(string clave_estado, int anio)
    {
        string[] legends = { "Popular hasta 158", "Popular hasta 200", "tradicional", "Media residencial" };
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select COALESCE(pcu,'U1') as pcu,vsm.descripcion as segmento,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion as pcu,id_segmento,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu = p.id");
        str.Append("     where anio="+anio+ " and id_pcu=1 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_pcu,id_segmento) f");
        str.Append(" right join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id");
        str.Append(" union");
        str.Append(" select COALESCE(pcu,'U2') as pcu,vsm.descripcion as segmento,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion as pcu,id_segmento,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu = p.id");
        str.Append("     where anio=" + anio + " and id_pcu=2 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_pcu,id_segmento) f");
        str.Append(" right join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id");
        str.Append(" union");
        str.Append(" select COALESCE(pcu,'U3') as pcu,vsm.descripcion as segmento,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion as pcu,id_segmento,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu = p.id");
        str.Append("     where anio=" + anio + " and id_pcu=3 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_pcu,id_segmento) f");
        str.Append(" right join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id");
        str.Append(" union");
        str.Append(" select COALESCE(pcu,'FC') as pcu,vsm.descripcion as segmento,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion as pcu,id_segmento,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu = p.id");
        str.Append("     where anio=" + anio + " and id_pcu=4 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_pcu,id_segmento) f");
        str.Append(" right join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id;");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        List<Data> data2 = new List<Data>();
        List<Data> data3 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[0]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["pcu"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[1]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["pcu"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            data2 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[2]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["pcu"].ToString(),
                     }).ToList();
            Serie serie2 = new Serie(legends[2], data2, type, type);
            data3 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[3]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["pcu"].ToString(),
                     }).ToList();
            Serie serie3 = new Serie(legends[3], data3, type, type);

            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.series.Add(serie2);
            opt.series.Add(serie3);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getPCUSuperficie(string clave_estado, int anio)
    {
        string[] legends = { "Menor a 45m2", "De 45 a 60m2", "Mayor a 60m2"};
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select COALESCE(pcu,'U1') as pcu,s.descripcion as superficie,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion pcu,id_superficie,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu = p.id");
        str.Append(" 	where anio="+anio+ " and id_pcu=1 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append(" 	group by id_pcu,id_superficie) f");
        str.Append(" right join c_superficie s on f.id_superficie = s.id");
        str.Append(" union");
        str.Append(" select COALESCE(pcu,'U2') as pcu,s.descripcion as superficie,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion pcu,id_superficie,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu = p.id");
        str.Append(" 	where anio="+anio+ " and id_pcu=2 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append(" 	group by id_pcu,id_superficie) f");
        str.Append(" right join c_superficie s on f.id_superficie = s.id");
        str.Append(" union");
        str.Append(" select COALESCE(pcu,'U3') as pcu,s.descripcion as superficie,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion pcu,id_superficie,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu = p.id");
        str.Append(" 	where anio="+anio+ " and id_pcu=3 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append(" 	group by id_pcu,id_superficie) f");
        str.Append(" right join c_superficie s on f.id_superficie = s.id");
        str.Append(" union");
        str.Append(" select COALESCE(pcu,'U4') as pcu,s.descripcion as superficie,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion pcu,id_superficie,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu = p.id");
        str.Append(" 	where anio="+anio+ " and id_pcu=4 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append(" 	group by id_pcu,id_superficie) f");
        str.Append(" right join c_superficie s on f.id_superficie = s.id;");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        List<Data> data2 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["superficie"].ToString() == legends[0]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["pcu"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["superficie"].ToString() == legends[1]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["pcu"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            data2 = (from DataRow row in dt.Rows
                     where row["superficie"].ToString() == legends[2]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["pcu"].ToString(),
                     }).ToList();
            Serie serie2 = new Serie(legends[2], data2, type, type);

            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.series.Add(serie2);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getValorTipoVivienda(string clave_estado, int anio)
    {
        string[] legends = { "Popular hasta 158", "Popular hasta 200","tradicional", "Media residencial" };
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select 'Horizontal' tipo_vivienda,vsm.descripcion as segmento,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select id_tipo_vivienda,id_segmento,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak");
        str.Append("     where anio=" +anio+ " and id_tipo_vivienda=1 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_tipo_vivienda,id_segmento) f");
        str.Append(" right join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id");
        str.Append(" union");
        str.Append(" select 'Vertical' tipo_vivienda,vsm.descripcion as segmento,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select id_tipo_vivienda,id_segmento,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak");
        str.Append("     where anio=" + anio + " and id_tipo_vivienda=2 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_tipo_vivienda,id_segmento) f");
        str.Append(" right join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id;");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        List<Data> data2 = new List<Data>();
        List<Data> data3 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[0]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["tipo_vivienda"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[1]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["tipo_vivienda"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            data2 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[2]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["tipo_vivienda"].ToString(),
                     }).ToList();
            Serie serie2 = new Serie(legends[2], data2, type, type);
            data3 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[3]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["tipo_vivienda"].ToString(),
                     }).ToList();
            Serie serie3 = new Serie(legends[3], data3, type, type);

            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.series.Add(serie2);
            opt.series.Add(serie3);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getValorSuperficie(string clave_estado, int anio)
    {
        string[] legends = { "Popular hasta 158", "Popular hasta 200", "tradicional", "Media residencial" };
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select 'Menor a 45m2' superficie,vsm.descripcion as segmento,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select id_superficie,id_segmento,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak");
        str.Append("     where anio = " + anio + " and id_superficie = 3 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_superficie,id_segmento) f");
        str.Append(" right join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id");
        str.Append(" union");
        str.Append(" select 'De 45 a 60m2' superficie,vsm.descripcion as segmento,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select id_superficie,id_segmento,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak");
        str.Append("     where anio = " + anio + " and id_superficie = 1 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_superficie,id_segmento) f");
        str.Append(" right join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id");
        str.Append(" union");
        str.Append(" select 'Mayor a 60m2' superficie,vsm.descripcion as segmento,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select id_superficie,id_segmento,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak");
        str.Append("     where anio = " + anio + " and id_superficie = 2 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_superficie,id_segmento) f");
        str.Append(" right join c_valor_vivienda_vsm vsm on f.id_segmento = vsm.id;");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        List<Data> data2 = new List<Data>();
        List<Data> data3 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[0]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["superficie"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[1]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["superficie"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            data2 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[2]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["superficie"].ToString(),
                     }).ToList();
            Serie serie2 = new Serie(legends[2], data2, type, type);
            data3 = (from DataRow row in dt.Rows
                     where row["segmento"].ToString() == legends[3]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["superficie"].ToString(),
                     }).ToList();
            Serie serie3 = new Serie(legends[3], data3, type, type);

            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.series.Add(serie2);
            opt.series.Add(serie3);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getTipoPCU(string clave_estado, int anio)
    {
        string[] legends = { "Horizontal", "Vertical"};
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select COALESCE(pcu,'U1') pcu,tv.descripcion as tipo_vivienda,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion pcu,id_tipo_vivienda,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu=p.id");
        str.Append("     where anio="+anio+ " and id_pcu = 1 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_pcu,id_tipo_vivienda) f");
        str.Append(" right join c_tipo_vivienda tv on f.id_tipo_vivienda = tv.id");
        str.Append(" union");
        str.Append(" select COALESCE(pcu,'U2') pcu,tv.descripcion as tipo_vivienda,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion pcu,id_tipo_vivienda,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu=p.id");
        str.Append("     where anio=" + anio + " and id_pcu = 2 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_pcu,id_tipo_vivienda) f");
        str.Append(" right join c_tipo_vivienda tv on f.id_tipo_vivienda = tv.id");
        str.Append(" union");
        str.Append(" select COALESCE(pcu,'U3') pcu,tv.descripcion as tipo_vivienda,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion pcu,id_tipo_vivienda,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu=p.id");
        str.Append("     where anio=" + anio + " and id_pcu = 3 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_pcu,id_tipo_vivienda) f");
        str.Append(" right join c_tipo_vivienda tv on f.id_tipo_vivienda = tv.id");
        str.Append(" union");
        str.Append(" select COALESCE(pcu,'FC') pcu,tv.descripcion as tipo_vivienda,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select p.descripcion pcu,id_tipo_vivienda,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak f");
        str.Append("     join c_pcu p on f.id_pcu=p.id");
        str.Append("     where anio=" + anio + " and id_pcu = 4 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_pcu,id_tipo_vivienda) f");
        str.Append(" right join c_tipo_vivienda tv on f.id_tipo_vivienda = tv.id;");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["tipo_vivienda"].ToString() == legends[0]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["pcu"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["tipo_vivienda"].ToString() == legends[1]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["pcu"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            
            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getSuperficieTipoVivienda(string clave_estado, int anio)
    {
        string[] legends = { "Menor a 45m2", "De 45 a 60m2", "Mayor a 60m2"};
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select 'Horizontal' tipo_vivienda,s.descripcion as superficie,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select id_tipo_vivienda,id_superficie,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak");
        str.Append("     where anio="+anio+ " and id_tipo_vivienda=1 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_tipo_vivienda,id_superficie) f");
        str.Append(" right join c_superficie s on f.id_superficie = s.id");
        str.Append(" union");
        str.Append(" select 'Vertical' tipo_vivienda,s.descripcion as superficie,COALESCE(viviendas,0) viviendas");
        str.Append(" from (select id_tipo_vivienda,id_superficie,sum(viviendas) viviendas");
        str.Append(" 	from cubo_registro_vivienda_bak");
        str.Append("     where anio=" + anio + " and id_tipo_vivienda=2 and mes <= (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("     group by id_tipo_vivienda,id_superficie) f");
        str.Append(" right join c_superficie s on f.id_superficie = s.id;");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        List<Data> data2 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["superficie"].ToString() == legends[0]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["tipo_vivienda"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["superficie"].ToString() == legends[1]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["tipo_vivienda"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            data2 = (from DataRow row in dt.Rows
                     where row["superficie"].ToString() == legends[2]
                     select new Data()
                     {
                         value = int.Parse(row["viviendas"].ToString()),
                         name = row["tipo_vivienda"].ToString(),
                     }).ToList();
            Serie serie2 = new Serie(legends[2], data2, type, type);
            
            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.series.Add(serie2);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getTiempoMaduracion(string clave_estado, int anio)
    {
        int anioInicial = anio - 2;
        int anioAnterior = anio - 1;
        string[] legends = { "Preparacion", "Construccion", "Venta" };
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select i.anio,i.trimestre,i.registro,i.construccion,i.venta,i.total as total,i.numero_vivienda as viviendas");
        str.Append(" from inventario_estatal i");
        str.Append(" where clave_entidad_federativa = '"+clave_estado+"' and (anio = "+anioInicial+" and trimestre>=(select max(trimestre) from inventario_estatal where anio = "+anio+" and trimestre <> 5))");
        str.Append(" union");
        str.Append(" select i.anio,if(i.trimestre=5, 'U', i.trimestre),i.registro,i.construccion,i.venta,i.total as total,i.numero_vivienda as viviendas");
        str.Append(" from inventario_estatal i");
        str.Append(" where anio between "+anioAnterior+" and "+anio+" and clave_entidad_federativa = '"+clave_estado+"'");
        str.Append(" order by anio,trimestre;");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        List<Data> data2 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     select new Data()
                     {
                         value = int.Parse(row["registro"].ToString()),
                         name = row["trimestre"]+"T"+row["anio"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     select new Data()
                     {
                         value = int.Parse(row["construccion"].ToString()),
                         name = row["trimestre"]+"T"+row["anio"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            data2 = (from DataRow row in dt.Rows
                     select new Data()
                     {
                         value = int.Parse(row["venta"].ToString()),
                         name = row["trimestre"]+"T"+row["anio"].ToString(),
                     }).ToList();
            Serie serie2 = new Serie(legends[2], data2, type, type);

            var lstXaxis = new HashSet<string>(data0.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data1.Select(x => x.name).ToList<string>());
            lstXaxis.UnionWith(data2.Select(x => x.name).ToList<string>());
            opt.xAxis = lstXaxis.ToList<string>();
            opt.series.Add(serie0);
            opt.series.Add(serie1);
            opt.series.Add(serie2);
            opt.legend = legends.ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getInventarioMunicipio(string clave_estado, int anio)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select cm.descripcion municipio,sum(viviendas) viviendas");
        str.Append(" from cubo_inventario_vivienda f");
        str.Append(" join c_municipio cm on f.clave_estado = cm.clave_entidad_federativa and f.clave_municipio = cm.clave");
        str.Append(" where anio="+anio+ " and mes = (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_entidad_federativa = '" + clave_estado + "'");
        str.Append(" group by clave_estado,clave_municipio");
        str.Append(" order by viviendas desc");
        str.Append(" limit 5;");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = float.Parse(row["viviendas"].ToString()),
                       name = row["municipio"].ToString()
                   }).ToList();
            opt.legend = lst.Select(x => x.name).ToList<string>();
            Serie serie = new Serie("Viviendas", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getInventarioPCU(string clave_estado, int anio)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append(" select p.descripcion pcu,sum(viviendas) viviendas");
        str.Append(" from cubo_inventario_vivienda f");
        str.Append(" join c_pcu p on f.id_pcu = p.id");
        str.Append(" where anio=" + anio + " and mes = (select mes from c_periodo_registro_vivienda where actual =1) and id_pcu >0");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by id_pcu;");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = float.Parse(row["viviendas"].ToString()),
                       name = row["pcu"].ToString()
                   }).ToList();
            opt.legend = lst.Select(x => x.name).ToList<string>();
            Serie serie = new Serie("Viviendas por PCU", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }
    public Option getInventarioSituacionAvance(string clave_estado, int anio)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("SELECT anio,a.descripcion as avance_obra,sum(viviendas) viviendas");
        str.Append(" from cubo_inventario_vivienda f");
        str.Append(" join c_avance_obra a on f.id_avance_obra = a.id");
        str.Append(" WHERE anio BETWEEN " + anioAnterior + " AND " + anio + " and mes = (select mes from c_periodo_registro_vivienda where actual =1)");
        if (!clave_estado.Equals("00"))
            str.Append(" AND clave_estado = '" + clave_estado + "'");
        str.Append(" GROUP BY anio,id_avance_obra;");
        List<Data> serieAnterior = new List<Data>();
        List<Data> serieActual = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            serieAnterior = (from DataRow row in dt.Rows
                             where row["anio"].ToString() == anioAnterior.ToString()
                             select new Data()
                             {
                                 value = float.Parse(row["viviendas"].ToString()),
                                 name = row["avance_obra"].ToString()
                             }).ToList();
            serieActual = (from DataRow row in dt.Rows
                           where row["anio"].ToString() == anio.ToString()
                           select new Data()
                           {
                               value = float.Parse(row["viviendas"].ToString()),
                               name = row["avance_obra"].ToString()
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
    #endregion
}