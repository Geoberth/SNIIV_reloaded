using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsuarioVO
/// </summary>
public class UsuarioVO
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string paterno { get; set; }
    public string materno { get; set; }
    public string usuario { get; set; }
    public string telefono { get; set; }
    public string password { get; set; }
    public int idEstatus { get; set; }
    public string fecha_alta { get; set; }
    public List<ModuloVO> modulos { get; set; }
    public string clave_asistente_tecnico { get; set; }

    public enum tipoEstatus {
        activo = 1,
        inactivo = 2
    }
    public int idRol { get; set; }

    public string nombreCompleto { get { return nombre + " " + paterno + " " + materno; } }

    public UsuarioVO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}