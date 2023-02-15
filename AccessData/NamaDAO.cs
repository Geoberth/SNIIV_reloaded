using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for UsuarioDAO
/// </summary>
public class NamaDAO
{
    private static NamaDAO _instancia = null;

    public static NamaDAO instancia()
    {
        if (_instancia == null)
        {
            _instancia = new NamaDAO();
        }
        return _instancia;
    }

    public NamaDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //Utilizar el siguente query cuando se requiera el  modulo de usuario
    /*INSERT INTO usuario(nombre, paterno, materno, usuario, pass, id_status, id_rol) 
    VALUES('David', 'Romero', 'Gomez', 'Admin', AES_ENCRYPT('@dmin***', get_clave_crypt_pass()), 1, 1);*/

    public int insertDocs(string original, string propuesta,int idusuario) {
        StringBuilder str = new StringBuilder();
        StringBuilder strdoc = new StringBuilder();
        str.Append("INSERT INTO nama.documento (original,propuesta) values ('"+original+"','"+propuesta+"');");
        str.Append("INSERT INTO nama.usuario_documento (id_usuario,id_documento,fecha_alta) values (" + idusuario + ",(SELECT LAST_INSERT_ID()),now());");
        str.Append("SELECT max(id_documento)as id from nama.usuario_documento where id_usuario" + idusuario+ ";");
        int usr = 0;
        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_NAMA);
           
                 
        }
        catch (Exception ex)
        {
            var error = ex;
        }
      
        return usr;
    }

  


    public int updateError(int error, int idusuario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("CALL sp_error(" + idusuario+","+ error+");");
        int usr = 0;
        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_NAMA);

        }
        catch (Exception ex)
        {
            var err = ex;
        }
        return usr;
    }

    public DocumentoVO findDocs(int idusuario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select id,original,propuesta from documento");
        str.Append(" where id =(select max(id_documento) as iddoc  ");
        str.Append(" from nama.usuario_documento where id_usuario = "+idusuario+")");
        DocumentoVO doc = null;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_NAMA);
            doc = (from DataRow row in dt.Rows
                   select new DocumentoVO()
                   {
                       id = Int32.Parse(row["id"].ToString()),
                       original = row["original"].ToString(),
                       propuesta = row["propuesta"].ToString(),
                   }).ToList().First<DocumentoVO>();
        }
        catch (Exception ex)
        {
            var error = ex;
        }
        return doc;
    }

}