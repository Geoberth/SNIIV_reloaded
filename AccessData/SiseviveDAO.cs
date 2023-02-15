using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de SiseviveDAO
/// </summary>
public class SiseviveDAO
{
    private static SiseviveDAO _instancia = null;

    public static SiseviveDAO instancia()
    {
        return _instancia == null ? new SiseviveDAO() : _instancia;
    }

    public SiseviveDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region DASHBOARD

    public List<SiseviveVO> getKPIs(int anio_inicio, int anio_fin)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select ef.descripcion as estado, tr.descripcion as tipologia_vivienda, c.descripcion as clima, idg, ");
        str.Append("ps.abreviacion as programa, g.descripcion as grupo, fecha, t.viviendas ");
        str.Append("from (select clave_estado, id_tipologia_ruv, id_clima, idg, id_programa, id_grupo_sisevive, fecha, sum(viviendas) as viviendas ");
        str.Append("from cubo_sisevive ");
        str.Append("where anio between " + anio_inicio + " AND " + anio_fin);
        str.Append(" group by clave_estado, id_tipologia_ruv, id_clima, idg, id_grupo_sisevive, id_programa, fecha) t ");
        str.Append("join c_entidad_federativa ef on ef.clave = t.clave_estado ");
        str.Append("join c_tipologia_ruv tr on tr.id = t.id_tipologia_ruv ");
        str.Append("join c_clima c on c.id = t.id_clima ");
        str.Append("join c_programa_sisevive ps on ps.id = t.id_programa ");
        str.Append("join c_grupo_sisevive g on g.id = t.id_grupo_sisevive");
        List<SiseviveVO> KPIs = new List<SiseviveVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new SiseviveVO()
                    {
                        estado = row["estado"].ToString(),
                        tipologia_vivienda = row["tipologia_vivienda"].ToString(),
                        clima = row["clima"].ToString(),
                        idg = row["idg"].ToString(),
                        programa = row["programa"].ToString(),
                        grupo = row["grupo"].ToString(),
                        fecha_corte = row["fecha"].ToString().Substring(0, 10),
                        viviendas = int.Parse(row["viviendas"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }

    #endregion

    #region CUBO

    public List<CatalogoVO> seleccionarAnio()
    {
        string str = "select distinct date_part('year', fecha) as anio from c_periodo_sisevive order by anio desc";
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
        string str = "select fecha from c_periodo_sisevive where actual";
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
            case "clima":
                lst[0] = "|l.descripcion as clima";
                lst[1] = "|id_clima";
                lst[2] = "|join c_clima l on f.id_clima = l.id";
                break;
            case "estado":
                lst[0] = "|e.descripcion as estado";
                lst[1] = "|clave_estado";
                lst[2] = "|join c_entidad_federativa e on f.clave_estado = e.clave";
                break;
            case "grupo":
                lst[0] = "|g.descripcion as grupo";
                lst[1] = "|id_grupo_sisevive";
                lst[2] = "|join c_grupo_sisevive g on f.id_grupo_sisevive = g.id";
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
            case "tipologia_vivienda":
                lst[0] = "|t.descripcion as tipologia_vivienda";
                lst[1] = "|id_tipologia_ruv";
                lst[2] = "|join c_tipologia_ruv t on f.id_tipologia_ruv = t.id";
                break;
            case "programa":
                lst[0] = "|vs.abreviacion as programa";
                lst[1] = "|id_programa";
                lst[2] = "|join c_programa_sisevive vs on f.id_programa = vs.id";
                break;
            default:
                lst[0] = "|idg";
                lst[1] = "|idg";
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

    // V1 Sin agrupaciones
    public List<SiseviveVO> getCubo(string anios, string clave_estado, string clave_municipio, string dimensiones)
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

        List<SiseviveVO> cubo = new List<SiseviveVO>();
        StringBuilder query = new StringBuilder();
        query.Append("select ");
        query.Append(strField);
        query.Append(",viviendas");
        query.Append(" from (select ");
        query.Append(strSubField.Replace("mes", "EXTRACT(MONTH FROM fecha) as mes"));
        query.Append(",sum(viviendas) as viviendas");
        query.Append(" from cubo_sisevive ");
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
            cubo = Util.instancia().ConvertDataTable<SiseviveVO>(dt);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cubo;
    }

    #endregion
}