using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PrototipoVO
/// </summary>
public class PrototipoVO
{
    public string id_prototipo { get; set; }
    public string sre { get; set; }
    public string orientacion_1 { get; set; }
    public string orientacion_2 { get; set; }
    public string orientacion_3 { get; set; }
    public string orientacion_4 { get; set; }
    public string orientacion_5 { get; set; }
    public string orientacion_6 { get; set; }
    public string orientacion_7 { get; set; }
    public string orientacion_8 { get; set; }
    public string orientacion_9 { get; set; }
    public string orientacion_10 { get; set; }
    public string orientacion_11 { get; set; }
    public string orientacion_12 { get; set; }

    public PrototipoVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public PrototipoVO(string _idprototipo,
        string _sre,
        string _orientacion_1,
        string _orientacion_2,
        string _orientacion_3,
        string _orientacion_4,
        string _orientacion_5,
        string _orientacion_6,
        string _orientacion_7,
        string _orientacion_8,
        string _orientacion_9,
        string _orientacion_10,
        string _orientacion_11,
        string _orientacion_12
        ) {
        id_prototipo = _idprototipo;
        sre = _sre;
        orientacion_1 = _orientacion_1;
        orientacion_2 = _orientacion_2;
        orientacion_3 = _orientacion_3;
        orientacion_4 = _orientacion_4;
        orientacion_5 = _orientacion_5;
        orientacion_6 = _orientacion_6;
        orientacion_7 = _orientacion_7;
        orientacion_8 = _orientacion_8;
        orientacion_9 = _orientacion_9;
        orientacion_10 = _orientacion_10;
        orientacion_11 = _orientacion_11;
        orientacion_12 = _orientacion_12;
    }
}