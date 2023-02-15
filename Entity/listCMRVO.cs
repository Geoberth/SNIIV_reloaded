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
public class listCMRVO
{
    [DataMember(EmitDefaultValue = false)]
    public string cveInmueble { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cveRecurso { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strProgramado { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strEjercido { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strAvanceFisico { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string anioMesInicio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string anioMesTermino { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strMontoAutorizado { get; set; }
 

public listCMRVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}