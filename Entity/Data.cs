using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de DataVO
/// </summary>
[DataContract]
public class Data
{
    [DataMember(EmitDefaultValue = false)]
    public int id { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string name { get; set; }
    [DataMember]
    public float value { get; set; }
    public Data()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}