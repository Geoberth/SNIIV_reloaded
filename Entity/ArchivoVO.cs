using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArchivoVO
/// </summary>
public class ArchivoVO
{
    public int id { get; set; }
    public int anio { get; set; }
    public int mes { get; set; }
    /*public string nombre
    {
        get { return Util.instancia().getMes(mes); }
        set { }
    }*/
    public string url { get; set; }

    public ArchivoVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}