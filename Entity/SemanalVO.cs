using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de FinanciamientosVO
/// </summary>
//[DataContract]
public class SemanalVO
{
    //[DataMember(EmitDefaultValue = false)]
    public int año { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string estado { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string organismo { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string modalidad { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string tipo_modalidad { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string subprograma { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public int semana { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string region { get; set; }

    //[DataMember]
    public Int64 acciones { get; set; }
    //[DataMember]
    public decimal monto { get; set; }

    public SemanalVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}
