using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DeeviVO
/// </summary>
public class DeeviVO
{
    public enum Tipo
    {
        original = 1,
        propuesta = 2
    }
    
    public Tipo tipo { get; set; }

    public string resultados_c35 { get; set; }
    public string resultados_g61 { get; set; }
    public string resultados_c65 { get; set; }

    public string comprobacion_c7 { get; set; }
    public string comprobacion_c9 { get; set; }
    public string comprobacion_k28 { get; set; }


    public string superficies_e28 { get; set; }
    public List<NombresVO> gv_nombres { get; set; }
    public List<PrototipoVO> superficies_prototipos { get; set; }
    public List<TipoVentanaVO> tipo_ventana { get; set; }
    public List<SombramientoTemporalVO> sombramiento_tmp { get; set; }

    public string ventanas_a23 { get; set; }
    public string ventanas_b23 { get; set; }
    public string ventanas_i23 { get; set; }

    public string tipo_ventana_g105 { get; set; }

    public string sombras_c9 { get; set; }
    public string sombras_c10 { get; set; }

    public string ventilacion_a11 { get; set; }
    public string ventilacion_a12 { get; set; }
    public string ventilacion_a13 { get; set; }
    public string ventilacion_g54 { get; set; }
    public string ventilacion_h54 { get; set; }
    public string ventilacion_i54 { get; set; }
    public string ventilacion_j54 { get; set; }


    public string ventilacion_v_d8 { get; set; }
    public string ventilacion_v_f24 { get; set; }
    public string ventilacion_v_h53 { get; set; }

    public string aparatos_r_b12 { get; set; }
    public string aparatos_r_b22 { get; set; }

    public string distribucion_acs_j9 { get; set; }
    public string distribucion_acs_h44 { get; set; }
    public string distribucion_acs_i44 { get; set; }
    public string distribucion_acs_i64 { get; set; }

    public string acs_solar_f14 { get; set; }
    public string acs_solar_f27 { get; set; }

    public string calentador_f26 { get; set; }

    public string valor_ep_f11 { get; set; }
    public string valor_ep_f36 { get; set; }
  
    

    public class Part : IEquatable<Part>
    {
        public int Id { get; set; }
        public string Columna { get; set; }
        public string Original { get; set; }
        public string Propuesta { get; set; }
 
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.Id.Equals(other.Id));
        }

    }

    public DeeviVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //

    }
}