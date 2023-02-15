using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de ViviendaSustentableVO
/// </summary>
[DataContract]
public class SiseviveVO
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
    public string tipologia_vivienda { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string clima { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string idg { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string programa { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string grupo { get; set; }
    /*[DataMember(EmitDefaultValue = false)]
    public double co2 { get; set; }*/
    [DataMember(EmitDefaultValue = false)]
    public string pcu { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string fecha_corte { get; set; }

    [DataMember]
    public Int64 viviendas { get; set; }

    public SiseviveVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}