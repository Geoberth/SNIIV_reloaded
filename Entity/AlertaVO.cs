using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de ArchivoDatosAbiertosVO
/// </summary>
public class AlertaVO
{
    //Hacerlo con Enum
    public static string type_success { get { return "alert alert-success alert-dismissible"; } }
    public static string type_info { get { return "alert alert-info alert-dismissible"; } }
    public static string type_warning { get { return "alert alert-warning alert-dismissible"; } }
    public static string type_danger { get { return "alert alert-danger alert-dismissible"; } }
    public string text { get; set; }
    public string type { get; set; }

    public AlertaVO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public AlertaVO(string _text, string _type)
    {
        text = _text;
        type = _type;
    }
}