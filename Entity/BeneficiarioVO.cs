using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for BeneficiarioVO
/// </summary>
[DataContract]
public class BeneficiarioVO
{
    [DataMember]
    public int id { get; set; }
    [DataMember]
    public string folio_conavi { get; set; }
    [DataMember]
    public string curp { get; set; }
    [DataMember]
    public string paterno { get; set; }
    [DataMember]
    public string materno { get; set; }
    [DataMember]
    public string nombre { get; set; }
    [DataMember]
    public string calle { get; set; }
    [DataMember]
    public string numero_interior { get; set; }
    [DataMember]
    public string numero_exterior { get; set; }
    [DataMember]
    public string codigo_postal { get; set; }
    [DataMember]
    public string clave_entidad_federativa { get; set; }
    //[DataMember]
    //public string entidad_federativa { get; set; }
    [DataMember]
    public string clave_municipio { get; set; }
    //[DataMember]
    //public string municipio { get; set; }
    [DataMember]
    public string clave_localidad { get; set; }
    [DataMember]
    public string latitud { get; set; }
    [DataMember]
    public string longitud { get; set; }
    [DataMember]
    public int id_tipo_intervencion { get; set; }
    //[DataMember]
    //public string tipo_intervencion { get; set; }
    [DataMember]
    public string monto_intervencion { get; set; }
    [DataMember]
    public string monto_asistente { get; set; }
    [DataMember]
    public string clave_asistente_tecnico { get; set; }
    [DataMember]
    public int id_comite_financiamiento { get; set; }
    [DataMember]
    public int id_comite_evaluacion { get; set; }
    [DataMember]
    public string estatus { get; set; }
    [DataMember]
    public string persona { get; set; }
    [DataMember]
    public string descargado { get; set; }
    [DataMember]
    public int id_programa { get; set; }
    //[DataMember]
    //public string programa { get; set; }
    [DataMember]
    public int explosion_insumos { get; set; }
    [DataMember]
    public string observaciones { get; set; }
    [DataMember]
    public string fecha_captura { get; set; }
    [DataMember]
    public bool material_vivienda { get; set; }
    [DataMember]
    public string material_lugar { get; set; }
    [DataMember]
    public int id_paquete_insumo { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public List<InsumoVO> insumos { get; set; }

    public enum estatusPaquete
    {
        pendiente = 1,
        asignado = 2
    }
    public string nombreCompleto { get { return nombre + " " + paterno + " " + materno; } }

    public BeneficiarioVO()
    {
        id = 0;
        folio_conavi = string.Empty;
        curp = string.Empty;
        paterno = string.Empty;
        materno = string.Empty;
        nombre = string.Empty;
        calle = string.Empty;
        numero_interior = string.Empty;
        numero_exterior = string.Empty;
        codigo_postal = string.Empty;
        clave_entidad_federativa = string.Empty;
        //entidad_federativa = string.Empty;
        clave_municipio = string.Empty;
        //municipio = string.Empty;
        clave_localidad = string.Empty;
        latitud = string.Empty;
        longitud = string.Empty;
        id_tipo_intervencion = 0;
        //tipo_intervencion = string.Empty;
        monto_intervencion = string.Empty;
        monto_asistente = string.Empty;
        clave_asistente_tecnico = string.Empty;
        id_comite_financiamiento = 0;
        id_comite_evaluacion = 0;
        estatus = string.Empty;
        persona = string.Empty;
        descargado = string.Empty;
        id_programa = 0;
        //programa = string.Empty;
        explosion_insumos = 2;
        observaciones = string.Empty;
        fecha_captura = string.Empty;
        material_vivienda = false;
        material_lugar = string.Empty;
        id_paquete_insumo = 0;
        insumos = new List<InsumoVO>();
    }
}