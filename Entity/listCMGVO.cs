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
public class listCMGVO
{
    [DataMember(EmitDefaultValue = false)]
    public string cveInmueble { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string numComite { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strFeAprobacion { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string denominacionProyecto { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string descripcion { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strTipoDanio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cveModalidad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strIdInciso { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strIdTipoApoyo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strBeneficiario { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strEdad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strSalario { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strBenIndigenas { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strBenDiscapacitados { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strLatitud { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strLongitud { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cveEstado { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cveMunicipio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string cveLocalidad { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nombreDocEvidenciaFotoInicio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string docBase64EvidenciaFotoInicio { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nombreDocEvidenciaFotoProceso { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string docBase64EvidenciaFotoProceso { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nombreDocEvidenciaFotoConcluida { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string docBase64EvidenciaFotoConcluida { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nombreDocActaEntrega { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string docBase64ActaEntrega { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strCveCancelacion { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string strJustificacionCancelacion { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string nombreDocCancelacion { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string docBase64Cancelacion { get; set; }

public listCMGVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}