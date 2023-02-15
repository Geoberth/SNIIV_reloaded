using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for InsumosVO
/// </summary>
[DataContract]
public class InsumoVO
{
    [DataMember]
    public int id { get; set; }
    [DataMember]
    public string codigo { get; set; }
    [DataMember]
    public string descripcion  { get; set; }
    [DataMember]
    public string detalle { get; set; }
    [DataMember]
    public string unidad_medida { get; set; }
    [DataMember]
    public int cantidad { get; set; }
    [DataMember]
    public int cantidad_2 { get; set; }
    [DataMember]
    public int cantidad_3 { get; set; }
    [DataMember]
    public float precio { get; set; }
    [DataMember]
    public bool activo { get; set; }
    [DataMember]
    public string codigo_grupo { get; set; }

    public InsumoVO()
    {
        id = 0;
        codigo = string.Empty;
        descripcion = string.Empty;
        unidad_medida = string.Empty;
        cantidad = 0;
        cantidad_2 = 0;
        cantidad_3 = 0;
        precio = 0;
        activo = false;
        codigo_grupo = string.Empty;
    }
}