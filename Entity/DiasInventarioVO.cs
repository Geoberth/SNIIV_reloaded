using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DiasInventarioVO
/// </summary>
public class DiasInventarioVO
{
    public string clave_entidad_federativa { get; set; }
    public string entidad { get; set; }
    public string clave_municipio { get; set; }
    public string municipio { get; set; }
    public int registro { get; set; }
    public int construccion { get; set; }
    public int venta { get; set; }
    public int total { get; set; }
    public int numero_vivienda { get; set; }
    // Actualmente el archivo fuente tiene total
    /*
    public float total {
        get { return u1 + u2 + u3 + r4a + r3a + r4b + fc + sd; }
        set { }
    }
    */

    public DiasInventarioVO()
    {
        clave_entidad_federativa = string.Empty;
        entidad = string.Empty;
        clave_municipio = string.Empty;
        municipio = string.Empty;
        registro = 0;
        construccion = 0;
        venta = 0;
        total = 0;
        numero_vivienda = 0;
    }

}