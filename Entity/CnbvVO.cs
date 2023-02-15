using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de CnbvVO
/// </summary>
[DataContract]
public class CnbvVO : CuboVO
{
    [DataMember(EmitDefaultValue = false)]
    public string linea_credito { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string intermediario_financiero { get; set; }

    public CnbvVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}