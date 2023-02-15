using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de ConaviVO
/// </summary>
//[DataContract]
public class ConaviVO : CuboVO
{
    //[DataMember(EmitDefaultValue = false)]
    public string entidad_ejecutora { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string tipo_entidad_ejecutora { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string organismo_ejecutor_obra { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string tipo_vivienda { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string desarrollo_certificado { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string vivienda_sustentable { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string pcu { get; set; }

    public ConaviVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}