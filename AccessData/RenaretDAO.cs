using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de RenaretDAO
/// </summary>
public class RenaretDAO
{
    private static RenaretDAO _instancia = null;

    public static RenaretDAO instancia()
    {
        return _instancia == null ? new RenaretDAO() : _instancia;
    }

    public RenaretDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DateTime seleccionarFecha()
    {
        //string str = "select TO_DATE(concat(anio,mes,'01'), 'YYYYMMDD') as fecha from c_periodo_renaret where actual";
        string endMonth = "SELECT (date_trunc('month',concat(anio,'-',TO_CHAR(mes,'fm00'),'-', '01')::date)+ interval '1 month' - interval '1 day')::date as fecha from c_periodo_renaret where actual";

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
        string str = "select distinct anio from renaret order by anio desc";
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
        str.Append("select distinct(c.mes), m.descripcion from renaret c");
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

    public List<RenaretVO> getRenaretEstatal(int anio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT clave AS clave_estado, estado, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'U1' THEN sup_ha END), 1), 0) AS U1, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'U2' THEN sup_ha END), 1), 0) AS U2, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'U3' THEN sup_ha END), 1), 0) AS U3, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'R4-A' THEN sup_ha END), 1), 0) AS R4A, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'R3-A' THEN sup_ha END), 1), 0) AS R3A, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'R4-B' THEN sup_ha END), 1), 0) AS R4B, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'FC' THEN sup_ha END), 1), 0) AS FC, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'S/D' THEN sup_ha END), 1), 0) AS SD, ");
        str.Append("ROUND(SUM(sup_ha), 1) AS total FROM( ");
        str.Append("SELECT e.clave, e.descripcion AS estado, r.calif_pcu, r.sup_ha ");
        str.Append("FROM (SELECT anio, mes, cve_edo, calif_pcu, SUM(sup_ha) AS sup_ha ");
        str.Append("FROM renaret WHERE anio = " + anio + " AND mes = (select max(mes) from renaret where anio = " + anio + ") ");
        str.Append("GROUP BY anio, mes, cve_edo, calif_pcu) r ");
        str.Append("LEFT JOIN c_entidad_federativa e ON r.cve_edo = e.clave ");
        str.Append(") t GROUP BY clave, estado");
        List<RenaretVO> lstEstatal = new List<RenaretVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstEstatal = (from DataRow row in dt.Rows
                        select new RenaretVO()
                        {
                            clave_area_geoestadistica = row["clave_estado"].ToString(),
                            area_geoestadistica = row["estado"].ToString(),
                            u1 = float.Parse(row["U1"].ToString()),
                            u2 = float.Parse(row["U2"].ToString()),
                            u3 = float.Parse(row["U3"].ToString()),
                            r4a = float.Parse(row["R4A"].ToString()),
                            r3a = float.Parse(row["R3A"].ToString()),
                            r4b = float.Parse(row["R4B"].ToString()),
                            fc = float.Parse(row["FC"].ToString()),
                            sd = float.Parse(row["SD"].ToString()),
                            total = float.Parse(row["total"].ToString())
                        }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstEstatal;
    }

    public List<RenaretVO> getRenaretMunicipal(int anio, string clave_estado)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT clave_mun AS clave_municipio, municipio, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'U1' THEN sup_ha END), 1), 0) AS U1, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'U2' THEN sup_ha END), 1), 0) AS U2, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'U3' THEN sup_ha END), 1), 0) AS U3, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'R4-A' THEN sup_ha END), 1), 0) AS R4A, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'R3-A' THEN sup_ha END), 1), 0) AS R3A, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'R4-B' THEN sup_ha END), 1), 0) AS R4B, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'FC' THEN sup_ha END), 1), 0) AS FC, ");
        str.Append("COALESCE(ROUND(SUM(CASE WHEN calif_pcu = 'S/D' THEN sup_ha END), 1), 0) AS SD, ");
        str.Append("ROUND(SUM(sup_ha), 1) AS total FROM( ");
        str.Append("SELECT m.clave_mun, m.descripcion AS municipio, r.calif_pcu, r.sup_ha ");
        str.Append("FROM (SELECT anio, cve_edo, cve_mun, calif_pcu, SUM(sup_ha) AS sup_ha ");
        str.Append("FROM renaret WHERE anio = " + anio + " AND mes = (select max(mes) from renaret where anio = " + anio + ") AND cve_edo = '" + clave_estado + "' ");
        str.Append("GROUP BY anio, mes, cve_edo, cve_mun, calif_pcu) r ");
        str.Append("LEFT JOIN c_entidad_federativa e ON r.cve_edo = e.clave ");
        str.Append("LEFT JOIN c_municipio m ON r.cve_edo = m.clave_entidad_federativa AND r.cve_mun = m.clave_mun) t GROUP BY clave_mun, municipio");
        List<RenaretVO> lstMunicipal = new List<RenaretVO>();
        System.Diagnostics.Debug.WriteLine(str.ToString());
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstMunicipal = (from DataRow row in dt.Rows
                          select new RenaretVO()
                          {
                              clave_area_geoestadistica = row["clave_municipio"].ToString(),
                              area_geoestadistica = row["municipio"].ToString(),
                              u1 = float.Parse(row["U1"].ToString()),
                              u2 = float.Parse(row["U2"].ToString()),
                              u3 = float.Parse(row["U3"].ToString()),
                              r4a = float.Parse(row["R4A"].ToString()),
                              r3a = float.Parse(row["R3A"].ToString()),
                              r4b = float.Parse(row["R4B"].ToString()),
                              fc = float.Parse(row["FC"].ToString()),
                              sd = float.Parse(row["SD"].ToString()),
                              total = float.Parse(row["total"].ToString())
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstMunicipal;
    }
}