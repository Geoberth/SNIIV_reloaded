using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de FideDAO
/// </summary>
public class FideDAO
{
    private static FideDAO _instancia = null;

    public static FideDAO instancia()
    {
        return _instancia == null ? new FideDAO() : _instancia;
    }

    public FideDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarAnio()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select distinct anio");
        str.Append(" from fide");
        str.Append(" order by anio desc;");
        List<CatalogoVO> anios = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
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
        str.Append(" select 13 as mes,'Acumulado' as descripcion");
        str.Append(" union all");
        str.Append(" select distinct(mes) as mes ");
        str.Append(" ,m.descripcion ");
        str.Append(" from fide f ");
        str.Append(" join sniiv.c_mes m ");
        str.Append(" on m.id = f.mes ");
        str.Append(" where anio = " + anio);
        str.Append(" order by mes desc;");
        List <CatalogoVO> mes = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            mes = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["mes"].ToString(),
                         descripcion = row["descripcion"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return mes;
    }

    public List<FideVO> seleccionarEstatal(int anio, int mes)
    {      
        StringBuilder str = new StringBuilder();
        str.Append(" call sp_fide_estatal("+anio+","+mes+"); ");
     
        List <FideVO> lstEstatal = new List<FideVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstEstatal = (from DataRow row in dt.Rows
                        select new FideVO()
                        {
                            clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                            entidad = row["entidad"].ToString(),
                            sistema_fotovoltaico = int.Parse(row["sistema_fotovoltaico"].ToString()),
                            calentador_gas = int.Parse(row["calentador_gas"].ToString()),
                            calentador_solar = int.Parse(row["calentador_solar"].ToString()),
                            aire_acondicionado = int.Parse(row["aire_acondicionado"].ToString()),
                            aislamiento_termico = int.Parse(row["aislamiento_termico"].ToString()),
                            ventana_termica = int.Parse(row["ventana_termica"].ToString()),
                            pelicula_control_solar = int.Parse(row["pelicula_control_solar"].ToString()),
                            luminaria_eficiente = int.Parse(row["luminaria_eficiente"].ToString()),
                            mejora_estructural = int.Parse(row["mejora_estructural"].ToString()),
                            co2 = float.Parse(row["co2"].ToString()),
                            monto = float.Parse(row["monto"].ToString()),
                            acciones = float.Parse(row["acciones"].ToString()),
                            total = int.Parse(row["total"].ToString()),
                        }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstEstatal;
    }

    public List<FideVO> seleccionarMunicipal(int anio, int mes, string clave_entidad_federativa)
    {
        StringBuilder str = new StringBuilder();
        str.Append("call sp_fide_municipal("+anio+","+mes+","+clave_entidad_federativa+"); ");

        List <FideVO> lstMunicipal = new List<FideVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstMunicipal = (from DataRow row in dt.Rows
                          select new FideVO()
                          {
                              clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                              clave_municipio = row["clave_municipio"].ToString(),
                              municipio = row["municipio"].ToString(),
                              sistema_fotovoltaico = int.Parse(row["sistema_fotovoltaico"].ToString()),
                              calentador_gas = int.Parse(row["calentador_gas"].ToString()),
                              calentador_solar = int.Parse(row["calentador_solar"].ToString()),
                              aire_acondicionado = int.Parse(row["aire_acondicionado"].ToString()),
                              aislamiento_termico = int.Parse(row["aislamiento_termico"].ToString()),
                              ventana_termica = int.Parse(row["ventana_termica"].ToString()),
                              pelicula_control_solar = int.Parse(row["pelicula_control_solar"].ToString()),
                              luminaria_eficiente = int.Parse(row["luminaria_eficiente"].ToString()),
                              mejora_estructural = int.Parse(row["mejora_estructural"].ToString()),
                              co2 = float.Parse(row["co2"].ToString()),
                              monto = float.Parse(row["monto"].ToString()),
                              acciones = float.Parse(row["acciones"].ToString()),
                              total = int.Parse(row["total"].ToString()),
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstMunicipal;
    }
}