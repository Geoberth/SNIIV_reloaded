using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de FonhapoVO
/// </summary>
[DataContract]
public class FonhapoVO : CuboVO
{
    [DataMember(EmitDefaultValue = false)]
    public string promotor { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tipo_vivienda { get; set; }

    public FonhapoVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}