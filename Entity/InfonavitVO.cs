using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de InfonavitVO
/// </summary>
[DataContract]
public class InfonavitVO : CuboVO
{
    [DataMember(EmitDefaultValue = false)]
    public string estado_civil { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string linea_credito { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tipo_credito { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string intermediario_financiero { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string vivienda_sustentable { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string vivienda { get; set; }

    public InfonavitVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}