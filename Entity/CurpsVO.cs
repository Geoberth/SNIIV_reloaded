using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de ConaviVO
/// </summary>
[DataContract]
public class CurpsVO
{
    
[DataMember(EmitDefaultValue = false)]
    public string nombres { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string apellido1 { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string apellido2 { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nacionalidad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string fechNac { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string sexo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cveEntidadNac { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string docProbatorio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string numEntidadReg { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cveMunicipioReg { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string anioReg { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string numActa { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string foja { get; set; }


    [DataMember(EmitDefaultValue = false)]
    public string libro { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tomo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string statusCurp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cveEntidadEmisora { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string statusOper { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string message { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nr_descEntidadNac { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nr_descDocProbatorio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nr_descEntidadReg { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nr_descMunicipioReg { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nr_descStatusCurp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nr_descTipoStatusCurp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string curp { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string curphistorica { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string codigoError { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string crip { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string folioCarta { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string numRegExtranjeros { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string tipoError { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string sessionID { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string estatus { get; set; }

    public CurpsVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}