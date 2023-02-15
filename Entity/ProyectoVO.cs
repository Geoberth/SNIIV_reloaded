using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//[DataContract]
public class ProyectoVO
{
    //[DataMember(EmitDefaultValue = false)]
    public int id { get; set; }
    public string folio { get; set; }
    public string correo { get; set; }
    public string nombre { get; set; }
    public string edicion { get; set; }
    public int anio { get; set; }
    public int id_categoria { get; set; }
    public string categoria { get; set; }
    public int id_status { get; set; }
    public string numero_vivienda { get; set; }
    public string status { get; set; }
    public int id_usuario { get; set; }
    public DateTime fecha_registro { get; set; }
    public decimal calificacion_criterios { get; set; }
    public decimal calificacion_encuesta { get; set; }
    public decimal calificacion_final { get; set; }
    public string entidad { get; set; }
    public string municipio { get; set; }
    //Mencion honorifica
    public int id_mencion { get; set; }
    public string mencion { get; set; }
    public string motivo_mencion { get; set; }
    //Elemento vivienda
    public decimal certeza { get; set; }
    public decimal disponibilidad { get; set; }
    public decimal asequibilidad { get; set; }
    public decimal habitabilidad { get; set; }
    public decimal accesibilidad { get; set; }
    public decimal ubicacion { get; set; }
    public decimal adecuacion { get; set; }
    public decimal total { get; set; }
    public string url { get; set; }
    //Evaluación Extra
    public decimal valor_extra { get; set; }
    public string descripcion_extra { get; set; }
    
}
