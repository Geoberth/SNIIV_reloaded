using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de DatosAbiertosDAO
/// </summary>
public class DatosAbiertosDAO
{
    private static DatosAbiertosDAO _instancia = null;

    public static DatosAbiertosDAO instancia()
    {
        return _instancia == null ? new DatosAbiertosDAO() : _instancia;
    }

    public DatosAbiertosDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarAnio(int tipo)
    {
        string subsi;
        switch (tipo)
        {
            case 1:
                subsi = "Subsidios";
                break;
            case 2:
                subsi = "Financiamientos";
                break;
            case 3:
                subsi = "Oferta vivienda";
                break;
            case 4:
                subsi = "Registro vivienda";
                break;
            case 5:
                subsi = "Días inventario";
                break;
            case 6:
                subsi = "Padrón beneficiario";
                break;
            case 7:
                subsi = "CNBV";
                break;
            default:
                subsi = "Subsidios";
                break;
        }
        System.Diagnostics.Debug.WriteLine(subsi);
        string str = "select distinct anio as anio from datos_abiertos where tipo = '" + subsi + "' order by anio desc";

        System.Diagnostics.Debug.WriteLine(str);
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

    public List<CatalogoVO> seleccionarAnio_bak(int tipo)
    {
        string subsi;
        switch (tipo)
        {
            case 1:
                subsi = "Subsidios";
                break;
            case 2:
                subsi = "Financiamientos";
                break;
            case 3:
                subsi = "Oferta vivienda";
                break;
            case 4:
                subsi = "Registro vivienda";
                break;
            case 5:
                subsi = "Días inventario";
                break;
            case 6:
                subsi = "Padrón beneficiario";
                break;
            case 7:
                subsi = "CNBV";
                break;
            default:
                subsi = "Subsidios";
                break;
        }
        System.Diagnostics.Debug.WriteLine(subsi);
        string str = "select distinct anio as anio from datos_abiertos where tipo = '" + subsi + "' order by anio desc";

        System.Diagnostics.Debug.WriteLine(str);
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

    public List<CatalogoVO> seleccionarMes(int tipo, int anio)
    {
        string subsi;
        switch (tipo)
        {
            case 1:
                subsi = "Subsidios";
                break;
            case 2:
                subsi = "Financiamientos";
                break;
            case 3:
                subsi = "Oferta vivienda";
                break;
            case 4:
                subsi = "Registro vivienda";
                break;
            case 5:
                subsi = "Días inventario";
                break;
            case 6:
                subsi = "Padrón beneficiario";
                break;
            case 7:
                subsi = "CNBV";
                break;
            default:
                subsi = "Subsidios";
                break;
        }
        StringBuilder str = new StringBuilder();
        str.Append("select c.mes, m.descripcion from datos_abiertos c");
        str.Append(" join c_mes m on m.id = c.mes");
        str.Append(" where c.anio = " + anio + " and c.tipo = '" + subsi + "' ");
        str.Append(" group by c.mes, m.descripcion");
        str.Append(" order by c.mes desc");
        System.Diagnostics.Debug.WriteLine(str.ToString());
        List<CatalogoVO> meses = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            meses = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["mes"].ToString(),
                         descripcion = (tipo == 5 || tipo == 6 ? Util.instancia().getTrimestre(int.Parse(row["mes"].ToString())) : row["descripcion"].ToString())
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return meses;
    }

    public DataTable seleccionarRezago(int rezago)
    {
        DataTable dt = new DataTable();
        string str = "call sp_get_rezago("+ rezago + ");";
        try
        {
            dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);

        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }
}