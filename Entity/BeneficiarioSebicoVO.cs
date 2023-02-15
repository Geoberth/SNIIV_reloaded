using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

[DataContract]
public class BeneficiarioSebicoVO

{
    [DataMember(EmitDefaultValue = false)]
    public DateTime fecha_registro { get; set; }
    [DataMember]
    public int id { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string curp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string entidad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string municipio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string localidad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string calle { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string colonia { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string numero_exterior { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string numero_interior { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string telefono { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nombre { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string paterno { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string materno { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string ingreso_mensual_hogar { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string integrantes_ingreso_hogar { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string num_ext { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string num_int { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string cantidad_individual { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cantidad_integrantes { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string derechohabiente { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tipo_vivienda { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string situacion_vivienda { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string propietario { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string num_personas { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string num_indigenas { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string num_discapacitados { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string num_menores { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string num_madres_solteras { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string madre_soltera { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string num_cuartos { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string num_recamaras { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string alto_riesgo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string riesgo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string seguridad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string agua { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string sanitario { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cocina { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string electricidad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string pared { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string techo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string piso { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tipo_apoyo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string uso_mejoramiento { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string uso_ampliacion { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string uso_mejoramiento2 { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string uso_ampliacion2 { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string total_ampliacion { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string total_mejoramiento { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string estatus_curp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estatus_sap { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estatus_eligibilidad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estatus_priorizacion { get; set; }

}