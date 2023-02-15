using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de Options
/// </summary>
[DataContract]
public class Option
{
    [DataMember]
    public List<Serie> series { get; set; }
    [DataMember]
    public List<string> legend { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public List<string> xAxis { get; set; }

    public Option()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
        series = new List<Serie>();
        legend = new List<string>();
    }
}