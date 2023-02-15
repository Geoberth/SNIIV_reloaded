using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de InventarioVO
/// </summary>
[DataContract]
public class InventarioVO 
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
    public string avance_obra { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string segmento { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string segmento_uma { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tipo_vivienda { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string subsidio { get; set; }
    [DataMember]
    public Int64 viviendas { get; set; }

    public InventarioVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}