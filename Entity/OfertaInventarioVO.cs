using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de RegistroViviendaVO
/// </summary>
/// 
[DataContract]
public class OfertaInventarioVO
{
    [DataMember(EmitDefaultValue = false)]
    public string estado { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string segmento { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string segmento_uma { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string avance_obra { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tipo_vivienda { get; set; }
    [DataMember]
    public decimal viviendas { get; set; }

    public OfertaInventarioVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}