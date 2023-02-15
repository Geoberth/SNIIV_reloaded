using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de CuboVO
/// </summary>
//[DataContract]
public class CuboVO
{
    //[DataMember]
    public int año { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string mes { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string estado { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string municipio { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string modalidad { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string esquema { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string sexo { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string grupo_edad { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string rango_salarial { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string valor_vivienda { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string programa_presupuestal { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string linea_apoyo { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string zona { get; set; }
    //[DataMember(EmitDefaultValue = false)]
    public string poblacion_indigena { get; set; }

    //[DataMember]
    public Int64 acciones { get; set; }
    //[DataMember]
    public decimal monto { get; set; }

    public CuboVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}