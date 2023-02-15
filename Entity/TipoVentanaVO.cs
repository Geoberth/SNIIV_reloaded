using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PrototipoVO
/// </summary>
public class TipoVentanaVO
{
       

    public string id { get; set; }
    public string Acristalamiento { get; set; }
    public string Valor_g { get; set; }
    public string Valor_Ug { get; set; }
    public string Valor_CS { get; set; }
    
    public TipoVentanaVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public TipoVentanaVO(string _id,
        string _acristalamiento,
        string _valor_g,
        string _valor_ug,
        string _valor_cs


        )
    {
        id = _id;
        Acristalamiento = _acristalamiento;
        Valor_g = _valor_g;
        Valor_Ug = _valor_ug;
        Valor_CS = _valor_cs;

    }
}