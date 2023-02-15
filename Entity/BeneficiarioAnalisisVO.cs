using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

[DataContract]
public class BeneficiarioAnalisisVO

{
    [DataMember(EmitDefaultValue = false)]
    public int id { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string programa { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string grupo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estado { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string municipio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string paterno { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string materno { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nombre { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string curp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string linea { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string sesion { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string acu { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string fecha { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public int activo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estatus { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estatus_pago { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string hitoria { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public decimal acciones { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public decimal monto { get; set; }

    [DataMember]
    public decimal monto_autorizado { get; set; }
    [DataMember]
    public decimal monto_dispersado { get; set; }
    [DataMember]
    public decimal monto_dispersar { get; set; }
    /*
    [DataMember(EmitDefaultValue = false)]
    public decimal monto_reintegrado { get; set; }
    */
    [DataMember(EmitDefaultValue = false)]
    public string proceso { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string obra { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string supervisor { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string proyecto { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string capacitacion { get; set; }
}
