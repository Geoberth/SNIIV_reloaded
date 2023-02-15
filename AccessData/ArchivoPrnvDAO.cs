using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArchivoPrnvDAO
{
    private static ArchivoPrnvDAO _instancia = null;

    public static ArchivoPrnvDAO instancia()
    {
        if (_instancia == null)
        {
            _instancia = new ArchivoPrnvDAO();
        }
        return _instancia;
    }

    public ArchivoPrnvDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool insertarArchivos(List<ArchivoPrnvVO> archivos)
    {
        StringBuilder str = new StringBuilder();
        foreach (ArchivoPrnvVO archivo in archivos)
            str.Append("INSERT INTO archivo_prnv (id_proyecto, url, id_tipo) VALUES (" + archivo.id_proyecto + ", '" + archivo.url + "', " + archivo.id_tipo + ");");
        bool respuesta = false;

        try {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            respuesta = ProyectoDAO.instancia().finalizarProyecto(archivos.First().id_proyecto);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }

        return respuesta;
    }

    public bool insertarEvidencia(List<ArchivoPrnvVO> archivos)
    {
        StringBuilder str = new StringBuilder();
        foreach (ArchivoPrnvVO archivo in archivos)
            str.Append("INSERT INTO archivo_prnv (id_proyecto, url, id_tipo) VALUES (" + archivo.id_proyecto + ", '" + archivo.url + "', " + archivo.id_tipo + ");");
        bool respuesta = false;

        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            //  respuesta = ProyectoDAO.instancia().finalizarProyecto(archivos.First().id_proyecto);
            respuesta = true;
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }

        return respuesta;
    }

    public bool eliminarEvidencia(int id_proyecto)
    {
        string str = "DELETE FROM archivo_prnv WHERE id_proyecto = " + id_proyecto +" and id_tipo=16";
        bool respuesta = false;
        try
        {
            Generico.instancia().eliminar(str, Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }

        return respuesta;
    }

}
