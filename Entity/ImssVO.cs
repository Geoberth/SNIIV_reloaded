using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de ImssVO
/// </summary>
[DataContract]
public class ImssVO
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
    public string sector_economico { get; set; }
    /*[DataMember(EmitDefaultValue = false)]
    public string tipo_sector_economico { get; set; }*/
    [DataMember(EmitDefaultValue = false)]
    public string sexo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string grupo_edad { get; set; }
    /*[DataMember(EmitDefaultValue = false)]
    public string rango_vsm { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string rango_uma { get; set; }*/
    [DataMember(EmitDefaultValue = false)]
    public string rango_salarial { get; set; }

    [DataMember]
    public Int64 trabajadores { get; set; }

    public ImssVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}