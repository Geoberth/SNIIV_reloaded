using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArchivoDatosAbiertosVO
/// </summary>
public class DatosAbiertosVO : ArchivoVO
{
    public enum Tipo
    {
        subsidios = 1,
        financiamientos = 2,
        oferta_vivienda = 3,
        registro_vivienda = 4,
        dias_inventario = 5,
        padron_beneficiario= 6,
        cnbv = 7
    }
    public int tipo { get; set; }

    public DatosAbiertosVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}