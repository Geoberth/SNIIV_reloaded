using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de CurpDAO
/// </summary>
public class CurpDAO
{
    private static CurpDAO _instancia = null;

    public static CurpDAO instancia()
    {
        return _instancia == null ? new CurpDAO() : _instancia;
    }

    public CurpDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public string insertarArchivo(string filename, int id_usuario)
    {
        String id_archivo = string.Empty;
        try
        {
            StringBuilder str = new StringBuilder();
            str.Append("call sp_inserta_archivo_curp ('" + filename + "'");
            str.Append("," + id_usuario + ");");
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            id_archivo = dt.Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }
        return id_archivo;
    }
    public void insertarCurp(string curp, string id_archivo)
    {
        try
        {
            StringBuilder str = new StringBuilder();
            str.Append("insert into consulta_curp(curp,id_archivo) ");
            str.Append(" values ('" + curp + "'");
            str.Append("," + id_archivo + ")");
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);

        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }
    }
    public List<ArchivoCurpVO> getArchivoCurp(int id_usuario)
    {
        string str = " call sp_consulta_archivos(" + id_usuario + ");";
        List<ArchivoCurpVO> curps = new List<ArchivoCurpVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            curps = (from DataRow row in dt.Rows
                     select new ArchivoCurpVO()
                     {
                         id = row["id"].ToString(),
                         archivo = row["archivo"].ToString(),
                         fecha = row["fecha"].ToString(),
                         estatus = row["estatus"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return curps;
    }

    public List<CurpVO> getConsultaCurp(int id_usuario, int estatus, int id_archivo)
    {
        string str = "call sp_consulta_curp(" + id_usuario + "," + estatus + "," + id_archivo + ")";
        List<CurpVO> curps = new List<CurpVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            curps = (from DataRow row in dt.Rows
                     select new CurpVO()
                     {
                         id = row["id"].ToString(),
                         curp = row["curp"].ToString(),
                         paterno = row["paterno"].ToString(),
                         materno = row["materno"].ToString(),
                         nombre = row["nombre"].ToString(),
                         sexo = row["sexo"].ToString(),
                         fecha_nacimiento = row["fecha_nacimiento"].ToString(),
                         nacionalidad = row["nacionalidad"].ToString(),
                         entidad_nacimiento = row["entidad_nacimiento"].ToString(),
                         estatus_curp = row["estatus_curp"].ToString(),
                         error_consulta = row["error_consulta"].ToString(),
                         id_archivo = Convert.ToInt32(row["id_archivo"]),
                         estatus = row["estatus"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return curps;
    }

    public void actualizarCurp(string curp, string paterno, string materno, string nombre, string sexo, string fecha, string nacionalidad, string entidad_nacimiento, string estatus_curp, int id_archivo)
    {

        try
        {
            StringBuilder str = new StringBuilder();
            str.Append("update consulta_curp set  paterno='" + paterno + "'");
            str.Append(",materno='" + materno + "'");
            str.Append(",nombre='" + nombre + "'");
            str.Append(",sexo='" + sexo + "'");
            str.Append(",fecha_nacimiento='" + fecha + "'");
            str.Append(",nacionalidad='" + nacionalidad + "'");
            str.Append(",entidad_nacimiento='" + entidad_nacimiento + "'");
            str.Append(",estatus_curp='" + estatus_curp + "'");
            str.Append(",estatus=1");
            str.Append(" where curp='" + curp + "'");
            str.Append(" and id_archivo=" + id_archivo + ";");

            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }
    }

    public void actualizarError(string curp, string error_consulta, int id_archivo)
    {

        try
        {
            StringBuilder str = new StringBuilder();
            str.Append("update consulta_curp set error_consulta='" + error_consulta + "'");
            str.Append(",estatus=1");
            str.Append(" where curp='" + curp + "'");
            str.Append(" and id_archivo=" + id_archivo + ";");

            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }
    }

}