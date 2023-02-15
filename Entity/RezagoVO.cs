using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de RezagoVO
/// </summary>
public class RezagoVO
{
    public int anio { get; set; }
    public string id_estado { get; set; }
    public string estado { get; set; }
    public string id_municipio { get; set; }
    public string municipio { get; set; }
    public int con_rezago { get; set; }
    public int sin_rezago { get; set; }
    public int total { get; set; }

    public RezagoVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}