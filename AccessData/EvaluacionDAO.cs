using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EvaluacionDAO
{
    private static EvaluacionDAO _instancia = null;

    public static EvaluacionDAO instancia()
    {
        return _instancia == null ? new EvaluacionDAO() : _instancia;
    }

    public EvaluacionDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public bool insertar(List<EvaluacionVO> evaluaciones)
    {
        bool respuesta;
        StringBuilder str = new StringBuilder();
        try
        {
            respuesta = eliminar(evaluaciones.First().id_proyecto, evaluaciones.First().id_evaluador);
            if (respuesta)
            {
                foreach (EvaluacionVO evaluacion in evaluaciones)
                {
                    str.Append("INSERT INTO proyecto_evaluacion (id_proyecto, id_evaluador, id_criterio_evaluacion, valor) ");
                    str.Append("VALUES (" + evaluacion.id_proyecto + ", " + evaluacion.id_evaluador + ", " + evaluacion.id_criterio_evaluacion + ", " + evaluacion.valor + ");");
                }
                Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
                respuesta = true;
            }

        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }
        return respuesta;
    }
    public bool eliminar(int id_proyecto, int id_evaluador)
    {
        bool respuesta;
        string str = "delete from proyecto_evaluacion where id_proyecto = " + id_proyecto + " and id_evaluador = " + id_evaluador;
        try
        {
            Generico.instancia().eliminar(str, Constante.BD_SNIIV);
            respuesta = true; ;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }
        return respuesta;
    }

    public bool insertarExtra(EvaluacionVO evaluacion)
    {
        bool respuesta;
        StringBuilder str = new StringBuilder();
        try
        {
            respuesta = eliminarExtra(evaluacion.id_proyecto, evaluacion.id_evaluador);
            if (respuesta)
            {
                str.Append("INSERT INTO proyecto_evaluacion_extra (id_proyecto, id_evaluador, valor_extra, descripcion_extra) ");
                str.Append("VALUES (" + evaluacion.id_proyecto + ", " + evaluacion.id_evaluador + ", " + evaluacion.valor + ", '" + evaluacion.descripcion + "');");
                Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
                respuesta = true;
            }

        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }
        return respuesta;
    }
    public bool eliminarExtra(int id_proyecto, int id_evaluador)
    {
        bool respuesta;
        string str = "delete from proyecto_evaluacion_extra where id_proyecto = " + id_proyecto + " and id_evaluador = " + id_evaluador;
        try
        {
            Generico.instancia().eliminar(str, Constante.BD_SNIIV);
            respuesta = true; ;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }
        return respuesta;
    }

    public List<EvaluacionVO> seleccionar(int id_proyecto, int id_evaluador)
    {
        string str = "select id_proyecto, id_evaluador, id_criterio_evaluacion, valor from proyecto_evaluacion where id_proyecto = " + id_proyecto + " and id_evaluador = " + id_evaluador;
        List<EvaluacionVO> evaluacion = new List<EvaluacionVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            evaluacion = (from DataRow row in dt.Rows
                          select new EvaluacionVO()
                          {
                              id_proyecto = Convert.ToInt32(row["id_proyecto"].ToString()),
                              id_evaluador = Convert.ToInt32(row["id_evaluador"].ToString()),
                              id_criterio_evaluacion = Convert.ToInt32(row["id_criterio_evaluacion"].ToString()),
                              valor = Convert.ToInt32(row["valor"].ToString())
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return evaluacion;
    }
    public List<EvaluacionVO> seleccionarExtra(int id_proyecto, int id_evaluador)
    {
        string str = "select id_proyecto, id_evaluador, valor_extra, descripcion_extra from proyecto_evaluacion_extra where id_proyecto = " + id_proyecto + " and id_evaluador = " + id_evaluador;
        List<EvaluacionVO> evaluacion = new List<EvaluacionVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            evaluacion = (from DataRow row in dt.Rows
                          select new EvaluacionVO()
                          {
                              id_proyecto = Convert.ToInt32(row["id_proyecto"].ToString()),
                              id_evaluador = Convert.ToInt32(row["id_evaluador"].ToString()),
                              valor = Convert.ToInt32(row["valor_extra"].ToString()),
                              descripcion = row["descripcion_extra"].ToString()
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return evaluacion;
    }

    public bool evaluar(EvaluacionVO evaluacion, decimal promedio)
    {
        string str = "UPDATE proyecto_evaluacion_extra SET calificacion_criterios = '" + promedio + "' WHERE id_proyecto = " + evaluacion.id_proyecto + " AND id_evaluador = " + evaluacion.id_evaluador;
        bool respuesta = false;
        try
        {
            Generico.instancia().actializar(str, Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }

        return respuesta;
    }
}