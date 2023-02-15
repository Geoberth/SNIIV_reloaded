using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de CuboVO
/// </summary>
[DataContract]
public class DesarrolladorFovisssteVO
{
    [DataMember]
    public string esquema { get; set; }
    [DataMember]
    public string desarrollador { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public Int64 acciones { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public decimal monto { get; set; }

    public DesarrolladorFovisssteVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}