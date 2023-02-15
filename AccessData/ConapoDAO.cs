using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ConapoDAO
/// </summary>
public class ConapoDAO
{
    private static ConapoDAO _instancia = null;

    public static ConapoDAO instancia()
    {
        return _instancia == null ? new ConapoDAO() : _instancia;
    }

    public ConapoDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable seleccionarPoblacionEstatal()
    {
        string str = "call sp_get_poblacion_estatal()";
        DataTable dt = new DataTable();

        try
        {
            dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }

    public DataTable seleccionarPoblacionMunicipal(string clave_estado)
    {
        string str = "call sp_get_poblacion_municipal(" + clave_estado + ")";
        DataTable dt = new DataTable();

        try
        {
            dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }
}