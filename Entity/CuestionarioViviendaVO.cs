using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CuestionarioViviendaVO
{
    public enum Tipo
    {
        tipo = 1,
        situacion = 2,
        riesgo = 3,
        seguridad = 4,
        agua = 5,
        banio = 6,
        cocina = 7,
        electricidad = 8,
        paredes = 9,
        techo = 10,
        piso = 11,
        mejoramiento = 12,
        ampliacion = 13,
        necesidad = 14
    }

    public int id { get; set; }
    public int id_usuario { get; set; }
    public string clave_estado { get; set; }
    public string clave_municipio { get; set; }
    public string clave_localidad { get; set; }
    public string direccion { get; set; }
    public string telefono { get; set; }
    public string curp { get; set; }
    public int id_tipo { get; set; }
    public int id_situacion { get; set; }
    public int id_riesgo { get; set; }
    public int id_seguridad { get; set; }
    public int id_agua { get; set; }
    public int id_banio { get; set; }
    public int id_cocina { get; set; }
    public int id_electricidad { get; set; }
    public int id_paredes { get; set; }
    public int id_techo { get; set; }
    public int id_piso { get; set; }
    public int id_mejoramiento { get; set; }
    public int id_ampliacion { get; set; }
    public int id_necesidad { get; set; }

    public CuestionarioViviendaVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}
