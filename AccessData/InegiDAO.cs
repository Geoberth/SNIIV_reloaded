using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de InegiDAO
/// </summary>
public class InegiDAO
{
    private static InegiDAO _instancia = null;

    public static InegiDAO instancia()
    {
        return _instancia == null ? new InegiDAO() : _instancia;
    }

    public InegiDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable seleccionarPoblacionEstatal()
    {
        string str = "call sp_get_poblacion_inegi_estatal()";
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
        string str = "call sp_get_poblacion_inegi_municipal(" + clave_estado + ")";
        DataTable dt = new DataTable();

        try
        {
            dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }
}