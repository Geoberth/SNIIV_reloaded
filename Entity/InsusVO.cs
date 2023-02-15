using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de InsusVO
/// </summary>
[DataContract]
public class InsusVO : CuboVO
{
    public string escolaridad { get; set; }
    public string estado_civil { get; set; }
    public string discapacidad { get; set; }
    public string condicion_indigena { get; set; }
    public string alfabetismo { get; set; }
    public string intentos_desalojo { get; set; }
    public string pavimentacion { get; set; }
    public string alumbrado { get; set; }
    public string transporte_publico { get; set; }
    public int? numero_integrantes { get; set; }
    public int? numero_cuartos { get; set; }
    public InsusVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}