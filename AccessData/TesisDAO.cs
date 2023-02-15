using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TesisDAO
{
    private static TesisDAO _instancia = null;

    public static TesisDAO instancia()
    {
        if (_instancia == null)
        {
            _instancia = new TesisDAO();
        }
        return _instancia;
    }

    public TesisDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int seleccionarIdTesis(int id_proyecto)
    {
        string str = "SELECT id FROM tesis_prnv WHERE id_proyecto = " + id_proyecto;
        int id = 0;

        try {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            if (dt.Rows.Count > 0)
                id = Convert.ToInt32(dt.Rows[0][0]);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return id;
    }

    public TesisVO seleccionarTesis(int id_tesis)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select id, id_proyecto, nombre, paterno, materno, fecha_nacimiento, nacionalidad+0 as nacionalidad, telefono, email, ");
        str.Append("calle, numero, colonia, cp, t.clave_entidad_federativa, t.clave_municipio, t.clave_localidad, ");
        str.Append("nombre_institucion, nombre_directores, nombre_codirectores, titulo, grado+0 as grado, fecha_grado ");
        str.Append(",grado as desc_grado,nacionalidad as desc_nacionalidad ,ef.descripcion as entidad ");
        str.Append(",mun.descripcion as municipio,lo.descripcion as localidad ");
        str.Append("from tesis_prnv t ");
        str.Append("left join c_entidad_federativa ef ");
        str.Append("on ef.clave = t.clave_entidad_federativa ");
        str.Append("left join c_municipio mun ");
        str.Append("on mun.clave = t.clave_municipio ");
        str.Append("and mun.clave_entidad_federativa = t.clave_entidad_federativa ");
        str.Append("left join c_localidad lo ");
        str.Append("on lo.clave = t.clave_localidad ");
        str.Append("and lo.clave_municipio = t.clave_municipio ");
        str.Append("and lo.clave_entidad_federativa = t.clave_entidad_federativa ");
        str.Append("where id = " + id_tesis);
        TesisVO tesis = null;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            tesis = (from DataRow row in dt.Rows
                     select new TesisVO()
                     {
                         id = Int32.Parse(row["id"].ToString()),
                         id_proyecto = Int32.Parse(row["id_proyecto"].ToString()),
                         nombre = row["nombre"].ToString(),
                         paterno = row["paterno"].ToString(),
                         materno = row["materno"].ToString(),
                         fecha_nacimiento = row["fecha_nacimiento"].ToString(),
                         nacionalidad = Int32.Parse(row["nacionalidad"].ToString()),
                         telefono = row["telefono"].ToString(),
                         email = row["email"].ToString(),
                         calle = row["calle"].ToString(),
                         numero = row["numero"].ToString(),
                         colonia = row["colonia"].ToString(),
                         cp = Int32.Parse(row["cp"].ToString()),
                         clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                         clave_municipio = row["clave_municipio"].ToString(),
                         clave_localidad = row["clave_localidad"].ToString(),
                         nombre_institucion = row["nombre_institucion"].ToString(),
                         nombre_directores = row["nombre_directores"].ToString(),
                         nombre_codirectores = row["nombre_codirectores"].ToString(),
                         titulo = row["titulo"].ToString(),
                         grado = Int32.Parse(row["grado"].ToString()),
                         fecha_grado = row["fecha_grado"].ToString(),
                         desc_nacionalidad = row["desc_nacionalidad"].ToString(),
                         desc_grado = row["desc_grado"].ToString(),
                         entidad = row["entidad"].ToString(),
                         municipio = row["municipio"].ToString(),
                         localidad = row["localidad"].ToString(),
                     }).ToList().First<TesisVO>();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return tesis;
    }

    public TesisVO seleccionarTesisProyecto(int id_tesis)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select id, id_proyecto, nombre, paterno, materno, fecha_nacimiento, nacionalidad+0 as nacionalidad, telefono, email, ");
        str.Append("calle, numero, colonia, cp, t.clave_entidad_federativa, t.clave_municipio, t.clave_localidad, ");
        str.Append("nombre_institucion, nombre_directores, nombre_codirectores, titulo, grado+0 as grado, fecha_grado ");
        str.Append(",grado as desc_grado,nacionalidad as desc_nacionalidad ,ef.descripcion as entidad ");
        str.Append(",mun.descripcion as municipio,lo.descripcion as localidad ");
        str.Append("from tesis_prnv t ");
        str.Append("left join c_entidad_federativa ef ");
        str.Append("on ef.clave = t.clave_entidad_federativa ");
        str.Append("left join c_municipio mun ");
        str.Append("on mun.clave = t.clave_municipio ");
        str.Append("and mun.clave_entidad_federativa = t.clave_entidad_federativa ");
        str.Append("left join c_localidad lo ");
        str.Append("on lo.clave = t.clave_localidad ");
        str.Append("and lo.clave_municipio = t.clave_municipio ");
        str.Append("and lo.clave_entidad_federativa = t.clave_entidad_federativa ");
        str.Append("where id_proyecto = " + id_tesis);
        TesisVO tesis = null;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            tesis = (from DataRow row in dt.Rows
                     select new TesisVO()
                     {
                         id = Int32.Parse(row["id"].ToString()),
                         id_proyecto = Int32.Parse(row["id_proyecto"].ToString()),
                         nombre = row["nombre"].ToString(),
                         paterno = row["paterno"].ToString(),
                         materno = row["materno"].ToString(),
                         fecha_nacimiento = row["fecha_nacimiento"].ToString(),
                         nacionalidad = Int32.Parse(row["nacionalidad"].ToString()),
                         telefono = row["telefono"].ToString(),
                         email = row["email"].ToString(),
                         calle = row["calle"].ToString(),
                         numero = row["numero"].ToString(),
                         colonia = row["colonia"].ToString(),
                         cp = Int32.Parse(row["cp"].ToString()),
                         clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                         clave_municipio = row["clave_municipio"].ToString(),
                         clave_localidad = row["clave_localidad"].ToString(),
                         nombre_institucion = row["nombre_institucion"].ToString(),
                         nombre_directores = row["nombre_directores"].ToString(),
                         nombre_codirectores = row["nombre_codirectores"].ToString(),
                         titulo = row["titulo"].ToString(),
                         grado = Int32.Parse(row["grado"].ToString()),
                         fecha_grado = row["fecha_grado"].ToString(),
                         desc_nacionalidad = row["desc_nacionalidad"].ToString(),
                         desc_grado = row["desc_grado"].ToString(),
                         entidad = row["entidad"].ToString(),
                         municipio = row["municipio"].ToString(),
                         localidad = row["localidad"].ToString(),
                     }).ToList().First<TesisVO>();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return tesis;
    }

    public bool insertarTesis(TesisVO tesis)
    {
        StringBuilder str = new StringBuilder();
        str.Append("INSERT INTO tesis_prnv(id_proyecto, nombre, paterno, materno, fecha_nacimiento, nacionalidad, telefono, email, ");
        str.Append("calle, numero, colonia, cp, clave_entidad_federativa, clave_municipio, clave_localidad, nombre_institucion, nombre_directores, nombre_codirectores, ");
        str.Append("titulo, grado, fecha_grado) ");
        str.Append("VALUES(" + tesis.id_proyecto + ", '" + tesis.nombre + "', '" + tesis.paterno + "', '" + tesis.materno + "', ");
        str.Append("'" + tesis.fecha_nacimiento + "', " + tesis.nacionalidad + ", '" + tesis.telefono + "', '" + tesis.email + "', ");
        str.Append("'" + tesis.calle + "', '" + tesis.numero + "', '" + tesis.colonia + "', " + tesis.cp + ", ");
        str.Append("'" + tesis.clave_entidad_federativa + "', '" + tesis.clave_municipio + "', '" + tesis.clave_localidad + "', ");
        str.Append("'" + tesis.nombre_institucion + "', '" + tesis.nombre_directores + "', '" + tesis.nombre_codirectores + "', ");
        str.Append("'" + tesis.titulo + "', " + tesis.grado + ", '" + tesis.fecha_grado + "')");
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

    public bool ActualizarTesis(TesisVO tesis)
    {
        StringBuilder str = new StringBuilder();
        str.Append("UPDATE tesis_prnv ");
        str.Append("SET nombre = '" + tesis.nombre + "', paterno = '" + tesis.paterno + "', materno = '" + tesis.materno + "', fecha_nacimiento = '" + tesis.fecha_nacimiento + "', ");
        str.Append("nacionalidad = " + tesis.nacionalidad + ", telefono = '" + tesis.telefono + "', email = '" + tesis.email + "', ");
        str.Append("calle = '" + tesis.calle + "', numero = '" + tesis.numero + "', colonia = '" + tesis.colonia + "', cp = " + tesis.cp + ", ");
        str.Append("clave_entidad_federativa = '" + tesis.clave_entidad_federativa + "', clave_municipio = '" + tesis.clave_municipio + "', clave_localidad = '" + tesis.clave_localidad + "', ");
        str.Append("nombre_institucion = '" + tesis.nombre_institucion + "', nombre_directores = '" + tesis.nombre_directores + "', nombre_codirectores = '" + tesis.nombre_codirectores + "', ");
        str.Append("titulo = '" + tesis.titulo + "', grado = " + tesis.grado + ", fecha_grado = '" + tesis.fecha_grado + "' ");
        str.Append("WHERE id = " + tesis.id);
        bool respuesta = false;

        try
        {
            Generico.instancia().actializar(str.ToString(), Constante.BD_SNIIV);
            respuesta = true; ;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }

        return respuesta;
    }

    public int seleccionarEdicion(int id_proyecto) {
        string str = "SELECT anio FROM proyecto_prnv WHERE id = " + id_proyecto;
        int anio = 0;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            if (dt.Rows.Count > 0)
                anio = Convert.ToInt32(dt.Rows[0][0]);
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return anio;
    }
}
