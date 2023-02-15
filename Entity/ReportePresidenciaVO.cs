using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de ViviendaSustentableVO
/// </summary>
[DataContract]
public class ReportePresidenciaVO
{
    [DataMember(EmitDefaultValue = false)]
    public string fecha { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string comite { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string modalidad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string linea_apoyo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string vertiente { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string rango_edad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string genero { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string clave_estado { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estado { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string clave_municipio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string municipio { get; set; }

    [DataMember]
    public decimal beneficiarios { get; set; }
    [DataMember]
    public decimal monto { get; set; }

    public ReportePresidenciaVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}