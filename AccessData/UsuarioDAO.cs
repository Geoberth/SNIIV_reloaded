using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


/// <summary>
/// Summary description for UsuarioDAO
/// </summary>
public class UsuarioDAO
{
    private static UsuarioDAO _instancia = null;

    public static UsuarioDAO instancia()
    {
        if (_instancia == null)
        {
            _instancia = new UsuarioDAO();
        }
        return _instancia;
    }

    public UsuarioDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool insertarUsuario(UsuarioVO usuario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("INSERT INTO usuario(nombre, paterno, materno, usuario, telefono, pass, id_status, id_rol) ");
        str.Append("VALUES('" + usuario.nombre + "', '" + usuario.paterno + "', '" + usuario.materno + "', '" + usuario.usuario + "', '" + usuario.telefono + "', ");
        str.Append("AES_ENCRYPT('" + usuario.password + "', get_clave_crypt_pass()), " + usuario.idEstatus + ", " + usuario.idRol + ")");
        
        bool respuesta = false;
        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            respuesta = true; ;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }

        return respuesta;
    }

    public bool validarNombreUsuario(string nombre_usuario)
    {
        string str = "SELECT id FROM usuario WHERE usuario = '" + nombre_usuario + "' AND id_status = " + (int)UsuarioVO.tipoEstatus.activo;
        bool existe = false;
        try
        {
            int id = Generico.instancia().seleccionar(str, Constante.BD_SNIIV).Rows.Count;
            existe = id != 0 ? true : false;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }
        return existe;
    }

    public UsuarioVO loginUsuario(string txtUsr, string txtPsw) {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT id, nombre, paterno, materno, usuario, telefono, id_status, id_rol, ");
        str.Append("pass AS psw, clave_asistente_tecnico ");
        str.Append("FROM usuario WHERE usuario = '" + txtUsr + "' ");
        str.Append("AND id_status = " + (int)UsuarioVO.tipoEstatus.activo);
        UsuarioVO usr = null;
        
        

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            usr = (from DataRow row in dt.Rows
                   select new UsuarioVO()
                   {
                       id = Int32.Parse(row["id"].ToString()),
                       nombre = row["nombre"].ToString(),
                       paterno = row["paterno"].ToString(),
                       materno = row["materno"].ToString(),
                       usuario = row["usuario"].ToString(),
                       telefono = row["telefono"].ToString(),
                       password = row["psw"].ToString(),
                       idEstatus = Int32.Parse(row["id_status"].ToString()),
                       idRol = Int32.Parse(row["id_rol"].ToString()),
                       clave_asistente_tecnico = row["clave_asistente_tecnico"].ToString()
                   }).ToList().First<UsuarioVO>();
            
            
        }
        catch (Exception ex)
        {
            var error = ex;
        }
        return usr;
    }

    public List<ModuloVO> getModulos(int id_rol) {
        StringBuilder str = new StringBuilder();
        str.Append("select id, descripcion, url, ico ");
        str.Append("from rol_modulo rm ");
        str.Append("join c_modulo m on m.id = rm.id_modulo ");
        str.Append("where rm.id_rol = " + id_rol);
        List<ModuloVO> lst = new List<ModuloVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new ModuloVO()
                   {
                       id = int.Parse(row["id"].ToString()),
                       text = row["descripcion"].ToString(),
                       url = row["url"].ToString(),
                       ico = row["ico"].ToString()
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public List<UsuarioVO> getUsuariosPrnv()
    {
        string str = "select id, nombre, paterno, materno, usuario, telefono, fecha_alta from usuario where id_rol = " + Constante.ROL_CAPTURA_PROYECTO + " and id_status = " + (int)UsuarioVO.tipoEstatus.activo;
        List<UsuarioVO> lst = new List<UsuarioVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new UsuarioVO()
                   {
                       id = int.Parse(row["id"].ToString()),
                       nombre = row["nombre"].ToString(),
                       paterno = row["paterno"].ToString(),
                       materno = row["materno"].ToString(),
                       usuario = row["usuario"].ToString(),
                       telefono = row["telefono"].ToString(),
                       fecha_alta = row["fecha_alta"].ToString()
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public List<UsuarioVO> getUsuariosPrnv(int id_categoria)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select u.id, u.nombre, u.paterno, u.materno, u.usuario, u.fecha_alta");
        str.Append(" from usuario u");
        str.Append(" join proyecto_prnv pp on u.id = pp.id_usuario");
        str.Append(" where u.id_rol = " + Constante.ROL_CAPTURA_PROYECTO + " and u.id_status = " + (int)UsuarioVO.tipoEstatus.activo);
        str.Append(" and pp.id_categoria = " + id_categoria + " and pp.id_status = " + Constante.ESTATUS_PROYECTO_FINALIZADO);
        str.Append(" group by u.id");
        List<UsuarioVO> lst = new List<UsuarioVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new UsuarioVO()
                   {
                       id = int.Parse(row["id"].ToString()),
                       nombre = row["nombre"].ToString(),
                       paterno = row["paterno"].ToString(),
                       materno = row["materno"].ToString(),
                       usuario = row["usuario"].ToString(),
                       fecha_alta = row["fecha_alta"].ToString()
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public void resetPass(int id_usuario)
    {
        StringBuilder str = new StringBuilder();
        str.Append(" update usuario set pass=AES_ENCRYPT(fn_cambiar_pass(id), get_clave_crypt_pass())  where id=" + id_usuario + ";");

        try
        {
            Generico.instancia().actializar(str.ToString(), Constante.BD_SNIIV);
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }

    }

    public int actualizarPass(int id_usuario,string pass)
    {
        int id=0;
        StringBuilder str = new StringBuilder();
        str.Append("call sp_actualizar_password("+ id_usuario + ", '" + pass + "');");

        try
        {
           
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            id = Convert.ToInt32(dt.Rows[0][0].ToString());
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }
        return id;
    }

    public UsuarioEvaluadorVO getUsuarioEvaluadorPrnv(UsuarioVO usuario)
    {
        string str = "select id_evaluador, id_categoria from usuario_evaluador where id_usuario = " + usuario.id;
        UsuarioEvaluadorVO usr = null;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            usr = (from DataRow row in dt.Rows
                   select new UsuarioEvaluadorVO()
                   {
                       id = usuario.id,
                       nombre = usuario.nombre,
                       paterno = usuario.paterno,
                       materno = usuario.materno,
                       usuario = usuario.usuario,
                       password = usuario.password,
                       idEstatus = usuario.idEstatus,
                       idRol = usuario.idRol,
                       clave_asistente_tecnico = usuario.clave_asistente_tecnico,
                       idEvaluador = Int32.Parse(row["id_evaluador"].ToString()),
                       idCategoria = Int32.Parse(row["id_categoria"].ToString())
                   }).ToList().First<UsuarioEvaluadorVO>();
        }
        catch (Exception ex)
        {
            var error = ex;
        }
        return usr;
    }
}