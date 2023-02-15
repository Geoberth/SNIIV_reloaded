using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de FideVO
/// </summary>
public class FideVO
{
    public string clave_entidad_federativa { get; set; }
    public string entidad { get; set; }
    public string clave_municipio { get; set; }
    public string municipio { get; set; }
    public int sistema_fotovoltaico { get; set; }
    public int calentador_gas { get; set; }
    public int calentador_solar { get; set; }
    public int aire_acondicionado { get; set; }
    public int aislamiento_termico { get; set; }
    public int ventana_termica { get; set; }
    public int pelicula_control_solar { get; set; }
    public int luminaria_eficiente { get; set; }
    public int mejora_estructural { get; set; }
    public float co2 { get; set; }
    public float monto { get; set; }
    public float acciones { get; set; }
    public int total { get; set; }
    // Actualmente el archivo fuente tiene total
    /*
    public float total {
        get { return u1 + u2 + u3 + r4a + r3a + r4b + fc + sd; }
        set { }
    }
    */

    public FideVO()
    {
        clave_entidad_federativa = string.Empty;
        entidad = string.Empty;
        clave_municipio = string.Empty;
        municipio = string.Empty;
        sistema_fotovoltaico = 0;
        calentador_gas = 0;
        calentador_solar = 0;
        aire_acondicionado = 0;
        aislamiento_termico = 0;
        ventana_termica = 0;
        pelicula_control_solar = 0;
        luminaria_eficiente = 0;
        mejora_estructural = 0;
        co2 = 0;
        monto = 0;
        acciones = 0;
        total = 0;
    }

}