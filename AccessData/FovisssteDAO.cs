﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de FovisssteDAO
/// </summary>
public class FovisssteDAO
{
    private static FovisssteDAO _instancia = null;

    public static FovisssteDAO instancia()
    {
        return _instancia == null ? new FovisssteDAO() : _instancia;
    }

    public FovisssteDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region DASHBOARD

    /*public DateTime seleccionarFecha()
    {
        string str = "call sp_fecha_fovissste();";
        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            fecha = (from DataRow row in dt.Rows select (DateTime)row["fecha"]).ToList<DateTime>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return fecha;
    }*/

    #endregion

    #region CUBO

    public List<CatalogoVO> seleccionarAnio()
    {
        //string str = "SELECT distinct anio from cubo_fovissste order by anio desc;";
        string str = "select distinct anio from c_periodo_fovissste order by anio desc";
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
                lst[2] = "|join c_esquema_fovissste s on f.id_esquema = s.id";
                break;
            case "estado":
                lst[0] = "|e.descripcion as estado";
                lst[1] = "|clave_estado";
                lst[2] = "|join c_entidad_federativa e on f.clave_estado = e.clave";
                break;
            case "entidad_financiera":
                lst[0] = "|ee.descripcion as entidad_financiera";
                lst[1] = "|id_ee";
                lst[2] = "|join c_intermediario_financiero_fovissste ee on f.id_ee = ee.id";
                break;
            case "genero":
                lst[0] = "|g.descripcion as sexo";
                lst[1] = "|id_genero";
                lst[2] = "|join c_genero g on f.id_genero = g.id";
                break;
            case "linea_credito":
                lst[0] = "|l.descripcion as linea_credito";
                lst[1] = "|id_linea_credito";
                lst[2] = "|join c_linea_credito_fovissste l on f.id_linea_credito = l.id";
                break;
            case "mes":
                lst[0] = "|m.descripcion as mes";
                lst[1] = "|mes";
                lst[2] = "|join c_mes m on f.mes = m.id";
                break;
            case "modalidad":
                lst[0] = "|mo.descripcion as modalidad";
                lst[1] = "|id_modalidad";
                lst[2] = "|join c_modalidad_fovissste mo on f.id_modalidad = mo.id";
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

    public List<FovisssteVO> getCubo(string anios, string clave_estado, string clave_municipio, string dimensiones)
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

        List<FovisssteVO> cubo = new List<FovisssteVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",acciones,monto");
        query.Append(" from (select ");
        query.Append(strSubField);
        query.Append(",sum(acciones) as acciones,sum(monto) as monto");
        query.Append(" from cubo_fovissste_bak ");
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
            cubo = Util.instancia().ConvertDataTable<FovisssteVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }

    #endregion

    #region TEMÁTICO

    public DateTime seleccionarFecha()
    {
        //string str = "select TO_DATE(concat(anio, TO_CHAR(mes,'fm00'), '01'), 'YYYYMMDD') as fecha from c_periodo_fovissste where actual";
        string endMonth = "SELECT (date_trunc('month',concat(anio,'-',TO_CHAR(mes,'fm00'),'-', '01')::date)+ interval '1 month' - interval '1 day')::date as fecha from c_periodo_fovissste where actual";
        DateTime fecha = new DateTime();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(endMonth, Constante.BD_SNIIV);
            fecha = (from DataRow row in dt.Rows select (DateTime)row["fecha"]).ToList<DateTime>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return fecha;
    }

    public Option getMes(string clave_estado, int anio, string metrica)
    {
        int anioAnterior = anio - 1;
        Option opt = new Option();
        opt.legend = new List<string> { anioAnterior.ToString(), anio.ToString() };
        StringBuilder str = new StringBuilder();
        str.Append("select COALESCE(c.anio, " + anioAnterior + ") as anio, m.descripcion as mes, COALESCE(c." + metrica + ", 0) as " + metrica);
        str.Append(" from (select anio, mes, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_fovissste_bak");
        str.Append(" where anio = " + anioAnterior + " and id_esquema != " + Constante.RESPALDA2M);
        //str.Append(" where anio = " + anioAnterior + " and id_esquema != " + Constante.MEJORAVIT_INFONAVIT);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by anio, mes) c");
        str.Append(" right join c_mes m on c.mes = m.id");
        str.Append(" union");
        str.Append(" select COALESCE(c.anio, " + anio + ") as anio, m.descripcion as mes, COALESCE(c." + metrica + ", 0) as " + metrica + "");
        str.Append(" from (select anio, mes, sum(" + metrica + ") as " + metrica);
        str.Append(" from cubo_fovissste_bak");
        str.Append(" where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        //str.Append(" where anio = " + anio + " and id_esquema != " + Constante.MEJORAVIT_INFONAVIT);
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

    public Option getMesEsquema(string clave_estado, int anio)
    {
        string[] legends = { "Tradicional", "Subsidio CONAVI", "Cofinanciamientos", "Otros" };
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select s.descripcion as mes,");
        str.Append(" case when t.id_esquema = 1 THEN '" + legends[0] + "'");
        str.Append(" when t.id_esquema IN (7,8,10,11) THEN '" + legends[2] + "'");
        str.Append(" when t.id_esquema IN (4,6) THEN '" + legends[1] + "'");
        str.Append(" else '" + legends[3] + "' end as esquema");
        str.Append(" , sum(t.acciones) acciones from");
        str.Append("    (select mes, 1 as id_esquema, sum(if(id_esquema = 1,acciones,0)) acciones");
        str.Append("    from cubo_fovissste_bak where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by mes");
        str.Append("    union");
        str.Append("    select mes, 2 as id_esquema, sum(if(id_esquema = 2,acciones,0)) acciones");
        str.Append("    from cubo_fovissste_bak where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by mes");
        str.Append("    union");
        str.Append("    select mes, 3 as id_esquema, sum(if(id_esquema = 3,acciones,0)) acciones");
        str.Append("    from cubo_fovissste_bak where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by mes");
        str.Append("    union");
        str.Append("    select mes, 4 as id_esquema, sum(if(id_esquema = 4,acciones,0)) acciones");
        str.Append("    from cubo_fovissste_bak where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by mes");
        str.Append("    union");
        str.Append("    select mes, 5 as id_esquema, sum(if(id_esquema = 5,acciones,0)) acciones");
        str.Append("    from cubo_fovissste_bak where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by mes");
        str.Append("    union");
        str.Append("    select mes, 6 as id_esquema, sum(if(id_esquema = 6,acciones,0)) acciones");
        str.Append("    from cubo_fovissste_bak where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by mes");
        str.Append("    union");
        str.Append("    select mes, 7 as id_esquema, sum(if(id_esquema = 7,acciones,0)) acciones");
        str.Append("    from cubo_fovissste_bak where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by mes");
        str.Append("    union");
        str.Append("    select mes, 8 as id_esquema, sum(if(id_esquema = 8,acciones,0)) acciones");
        str.Append("    from cubo_fovissste_bak where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        str.Append("    group by mes) t");
        str.Append(" join c_esquema_fovissste e on e.id = t.id_esquema");
        str.Append(" join c_mes s on s.id = t.mes");
        str.Append(" group by mes, esquema order by s.id, esquema");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        List<Data> data2 = new List<Data>();
        List<Data> data3 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["esquema"].ToString() == legends[0]
                     select new Data()
                     {
                         value = int.Parse(row["acciones"].ToString()),
                         name = row["mes"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["esquema"].ToString() == legends[1]
                     select new Data()
                     {
                         value = int.Parse(row["acciones"].ToString()),
                         name = row["mes"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            data2 = (from DataRow row in dt.Rows
                     where row["esquema"].ToString() == legends[2]
                     select new Data()
                     {
                         value = int.Parse(row["acciones"].ToString()),
                         name = row["mes"].ToString(),
                     }).ToList();
            Serie serie2 = new Serie(legends[2], data2, type, type);
            data3 = (from DataRow row in dt.Rows
                     where row["esquema"].ToString() == legends[3]
                     select new Data()
                     {
                         value = int.Parse(row["acciones"].ToString()),
                         name = row["mes"].ToString(),
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

    public Option getMesModalidad(string clave_estado, int anio)
    {
        string[] legends = { "Adquisición vivienda nueva", "Adquisición vivienda existente", "Otros" };
        string type = "bar";
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select s.descripcion as mes,");
        str.Append(" case when t.id_modalidad in (1) and t.id_linea_credito in (1,3) then '" + legends[0] + "'");
        str.Append(" when t.id_modalidad in (2) and t.id_linea_credito in (1) then '" + legends[1] + "'");
        str.Append(" else '" + legends[2] + "' end as modalidad");
        str.Append(" , sum(t.acciones) acciones from");
        str.Append("    (select mes, id_modalidad, id_linea_credito, sum(acciones) as acciones");
        str.Append("    from cubo_fovissste_bak where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append("    and clave_estado = '" + clave_estado + "'");
        str.Append("    group by mes, id_modalidad, id_linea_credito) t");
        str.Append(" join c_modalidad_fovissste mf on mf.id=t.id_modalidad");
        str.Append(" join c_linea_credito_fovissste lc on lc.id = t.id_linea_credito");
        str.Append(" join c_mes s on s.id = t.mes");
        str.Append(" group by mes, modalidad order by s.id, modalidad");
        List<Data> data0 = new List<Data>();
        List<Data> data1 = new List<Data>();
        List<Data> data2 = new List<Data>();
        try
        {
            //Hacer ésto dinámico
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            data0 = (from DataRow row in dt.Rows
                     where row["modalidad"].ToString() == legends[0]
                     select new Data()
                     {
                         value = int.Parse(row["acciones"].ToString()),
                         name = row["mes"].ToString(),
                     }).ToList();
            Serie serie0 = new Serie(legends[0], data0, type, type);
            data1 = (from DataRow row in dt.Rows
                     where row["modalidad"].ToString() == legends[1]
                     select new Data()
                     {
                         value = int.Parse(row["acciones"].ToString()),
                         name = row["mes"].ToString(),
                     }).ToList();
            Serie serie1 = new Serie(legends[1], data1, type, type);
            data2 = (from DataRow row in dt.Rows
                     where row["modalidad"].ToString() == legends[2]
                     select new Data()
                     {
                         value = int.Parse(row["acciones"].ToString()),
                         name = row["mes"].ToString(),
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

    public Option getModalidad(string clave_estado, int anio)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select case when id_modalidad in (1) and t.id_linea_credito in (1,3) then 'Adquisición vivienda nueva'");
        str.Append(" when id_modalidad in (2) and t.id_linea_credito in (1) then 'Adquisición vivienda existente'");
        str.Append(" else 'Otros' end as modalidad,");
        str.Append(" sum(acciones) as acciones");
        str.Append(" from cubo_fovissste_bak t");
        str.Append(" join c_modalidad_fovissste m on m.id = t.id_modalidad");
        str.Append(" join c_linea_credito_fovissste lc on lc.id = t.id_linea_credito");
        str.Append(" where anio = " + anio + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by modalidad");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = float.Parse(row["acciones"].ToString()),
                       name = row["modalidad"].ToString()
                   }).ToList();
            opt.legend = lst.Select(x => x.name).ToList<string>();
            Serie serie = new Serie("modalidad", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getTipoVivienda(string clave_estado, int anio)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select case when id_valor_vivienda in (1, 2) then 'Económica y Popular'");
        str.Append(" when id_valor_vivienda in (5, 6) then 'Residencial'");
        str.Append(" else vv.descripcion end as tipo_vivienda,");
        str.Append(" sum(acciones) as acciones");
        str.Append(" from cubo_fovissste_bak");
        str.Append(" join c_valor_vivienda vv on vv.id = id_valor_vivienda");
        str.Append(" where anio = " + anio + " and id_valor_vivienda != 0 and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by tipo_vivienda");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = float.Parse(row["acciones"].ToString()),
                       name = row["tipo_vivienda"].ToString()
                   }).ToList();
            opt.legend = lst.Select(x => x.name).ToList<string>();
            Serie serie = new Serie("tipo_vivienda", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getGenero(string clave_estado, int anio, int id_rango_edad)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select g.descripcion as genero, sum(acciones) as acciones");
        str.Append(" from cubo_fovissste_bak");
        str.Append(" join c_genero g on g.id = id_genero");
        str.Append(" where anio = " + anio + " and id_genero != 0 and id_rango_edad = " + id_rango_edad + " and id_esquema != " + Constante.RESPALDA2M);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by id_genero");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = float.Parse(row["acciones"].ToString()),
                       name = row["genero"].ToString()
                   }).ToList();
            opt.legend = lst.Select(x => x.name).ToList<string>();
            Serie serie = new Serie("genero", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    public Option getQuintil(string clave_estado, int anio, int id_rango_edad, int id_genero)
    {
        Option opt = new Option();
        StringBuilder str = new StringBuilder();
        str.Append("select quintil, sum(acciones) as acciones");
        str.Append(" from quintil_fovissste");
        str.Append(" where anio = " + anio + " and id_rango_edad = " + id_rango_edad + " and id_genero = " + id_genero);
        if (!clave_estado.Equals("00"))
            str.Append(" and clave_estado = '" + clave_estado + "'");
        str.Append(" group by quintil");
        List<Data> lst = new List<Data>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new Data()
                   {
                       value = float.Parse(row["acciones"].ToString()),
                       name = row["quintil"].ToString()
                   }).ToList();
            opt.legend = lst.Select(x => x.name).ToList<string>();
            Serie serie = new Serie("quintil", lst);
            opt.series.Add(serie);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opt;
    }

    #endregion

    #region REPORTE DESARROLLADOR

    public List<CatalogoVO> seleccionarMes(int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select c.mes, m.descripcion from c_periodo_fovissste c");
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

    public List<DesarrolladorFovisssteVO> getDesarrollador(string anio, string mes, string clave_estado, string clave_municipio)
    {
        List<DesarrolladorFovisssteVO> rpt = new List<DesarrolladorFovisssteVO>();
        StringBuilder query = new StringBuilder();

        query.Append("select f.desarrollador, e.descripcion as esquema, ");
        query.Append("sum(f.acciones) as acciones, sum(f.monto) as monto ");
        query.Append("from desarrollador_fovissste f ");
        query.Append("join c_esquema_fovissste e on e.id = f.id_esquema ");
        query.Append("where anio = " + anio);
        if (mes != "0")
            query.Append(" and mes = " + mes);
        if (clave_estado != "0")
            query.Append(" and clave_estado = '" + clave_estado + "'");
        if (clave_municipio != "0")
            query.Append(" and clave_estado = '" + clave_estado + "' and clave_municipio = '" + clave_municipio + "'");
        query.Append(" group by f.desarrollador, e.descripcion");

        try
        {
            DataTable dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV);
            rpt = Util.instancia().ConvertDataTable<DesarrolladorFovisssteVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return rpt;
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
        query.Append("mt.monto  AS total_monto ");
        query.Append("FROM cubo_fovissste_bak c ");
        query.Append("JOIN c_entidad_federativa e on e.clave = c.clave_estado ");
        query.Append("JOIN c_mes m on m.id = c.mes ");
        query.Append("JOIN meta mt on mt.clave = '00621' and mt.anio = " + anio + " and mt.clave_entidad_federativa = c.clave_estado ");
        query.Append("WHERE c.anio = " + anio + " ");
        query.Append("GROUP BY e.clave, e.abreviacion, m.abreviatura, mt.acciones, mt.monto) t ");
        query.Append("GROUP BY t.estado, total_acciones, total_monto ");
        DataTable dt = new DataTable();

        try { dt = Generico.instancia().seleccionar(query.ToString(), Constante.BD_SNIIV); }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }

    public List<CatalogoVO> seleccionarAnioMeta()
    {
        string str = "select distinct anio from meta where clave = '00621' order by anio desc";
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