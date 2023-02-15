using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ParqueHabitacionalVO
/// </summary>
public class ParqueHabitacionalVO
{
    public string clave_area_geoestadistica { get; set; }
    public string area_geoestadistica { get; set; }
    public int habitada { get; set; }
    public int deshabitada { get; set; }
    public int uso_temporal { get; set; }
    public int total { get; set; }
    // Actualmente el archivo fuente tiene total
    /*
    public float total {
        get { return u1 + u2 + u3 + r4a + r3a + r4b + fc + sd; }
        set { }
    }
    */

    public ParqueHabitacionalVO()
    {
        clave_area_geoestadistica = string.Empty;
        area_geoestadistica = string.Empty;
        habitada = 0;
        deshabitada = 0;
        uso_temporal = 0;
        total = 0;
    }
}