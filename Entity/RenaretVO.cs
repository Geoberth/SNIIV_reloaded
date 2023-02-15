using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de RenaretVO
/// </summary>
public class RenaretVO
{
    public string clave_area_geoestadistica { get; set; }
    public string area_geoestadistica { get; set; }
    public float u1 { get; set; }
    public float u2 { get; set; }
    public float u3 { get; set; }
    public float r4a { get; set; }
    public float r3a { get; set; }
    public float r4b { get; set; }
    public float fc { get; set; }
    public float sd { get; set; }
    public float total { get; set; }
    // Actualmente el archivo fuente tiene total
    /*
    public float total {
        get { return u1 + u2 + u3 + r4a + r3a + r4b + fc + sd; }
        set { }
    }
    */

    public RenaretVO()
    {
        clave_area_geoestadistica = string.Empty;
        area_geoestadistica = string.Empty;
        u1 = 0;
        u2 = 0;
        u3 = 0;
        r4a = 0;
        r3a = 0;
        r4b = 0;
        fc = 0;
        sd = 0;
    }
}