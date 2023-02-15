using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de ArchivoVO
/// </summary>
public class ArchivoPrnvVO
{
    public enum Tipo
    {
        carta_postulacion = 1,
        carta_originalidad = 2,
        carta_aceptacion = 3,
        resumen_trabajo = 4,
        resumen_ejecutivo = 5,
        tesis = 6,
        titulo = 7,
        adicional = 8,
        proyecto_urbano=9,
        proyecto_arquitectonico = 10,
        plano_instalaciones = 11,
        plano_estructural = 12,
        memoria_descriptiva = 13,
        memoria_calculo = 14,
        esquema_financiero = 15,
        evidencia=16
    }

    public int id { get; set; }
    public int id_proyecto { get; set; }
    public string url { get; set; }
    public int id_tipo { get; set; }

    public ArchivoPrnvVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}
