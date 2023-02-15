using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de InventarioDAO
/// </summary>
public class InventarioDAO
{
    private static InventarioDAO _instancia = null;

    public static InventarioDAO instancia()
    {
        return _instancia == null ? new InventarioDAO() : _instancia;
    }

    public InventarioDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    #region DASHBOARD

    public List<InventarioVO> getKPIs()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select s.descripcion as segmento, a.descripcion as avance_obra, tv.descripcion as tipo_vivienda, viviendas ");
        str.Append("from (select id_segmento, id_avance_obra, id_tipo_vivienda, sum(viviendas) as viviendas ");
        str.Append("from cubo_inventario_vivienda where anio = (select anio from c_periodo_inventario where actual) ");
        str.Append("and mes = (select mes from c_periodo_inventario where actual) ");
        str.Append("group by id_segmento, id_avance_obra, id_tipo_vivienda) f ");
        str.Append("join c_valor_vivienda s on f.id_segmento = s.id ");
        str.Append("join c_avance_obra a on f.id_avance_obra = a.id ");
        str.Append("join c_tipo_vivienda tv on f.id_tipo_vivienda = tv.id");
        List<InventarioVO> KPIs = new List<InventarioVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new InventarioVO()
                    {
                        avance_obra = row["avance_obra"].ToString(),
                        tipo_vivienda = row["tipo_vivienda"].ToString(),
                        segmento = row["segmento"].ToString(),
                        viviendas = UInt32.Parse(row["viviendas"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    #endregion
    #region FECHA

    public DateTime seleccionarFecha()
    {
        //string str = "select TO_DATE(concat(anio, TO_CHAR(mes,'fm00'), '01'), 'YYYYMMDD') as fecha from c_periodo_inventario where actual";
        string endMonth = "SELECT (date_trunc('month',concat(anio,'-',TO_CHAR(mes,'fm00'),'-', '01')::date)+ interval '1 month' - interval '1 day')::date as fecha from c_periodo_inventario where actual";
        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(endMonth, Constante.BD_SNIIV);
            fecha = (from DataRow row in dt.Rows select (DateTime)row["fecha"]).ToList<DateTime>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return fecha;
    }



    #endregion

    #region CUBO

    public List<CatalogoVO> seleccionarAnioInventario()
    {
        string str = "select distinct anio from c_periodo_inventario order by anio desc;";
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
    public List<CatalogoVO> seleccionarMesInventario(int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select c.mes, m.descripcion from c_periodo_inventario c");
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

    public string[] crearConsulta(string parametro)
    {
        string[] lst = new string[3];
        switch (parametro)
        {
            case "avance_obra":
                lst[0] = "|a.descripcion as avance_obra";
                lst[1] = "|id_avance_obra";
                lst[2] = "|join c_avance_obra a on f.id_avance_obra = a.id";
                break;
            case "estado":
                lst[0] = "|e.descripcion as estado";
                lst[1] = "|clave_estado";
                lst[2] = "|join c_entidad_federativa e on f.clave_estado = e.clave";
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
                lst[0] = "|s.descripcion as segmento";
                lst[1] = "|id_segmento";
                lst[2] = "|join c_valor_vivienda s on f.id_segmento = s.id";
                break;
            case "segmento_uma":
                lst[0] = "|su.descripcion as segmento_uma";
                lst[1] = "|id_segmento_uma";
                lst[2] = "|join c_valor_vivienda_uma su on f.id_segmento_uma = su.id";
                break;
            case "tipo_vivienda":
                lst[0] = "|tv.descripcion as tipo_vivienda";
                lst[1] = "|id_tipo_vivienda";
                lst[2] = "|join c_tipo_vivienda tv on f.id_tipo_vivienda = tv.id";
                break;
            default: //subsidio
                lst[0] = "|subsidio";
                lst[1] = "|subsidio";
                lst[2] = "|";
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
    public List<InventarioVO> getCubo(string anios, string clave_estado, string clave_municipio, string dimensiones)
    {
        string anio_inicio = anios.Split(',').First();
        string mes = anios.Split(',').Last();

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

        List<InventarioVO> cubo = new List<InventarioVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",viviendas");
        query.Append(" from (select ");
        query.Append(strSubField);
        query.Append(",sum(viviendas) as viviendas");
        query.Append(" from cubo_inventario_vivienda ");
        query.Append("where anio = " + anio_inicio + " and mes = " + mes);
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
            cubo = Util.instancia().ConvertDataTable<InventarioVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }

    #endregion

    #region TEMÁTICO

    //Actualmente apunta a cubo_conavi (semanal), deberá apuntar a los datos mensuales
    //Cambiará el campo dependiendo la métrica

    /*
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
    */

    /*
    public List<CatalogoVO> seleccionarMes(int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select c.mes, m.descripcion from c_periodo_conavi c");
        str.Append(" join c_mes m on m.id = c.mes");
        str.Append(" where c.anio = " + anio);
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
    */

    public Option getMes(string clave_estado, int anio, int mes, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        opt.legend = new List<string> { anioAnterior.ToString(), anio.ToString() };
        StringBuilder str = new StringBuilder();
        //En caso de tener una mejor idea, favor cambiar lógica
        str.Append("select COALESCE(c.anio, " + anioAnterior + ") as anio, m.descripcion as mes, COALESCE(c." + metrica + ", 0) as " + metrica);
        str.Append(" from (select anio, id_mes, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi");
        str.Append(" where anio = " + anioAnterior);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, id_mes order by anio, id_mes) c");
        str.Append(" right join c_mes m on c.id_mes = m.id");
        str.Append(" union");
        str.Append(" select COALESCE(c.anio, " + anio + ") as anio, m.descripcion as mes, COALESCE(c." + metrica + ", 0) as " + metrica + "");
        str.Append(" from (select anio, id_mes, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi");
        str.Append(" where anio = " + anio);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, id_mes order by anio, id_mes) c");
        str.Append(" right join c_mes m on c.id_mes = m.id");
        str.Append(" where m.id <= " + mes);
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

    public Option getModalidad(string clave_estado, int anio, int mes, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select anio, modalidad, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi");
        str.Append(" where (anio = " + anioAnterior + " or (anio = " + anio + " and id_mes <= " + mes + "))");
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

    public Option getTipoEe(string clave_estado, int anio, int mes, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select anio, if(tipo_entidad_ejecutora='Intermediarios financieros','Intermediarios',tipo_entidad_ejecutora) as entidad_ejecutora, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi");
        str.Append(" where (anio = " + anioAnterior + " or (anio = " + anio + " and id_mes <= " + mes + "))");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, tipo_entidad_ejecutora");
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

    public Option getTipoMunicipio(string clave_estado, int anio, int mes, string metrica)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select zona as tipo_municipio, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_conavi");
        str.Append(" where anio = " + anio + " and id_mes <= " + mes);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by zona");
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

    public Option getDistribucion(string clave_estado, int anio, int mes, string dimension)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select anio, " + dimension + ", sum(acciones) as acciones");
        str.Append(" from cubo_conavi");
        str.Append(" where (anio = " + anioAnterior + " or (anio = " + anio + " and id_mes <= " + mes + "))");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, " + dimension);
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

    public Option getValorVivienda(string clave_estado, int anio, int mes, string dimension)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        opt.legend = new List<string> { anioAnterior.ToString(), anio.ToString() };
        StringBuilder str = new StringBuilder();
        str.Append("select anio, " + dimension + ", sum(monto) as monto");
        str.Append(" from cubo_conavi");
        str.Append(" where (anio = " + anioAnterior + " or (anio = " + anio + " and id_mes <= " + mes + "))");
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, " + dimension + " order by anio, " + dimension);
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

    public Option getGenero(string clave_estado, int anio, int mes, string dimension)
    {
        string hombre = "Hombre";
        string mujer = "Mujer";
        Option opt = new Option();
        opt.legend = new List<string> { hombre, mujer };
        StringBuilder str = new StringBuilder();
        //En caso de tener una mejor idea, favor cambiar lógica
        str.Append("select COALESCE(t.genero, '" + hombre + "') as genero, e.descripcion,");
        str.Append(" round(COALESCE(sum(acciones)*100/(");
        str.Append("  select sum(acciones)");
        str.Append("  from cubo_conavi");
        str.Append("  where " + dimension + " = e.descripcion and anio = " + anio + " and id_mes <= " + mes);
        if (!clave_estado.Equals("00"))
            str.Append("  and clave_estado = '" + clave_estado + "'");
        str.Append(" ),0),2) as porcentaje");
        str.Append(" from (select genero, " + dimension + ", acciones");
        str.Append("  from cubo_conavi where anio = " + anio + " and id_mes <= " + mes + " and genero = '" + hombre + "'");
        if (!clave_estado.Equals("00"))
            str.Append("  and clave_estado = '" + clave_estado + "'");
        str.Append(" ) t");
        str.Append(" right join c_" + dimension + " e on t." + dimension + " = e.descripcion");
        str.Append(" group by e.descripcion");
        str.Append(" union");
        str.Append(" select COALESCE(t.genero, '" + mujer + "') as genero, e.descripcion,");
        str.Append(" round(COALESCE(sum(acciones)*100/(");
        str.Append("  select sum(acciones)");
        str.Append("  from cubo_conavi ");
        str.Append("  where " + dimension + " = e.descripcion and anio = " + anio + " and id_mes <= " + mes);
        if (!clave_estado.Equals("00"))
            str.Append("  and clave_estado = '" + clave_estado + "'");
        str.Append(" ),0),2) as porcentaje");
        str.Append(" from (select genero, " + dimension + ", acciones");
        str.Append("  from cubo_conavi where anio = " + anio + " and id_mes <= " + mes + " and genero = '" + mujer + "'");
        if (!clave_estado.Equals("00"))
            str.Append("  and clave_estado = '" + clave_estado + "'");
        str.Append(" ) t");
        str.Append(" right join c_" + dimension + " e on t." + dimension + " = e.descripcion");
        str.Append(" group by e.descripcion");
        /*str.Append("select genero, t." + dimension + ",");
        str.Append(" round((sum(acciones) * 100) / (");
        str.Append("  select sum(acciones)");
        str.Append("  from cubo_conavi");
        str.Append("  where " + dimension + " = t." + dimension + " and anio = " + anio + " and id_mes <= " + mes);
        if (!clave_estado.Equals("00"))
            str.Append("  and clave_estado = '" + clave_estado + "'");
        str.Append(" ), 2) as porcentaje");
        str.Append(" from cubo_conavi t");
        str.Append(" where anio = " + anio + " and id_mes <= " + mes);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by genero, t." + dimension);*/
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
                               name = row["descripcion"].ToString()
                           }).ToList();
            serieMujer = (from DataRow row in dt.Rows
                          where row["genero"].ToString() == mujer
                          select new Data()
                          {
                              value = float.Parse(row["porcentaje"].ToString()),
                              name = row["descripcion"].ToString()
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

    #endregion

}