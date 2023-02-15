using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de ConaviVO
/// </summary>
[DataContract]
public class CurpVO 
{
    [DataMember(EmitDefaultValue = false)]
    public string id { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string curp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string paterno { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string materno { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nombre { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string sexo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string fecha_nacimiento { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nacionalidad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string entidad_nacimiento { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estatus_curp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public int id_archivo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estatus { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string error_consulta { get; set; }

    public CurpVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}