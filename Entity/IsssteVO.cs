using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de IsssteVO
/// </summary>
/// 
[DataContract]
public class IsssteVO
{
    [DataMember]
    public int año { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string mes { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estado { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string sexo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string rango_salarial { get; set; }
    [DataMember]
    public Int64 trabajadores { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nombramiento { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string rango_antiguedad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string sector { get; set; }
    public IsssteVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}