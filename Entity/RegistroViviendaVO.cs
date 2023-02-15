using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de RegistroViviendaVO
/// </summary>
/// 
[DataContract]
public class RegistroViviendaVO
{
    [DataMember]
    public int año { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string mes { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estado { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string municipio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string pcu { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string segmento { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string segmento_uma { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tipo_vivienda { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string superficie { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string recamara { get; set; }

    [DataMember]
    public Int64 viviendas { get; set; }

    public RegistroViviendaVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}