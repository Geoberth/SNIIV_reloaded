using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de ArchivoCurpVO
/// </summary>
[DataContract]
public class ArchivoCurpVO
{
    [DataMember(EmitDefaultValue = false)]
    public string id { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string archivo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string fecha { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estatus { get; set; }
   

    public ArchivoCurpVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}