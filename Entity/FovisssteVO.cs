using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de FovisssteVO
/// </summary>
[DataContract]
public class FovisssteVO : CuboVO
{
    [DataMember(EmitDefaultValue = false)]
    public string linea_credito { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string entidad_financiera { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string vivienda_sustentable { get; set; }

    public FovisssteVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}