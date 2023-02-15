using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de CnbvVO
/// </summary>
[DataContract]
public class ShfVO : CuboVO
{
    [DataMember(EmitDefaultValue = false)]
    public string intermediario_financiero { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tipo_ingreso { get; set; }

    public ShfVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}
