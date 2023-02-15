using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ReconstruccionVO
/// </summary>
public class LevantamientoVO
{
    public string clave_entidad_federativa { get; set; }
    public string entidad { get; set; }
    public string clave_municipio { get; set; }
    public string municipio { get; set; }
    public string modalidad { get; set; }
    public string programa { get; set; }
    public int meta { get; set; }
    public int avance { get; set; }
  
    public LevantamientoVO()
    {
        clave_entidad_federativa = string.Empty;
        entidad = string.Empty;
        clave_municipio = string.Empty;
        municipio = string.Empty;
        modalidad = string.Empty;
        programa = string.Empty;
        meta = 0;
        avance = 0;
    }

}