using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

[DataContract]
public class MetaVO

{
    [DataMember(EmitDefaultValue = false)]
    public int anio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string programa { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string clave_estado { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estado { get; set; }

    [DataMember]
    public int autorizado { get; set; }
    [DataMember]
    public decimal monto_autorizado { get; set; }
    [DataMember]
    public int dispersado { get; set; }
    [DataMember]
    public decimal monto_dispersado { get; set; }
    [DataMember]
    public int meta { get; set; }
    [DataMember]
    public decimal monto_meta { get; set; }

    [DataMember]
    public int autorizado_meta { get; set; }
    [DataMember]
    public int dispersado_autorizado { get; set; }
    [DataMember]
    public int monto_autorizado_meta { get; set; }
    [DataMember]
    public int monto_dispersado_autorizado { get; set; }
}
