using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

public class CedulaRegistroDAO
{
    private static CedulaRegistroDAO _instancia = null;

    public static CedulaRegistroDAO instancia()
    {
        return _instancia == null ? new CedulaRegistroDAO() : _instancia;
    }

    public CedulaRegistroDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CedulaRegistroVO> seleccionarProyecto(int id_proyecto)
    {
        string str;
        str=("CALL sniiv.sp_consulta_proyecto(" + id_proyecto + ");");

        List<CedulaRegistroVO> lst = new List<CedulaRegistroVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new CedulaRegistroVO()
                   {
                       id = int.Parse(row["id"].ToString()),
                       folio = row["folio"].ToString(),
                       nombre = row["nombre"].ToString(),
                       anio = int.Parse(row["anio"].ToString()),
                       id_categoria = int.Parse(row["id_categoria"].ToString()),
                       categoria = row["categoria"].ToString(),
                       status = row["status"].ToString(),
                       calle = row["calle"].ToString(),
                       numero = row["numero"].ToString(),
                       responsable_proyecto = row["responsable_proyecto"].ToString(),
                       responsable_disenio = row["responsable_disenio"].ToString(),
                       responsable_ejecucion = row["responsable_ejecucion"].ToString(),
                       codigo_postal = row["codigo_postal"].ToString(),
                       clave_entidad_federativa= row["clave_entidad_federativa"].ToString(),
                       clave_municipio = row["clave_municipio"].ToString(),
                       clave_localidad = row["clave_localidad"].ToString(),
                       entidad = row["entidad"].ToString(),
                       municipio = row["municipio"].ToString(),
                       localidad = row["localidad"].ToString(),
                       total_vivienda_conjunto = row["total_vivienda_conjunto"].ToString(),
                     //  total_vivienda_premio = row["total_vivienda_premio"].ToString(),
                       latitud = row["latitud"].ToString(),
                       longitud = row["longitud"].ToString(),
                       id_tipologia  = row["id_tipologia"].ToString(),
                       tipologia = row["tipologia"].ToString(),
                       id_tipo_vivienda  = row["id_tipo_vivienda"].ToString(),
                       tipo_vivienda = row["tipo_vivienda"].ToString(),
                       descripcion_tipologia = row["descripcion_tipologia"].ToString(),
                       //  numero_etapa = row["numero_etapa"].ToString(),
                       //  modelo_existente = row["modelo_existente"].ToString(),

                       empresa_razon = row["empresa_razon"].ToString(),
                       empresa_rfc = row["empresa_rfc"].ToString(),
                       empresa_calle = row["empresa_calle"].ToString(),
                       empresa_numero = row["empresa_numero"].ToString(),
                       empresa_cp = row["empresa_cp"].ToString(),
                       empresa_clave_entidad = row["empresa_clave_entidad"].ToString(),
                       empresa_clave_municipio = row["empresa_clave_municipio"].ToString(),
                       empresa_clave_localidad = row["empresa_clave_localidad"].ToString(),
                       empresa_entidad = row["empresa_entidad"].ToString(),
                       empresa_municipio = row["empresa_municipio"].ToString(),
                       empresa_localidad = row["empresa_localidad"].ToString(),

                       enlace_nombre= row["enlace_nombre"].ToString(),
                       enlace_cargo = row["enlace_cargo"].ToString(),
                       enlace_celular = row["enlace_celular"].ToString(),
                       enlace_telefono = row["enlace_telefono"].ToString(),
                       enlace_correo = row["enlace_correo"].ToString(),

                       representante_nombre = row["representante_nombre"].ToString(),
                       representante_cargo = row["representante_cargo"].ToString(),
                       representante_celular = row["representante_celular"].ToString(),
                       representante_telefono = row["representante_telefono"].ToString(),
                       representante_correo = row["representante_correo"].ToString(),
                       fecha_hora = row["fecha"].ToString(),

                       fecha_registro = DateTime.Parse(row["fecha"].ToString())
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }



    //AlertaVO alerta;
    public int insertarCedula(CedulaRegistroVO cedula)
    {
        StringBuilder str = new StringBuilder();
        int id;
        
        str.Append("CALL sniiv.sp_insertar_cedula('"+ cedula.id_proyecto + "', ");
        str.Append("'" + cedula.calle + "', ");
        str.Append("'" + cedula.numero + "', ");
        str.Append("'" + cedula.codigo_postal + "', ");
        str.Append("'" + cedula.clave_entidad_federativa + "', ");
        str.Append("'" + cedula.clave_municipio + "', ");
        str.Append("'" + cedula.clave_localidad + "', ");
        str.Append("'" + cedula.responsable_proyecto + "', ");
        str.Append("'" + cedula.responsable_disenio + "', ");
        str.Append("'" + cedula.responsable_ejecucion + "'" + ")");

      /*str.Append("'" + cedula.responsable_ejecucion + "', ");
        str.Append("'" + cedula.total_vivienda_conjunto + "', ");
        str.Append("'" + cedula.latitud + "', ");
        str.Append("'" + cedula.longitud + "', ");
        str.Append("'" + cedula.numero_etapa + "', ");
        str.Append("'" + cedula.modelo_existente + "'" + ")");*/

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            id = Convert.ToInt32(dt.Rows[0][0].ToString());
            str = new StringBuilder();
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            id = 0;
        }

        return id;
    }


    public int actualizarGeorreferencia(CedulaRegistroVO cedula)
    {
        StringBuilder str = new StringBuilder();
        int id;

        str.Append("CALL sniiv.sp_actualizar_georreferencia('" + cedula.id_proyecto + "', ");
        str.Append("'" + cedula.total_vivienda_conjunto + "', ");
        //str.Append("'" + cedula.total_vivienda_premio + "', ");
        str.Append("'" + cedula.latitud + "', ");
        str.Append("'" + cedula.longitud + "', ");
        str.Append("'" + cedula.id_tipologia + "', ");
        str.Append("'" + cedula.id_tipo_vivienda + "', ");
        str.Append("'" + cedula.descripcion_tipologia + "'" + ")");

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            id = Convert.ToInt32(dt.Rows[0][0].ToString());
            str = new StringBuilder();
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            id = 0;
        }

        return id;
    }

    public int actualizarEmpresa(CedulaRegistroVO cedula)
    {
        StringBuilder str = new StringBuilder();
        int id;

        str.Append("CALL sniiv.sp_actualizar_empresa('" + cedula.id_proyecto + "', ");
        str.Append("'" + cedula.empresa_razon + "', ");
        str.Append("'" + cedula.empresa_rfc + "', ");
        str.Append("'" + cedula.empresa_calle + "', ");
        str.Append("'" + cedula.empresa_numero + "', ");
        str.Append("'" + cedula.empresa_cp + "', ");
        str.Append("'" + cedula.empresa_entidad + "', ");
        str.Append("'" + cedula.empresa_municipio + "', ");
        str.Append("'" + cedula.empresa_localidad+ "'" + ")");

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            id = Convert.ToInt32(dt.Rows[0][0].ToString());
            str = new StringBuilder();
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            id = 0;
        }

        str = new StringBuilder();

        str.Append("CALL sniiv.sp_actualizar_enlace('" + cedula.id_proyecto + "', ");
        str.Append("'" + cedula.enlace_nombre + "', ");
        str.Append("'" + cedula.enlace_cargo + "', ");
        str.Append("'" + cedula.enlace_celular + "', ");
        str.Append("'" + cedula.enlace_telefono + "', ");
        str.Append("'" + cedula.enlace_correo + "'); ");

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            id = Convert.ToInt32(dt.Rows[0][0].ToString());
            str = new StringBuilder();
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            id = 0;
        }

        str = new StringBuilder();

        str.Append("CALL sniiv.sp_actualizar_representante('" + cedula.id_proyecto + "', ");
        str.Append("'" + cedula.representante_nombre + "', ");
        str.Append("'" + cedula.representante_cargo + "', ");
        str.Append("'" + cedula.representante_celular + "', ");
        str.Append("'" + cedula.representante_telefono + "', ");
        str.Append("'" + cedula.representante_correo + "'); ");

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            id = Convert.ToInt32(dt.Rows[0][0].ToString());
            str = new StringBuilder();
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            id = 0;
        }

        return id;
    }

    public void insertarEmpresa(CedulaRegistroVO cedula)
    {
        StringBuilder str = new StringBuilder();
        str.Append("INSERT INTO cedula_ciudad_pnv ( id_proyecto, clave_entidad_federativa, clave_municipio, clave_localidad) VALUES ('" + cedula.id_proyecto +"' , '" + cedula.trabajo_entidad + "' , '" + cedula.trabajo_municipio + "', '" + cedula.trabajo_localidad + "');");

        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
          /*  alerta.text = "Cuestionario enviado correctamente.";
            alerta.type = AlertaVO.type_success;*/
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
           /* alerta.text = "Problemas al enviar cuestionario.";
            alerta.type = AlertaVO.type_danger;*/
        }
     
    }


    public void eliminarEmpresa(int ciudad_cedula)
    {
        StringBuilder str = new StringBuilder();
        str.Append("delete from cedula_ciudad_pnv  where id='" + ciudad_cedula + "';");

        try
        {
            Generico.instancia().eliminar(str.ToString(), Constante.BD_SNIIV);
            /*  alerta.text = "Cuestionario enviado correctamente.";
              alerta.type = AlertaVO.type_success;*/
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            /* alerta.text = "Problemas al enviar cuestionario.";
             alerta.type = AlertaVO.type_danger;*/
        }

    }

    public List<CedulaRegistroVO> getCedulaCiudad(int id_proyecto)
    {
        string str = " call sp_cedula_ciudad(" + id_proyecto + ");";
        List<CedulaRegistroVO> ciudad = new List<CedulaRegistroVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            ciudad = (from DataRow row in dt.Rows
                     select new CedulaRegistroVO()
                     {
                         id_cedula_ciudad = row["id"].ToString(),
                         trabajo_entidad = row["clave_entidad_federativa"].ToString(),
                         trabajo_municipio = row["clave_municipio"].ToString(),
                         trabajo_localidad = row["clave_localidad"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return ciudad;
    }

    public List<CatalogoVO> seleccionarTipologia()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select id, descripcion from c_tipo_vivienda_cedula");
        List<CatalogoVO> lstTipologia = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstTipologia = (from DataRow row in dt.Rows
                          select new CatalogoVO()
                          {
                              id = row["id"].ToString(),
                              descripcion = row["descripcion"].ToString()
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstTipologia;
    }

}
