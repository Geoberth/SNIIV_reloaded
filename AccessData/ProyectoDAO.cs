using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProyectoDAO
{
    private static ProyectoDAO _instancia = null;

    public static ProyectoDAO instancia()
    {
        if (_instancia == null)
        {
            _instancia = new ProyectoDAO();
        }
        return _instancia;
    }

    public ProyectoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<CatalogoVO> seleccionarCategorias()
    {
        string str = "select id, descripcion from c_categoria_prnv";
        List<CatalogoVO> categorias = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            categorias = (from DataRow row in dt.Rows
                          select new CatalogoVO()
                          {
                              id = row["id"].ToString(),
                              descripcion = row["descripcion"].ToString()
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return categorias;
    }

    public List<CatalogoVO> seleccionarMenciones()
    {
        string str = "select id, descripcion from c_mencion_prnv";
        List<CatalogoVO> categorias = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            categorias = (from DataRow row in dt.Rows
                          select new CatalogoVO()
                          {
                              id = row["id"].ToString(),
                              descripcion = row["descripcion"].ToString()
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return categorias;
    }

    public DataTable seleccionarProyectos()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select p.id, p.folio, p.nombre, p.anio, p.id_categoria, c.descripcion as categoria,");
        str.Append(" p.id_status, s.descripcion as status, p.fecha, u.usuario as correo, u.telefono");
        str.Append(" from proyecto_prnv p");
        str.Append(" join c_categoria_prnv c on p.id_categoria = c.id");
        str.Append(" join c_status_prnv s on p.id_status = s.id");
        str.Append(" join usuario u on p.id_usuario = u.id");
        str.Append(" where u.id_status = " + Constante.ACTIVO);

        DataTable dt = new DataTable();

        try { dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV); }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }

    public List<ProyectoVO> seleccionarProyectos(int id_usuario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select p.id, p.folio, p.nombre, p.anio, p.id_categoria, c.descripcion as categoria, p.id_status, s.descripcion as status, p.fecha ");
        str.Append("from proyecto_prnv p ");
        str.Append("join c_categoria_prnv c on p.id_categoria = c.id ");
        str.Append("join c_status_prnv s on p.id_status = s.id ");
        str.Append("where p.id_usuario = " + id_usuario);
        List<ProyectoVO> lst = new List<ProyectoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new ProyectoVO()
                   {
                       id = int.Parse(row["id"].ToString()),
                       folio = row["folio"].ToString(),
                       nombre = row["nombre"].ToString(),
                       anio = int.Parse(row["anio"].ToString()),
                       id_categoria = int.Parse(row["id_categoria"].ToString()),
                       categoria = row["categoria"].ToString(),
                       id_status = int.Parse(row["id_status"].ToString()),
                       status = row["status"].ToString(),
                       fecha_registro = DateTime.Parse(row["fecha"].ToString())
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public List<ProyectoVO> seleccionarEvaluacionExtra(int id_proyecto)
    {
        string str = "call sp_evaluacion_extra("+id_proyecto+");";
        List<ProyectoVO> lst = new List<ProyectoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new ProyectoVO()
                   {
                       id = int.Parse(row["id_proyecto"].ToString()),
                       nombre = row["nombre_completo"].ToString(),
                       valor_extra = int.Parse(row["valor_extra"].ToString()),
                       descripcion_extra = row["descripcion_extra"].ToString(),
                       calificacion_criterios = decimal.Parse(row["calificacion_criterios"].ToString()),
                       mencion = row["mencion"].ToString(),
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }
    /*
    public List<ProyectoVO> seleccionarProyectos(int id_usuario, int id_categoria)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select p.id, p.folio, p.nombre, p.anio, p.id_categoria, c.descripcion as categoria, p.id_status, s.descripcion as status, p.fecha ");
        str.Append("from proyecto_prnv p ");
        str.Append("join c_categoria_prnv c on p.id_categoria = c.id ");
        str.Append("join c_status_prnv s on p.id_status = s.id ");
        str.Append("where p.id_usuario = " + id_usuario + " and p.id_categoria = " + id_categoria);
        List<ProyectoVO> lst = new List<ProyectoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new ProyectoVO()
                   {
                       id = int.Parse(row["id"].ToString()),
                       folio = row["folio"].ToString(),
                       nombre = row["nombre"].ToString(),
                       anio = int.Parse(row["anio"].ToString()),
                       id_categoria = int.Parse(row["id_categoria"].ToString()),
                       categoria = row["categoria"].ToString(),
                       id_status = int.Parse(row["id_status"].ToString()),
                       status = row["status"].ToString(),
                       fecha_registro = DateTime.Parse(row["fecha"].ToString())
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }
    */
    public List<ProyectoVO> seleccionarProyectosCategoria(int id_categoria, int id_usuario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select p.id, p.folio, p.nombre, p.anio, p.id_categoria, c.descripcion as categoria, p.id_status, s.descripcion as status, ");
        str.Append("p.fecha, COALESCE(e.calificacion_criterios, 0) AS calificacion_criterios, COALESCE(m.id_mencion, 0) as id_mencion, m.descripcion as motivo_mencion, cm.descripcion as mencion ");
        str.Append("from proyecto_prnv p ");
        str.Append("join c_categoria_prnv c on p.id_categoria = c.id ");
        str.Append("join c_status_prnv s on p.id_status = s.id ");
        str.Append("join usuario u on p.id_usuario = u.id ");
        str.Append("left join proyecto_mencion m on p.id = m.id_proyecto AND m.id_evaluador = " + id_usuario);
        str.Append(" left join c_mencion_prnv cm on m.id_mencion = cm.id ");
        str.Append(" left join proyecto_evaluacion_extra e on p.id = e.id_proyecto AND e.id_evaluador = " + id_usuario);
        str.Append(" where p.id_categoria = " + id_categoria + " and p.id_status = " + Constante.ESTATUS_PROYECTO_FINALIZADO + " and u.id_status = " + Constante.ACTIVO);
        List<ProyectoVO> lst = new List<ProyectoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new ProyectoVO()
                   {
                       id = int.Parse(row["id"].ToString()),
                       folio = row["folio"].ToString(),
                       nombre = row["nombre"].ToString(),
                       anio = int.Parse(row["anio"].ToString()),
                       id_categoria = int.Parse(row["id_categoria"].ToString()),
                       categoria = row["categoria"].ToString(),
                       id_status = int.Parse(row["id_status"].ToString()),
                       status = row["status"].ToString(),
                       fecha_registro = DateTime.Parse(row["fecha"].ToString()),
                       calificacion_criterios = decimal.Parse(row["calificacion_criterios"].ToString()),
                       mencion = row["mencion"].ToString(),
                       id_mencion = int.Parse(row["id_mencion"].ToString()),
                       motivo_mencion = row["motivo_mencion"].ToString()
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public bool insertarProyecto(ProyectoVO proyecto)
    {
        StringBuilder str = new StringBuilder();
        str.Append("INSERT INTO proyecto_prnv (folio, nombre, anio, id_categoria, id_usuario) ");
        str.Append("VALUES('" + proyecto.folio + "', '" + proyecto.nombre + "', " + proyecto.anio + ", '" + proyecto.id_categoria + "', '" + proyecto.id_usuario + "')");

        bool respuesta = false;
        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
        }

        return respuesta;
    }

    public bool eliminarProyecto(int id_proyecto)
    {
        string str = "DELETE FROM proyecto_prnv WHERE id = " + id_proyecto;
        bool respuesta = false;
        try
        {
            Generico.instancia().eliminar(str, Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }

        return respuesta;
    }

    public bool finalizarProyecto(int id_proyecto)
    {
        string str = "UPDATE proyecto_prnv SET id_status = 2 WHERE id = " + id_proyecto;
        bool respuesta = false;
        try
        {
            Generico.instancia().actializar(str, Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }

        return respuesta;
    }

    public bool insertarMencion(ProyectoVO proyecto)
    {
        bool respuesta = false;
        string str = "INSERT INTO proyecto_mencion (id_proyecto, id_evaluador, id_mencion, descripcion) VALUES(" + proyecto.id + ", " + proyecto.id_usuario + ", " + proyecto.id_mencion + ", '" + proyecto.mencion + "')";
        try {
            Generico.instancia().insertar(str, Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return respuesta;
    }

    public bool eliminarMencion(ProyectoVO proyecto)
    {
        bool respuesta = false;
        string str = "DELETE FROM proyecto_mencion WHERE id_proyecto = " + proyecto.id + " AND id_evaluador = " + proyecto.id_usuario;
        try {
            Generico.instancia().eliminar(str, Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return respuesta;
    }

    public int contarMencion(int id_evaluador)
    {
        int contador = 0;
        string str = "SELECT COUNT(id_proyecto) AS completo FROM proyecto_mencion WHERE id_evaluador = " + id_evaluador;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            contador = Convert.ToInt32(dt.Rows[0][0].ToString());
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return contador;
    }

    public List<ProyectoVO> seleccionarEvaluacion(string calificado)
    {
        string str = "call sp_evaluacion_prnv("+calificado+")";
        List<ProyectoVO> lst = new List<ProyectoVO>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new ProyectoVO()
                   {
                       id = int.Parse(row["id"].ToString()),
                       folio = row["folio"].ToString(),
                       correo = row["correo"].ToString(),
                       nombre = row["nombre"].ToString(),
                       edicion = row["edicion"].ToString(),
                       categoria = row["categoria"].ToString(),
                       numero_vivienda = row["numero_vivienda"].ToString(),
                       entidad = row["entidad"].ToString(),
                       municipio = row["municipio"].ToString(),
                       mencion= row["mencion"].ToString(),
                       valor_extra = decimal.Parse(row["valor_extra"].ToString()),
                       calificacion_criterios = decimal.Parse(row["calificacion_criterios"].ToString()),
                       calificacion_encuesta = decimal.Parse(row["calificacion_encuesta"].ToString()),
                       calificacion_final = decimal.Parse(row["calificacion_final"].ToString()),
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public bool calificarProyecto(int proyecto, Decimal[] calificacion)
    {
        eliminarCalificacionProyecto(proyecto);
        string query;
        decimal calificacion_final = 0;
        int elemento_vivienda = 0;
        for (var i = 0; i < calificacion.Length; i++)
        {
            elemento_vivienda = elemento_vivienda + 1;
            query = "INSERT INTO proyecto_elemento (id_proyecto,id_elemento_vivienda,calificacion) values (" + proyecto + "," + elemento_vivienda + "," + calificacion[i] + ");";
            calificacion_final = calificacion_final + calificacion[i];
            try
            {
                Generico.instancia().insertar(query, Constante.BD_SNIIV);
            }
            catch (Exception ex) { Util.instancia().setLogError(ex); }

        }
        if (calificacion_final >= Convert.ToDecimal(39.97))
        {
            calificacion_final = Convert.ToDecimal(40.0);
        }
        string str = "UPDATE proyecto_prnv SET calificacion_encuesta = " + calificacion_final + " WHERE id = " + proyecto;
        bool respuesta = false;
        try
        {
            Generico.instancia().actializar(str, Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return respuesta;
    }

    public bool eliminarCalificacionProyecto(int id_proyecto)
    {
        string str = "DELETE FROM proyecto_elemento WHERE id_proyecto = " + id_proyecto;
        bool respuesta = false;
        try
        {
            Generico.instancia().eliminar(str, Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return respuesta;
    }

    public ProyectoVO cargarElementosVivienda(int id_proyecto)
    {
        string str;
        str = ("CALL sp_elemento_vivienda(" + id_proyecto + ");");
        ProyectoVO lst = null;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new ProyectoVO()
                   {
                       certeza = decimal.Parse(row["certeza"].ToString()),
                       disponibilidad = decimal.Parse(row["disponibilidad"].ToString()),
                       asequibilidad = decimal.Parse(row["asequibilidad"].ToString()),
                       habitabilidad = decimal.Parse(row["habitabilidad"].ToString()),
                       accesibilidad = decimal.Parse(row["accesibilidad"].ToString()),
                       ubicacion = decimal.Parse(row["ubicacion"].ToString()),
                       adecuacion = decimal.Parse(row["adecuacion"].ToString()),
                       total = decimal.Parse(row["total"].ToString()),
                       url = row["url"].ToString(),

                   }).ToList().First<ProyectoVO>();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public DataTable seleccionarEvaluacionExport()
    {
        DataTable dt = new DataTable();
        string str = "call sp_evaluacion_excel();";
        try
        {
            dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);

        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return dt;
    }
}

