using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//[DataContract]
public class TesisVO
{
    public enum Nacionalidad
    {
        mexicana = 1,
        extranjera = 2
    }
    public enum Grado
    {
        maestria = 1,
        doctorado = 2
    }
    //[DataMember(EmitDefaultValue = false)]
    public int id { get; set; }
    public int id_proyecto { get; set; }

    public string nombre { get; set; }
    public string paterno { get; set; }
    public string materno { get; set; }
    public string fecha_nacimiento { get; set; }
    public int nacionalidad { get; set; }
    public string desc_nacionalidad { get; set; }
    public string telefono { get; set; }
    public string email { get; set; }
    public string calle { get; set; }
    public string numero { get; set; }
    public string colonia { get; set; }
    public int cp { get; set; }
    public string clave_entidad_federativa { get; set; }
    public string clave_municipio { get; set; }
    public string clave_localidad { get; set; }
    public string entidad { get; set; }
    public string municipio { get; set; }
    public string localidad { get; set; }
    public string nombre_institucion { get; set; }
    public string nombre_directores { get; set; }
    public string nombre_codirectores { get; set; }

    public string titulo { get; set; }
    public int grado { get; set; }
    public string desc_grado { get; set; }
    public string fecha_grado { get; set; }
}