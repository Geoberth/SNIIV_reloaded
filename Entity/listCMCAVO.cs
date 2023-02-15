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
public class listCMCAVO
{

    [DataMember(EmitDefaultValue = false)]
    public string cveInmueble { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cveRecursoCalendario { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string mesProgramacion { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strMontoInversion { get; set; }


    public listCMCAVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}