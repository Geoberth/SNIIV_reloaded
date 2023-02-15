using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PrototipoVO
/// </summary>
public class NombresVO
{
    public string namegvPrototipo { get; set; }
    public string namegvSuperficieRef { get; set; }
    public string namegvOrientacion { get; set; }
    public string namegvTipoVentana { get; set; }
    

    public NombresVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public NombresVO(string namegvPrototipo,
          string namegvSuperficieRef,
          string namegvOrientacion,
          string namegvTipoVentana


        )
    {
        namegvPrototipo = "gvPrototipo";
        namegvSuperficieRef = "gvSuperficieRef";
        namegvOrientacion = "gvOrientacion";
        namegvTipoVentana = "gvTipoVentana";
        
    }
}