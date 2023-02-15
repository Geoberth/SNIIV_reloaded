using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de BookMarkDAO
/// </summary>
public class BookMarkDAO
{
    private static BookMarkDAO _instancia = null;

    public static BookMarkDAO instancia()
    {
        return _instancia == null ? new BookMarkDAO() : _instancia;
    }

    public BookMarkDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public string seleccionar(int id)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select id, config_pivottable from bookmark where id = " + id);
        string config_pivottable = string.Empty;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            config_pivottable = (from DataRow row in dt.Rows 
                                 select row["config_pivottable"].ToString()).ToList<string>().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return config_pivottable;
    }
}