using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

public class RegistroEvaluadoresDAO
{
    private static RegistroEvaluadoresDAO _instancia = null;

    public static RegistroEvaluadoresDAO instancia()
    {
        return _instancia == null ? new RegistroEvaluadoresDAO() : _instancia;
    }

    public RegistroEvaluadoresDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarGenero()
    {
        string str = "SELECT id, alias FROM sniiv.c_genero where id !='0'";
        List<CatalogoVO> genero = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            genero = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["id"].ToString(),
                         descripcion = row["alias"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return genero;
    }

    public List<CatalogoVO> seleccionarEscolaridad()
    {
        string str = "SELECT id, descripcion FROM sniiv.c_escolaridad_pnv";
        List<CatalogoVO> escolaridad = new List<CatalogoVO>();
        

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            escolaridad = (from DataRow row in dt.Rows
                      select new CatalogoVO()
                      {
                          id = row["id"].ToString(),
                          descripcion = row["descripcion"].ToString()
                      }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return escolaridad;
    }

    AlertaVO alerta;
    public int insertarRegistroDg(EvaluadorVO evaluador)
    {
        StringBuilder str = new StringBuilder();
        int id;

        str.Append("CALL sniiv.sp_registro_evaluador('"+ evaluador.folio + "', ");
        str.Append("'" + evaluador.fecha_registro + "', ");
        str.Append("'" + evaluador.nombre + "', ");
        str.Append("'" + evaluador.paterno + "', ");
        str.Append("'" + evaluador.materno + "', ");
        str.Append("'" + evaluador.rfc + "', ");
        str.Append("'" + evaluador.genero + "', ");
        str.Append("'" + evaluador.curp + "', ");
        str.Append("'" + evaluador.calle + "', ");
        str.Append("'" + evaluador.numero + "', ");
        str.Append("'" + evaluador.colonia + "', ");
        str.Append("'" + evaluador.entidad + "', ");
        str.Append("'" + evaluador.municipio + "', ");
        str.Append("'" + evaluador.localidad + "', ");
        str.Append("'" + evaluador.cp + "', ");
        str.Append("'" + evaluador.telefono + "', ");
        str.Append("'" + evaluador.celular + "', ");
        str.Append("'" + evaluador.correo + "'" + ")");

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            id = Convert.ToInt32(dt.Rows[0][0].ToString());
            str = new StringBuilder();
            if (evaluador.escolaridades.Count > 0)
            {
                foreach (EscolaridadVO escolaridad in evaluador.escolaridades)
                {
                    str.Append("CALL sp_registro_escolaridades('" + id + "', ");
                    str.Append("'" + escolaridad.id_escolaridad + "', ");
                    str.Append("'" + escolaridad.institucion_escolaridad + "', ");
                    str.Append("'" + escolaridad.disciplina_escolaridad + "', ");
                    str.Append("'" + escolaridad.periodo_escolaridad + "'" + ");");
                }
            }
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);

            str = new StringBuilder();
            if (evaluador.cursos.Count > 0) { 
                foreach (CursoVO curso in evaluador.cursos) {
                    
                    str.Append("CALL sniiv.sp_registro_cursos('" + id + "', ");
                    str.Append("'"+ curso.institucion + "', ");
                    str.Append("'" + curso.tema + "', ");
                    str.Append("'" + curso.anio + "'" + ");");
                    
                }
                Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            }
            str = new StringBuilder();
            str.Append("CALL sniiv.sp_registro_laboral('" + id + "', ");
            str.Append("'" + evaluador.laboral.razon_social_empresa + "', ");
            str.Append("'" + evaluador.laboral.rfc_empresa + "', ");
            str.Append("'" + evaluador.laboral.calle_empresa + "', ");
            str.Append("'" + evaluador.laboral.numero_exterior_empresa + "', ");
            str.Append("'" + evaluador.laboral.colonia_empresa + "', ");
            str.Append("'" + evaluador.laboral.clave_entidad_federativa_empresa + "', ");
            str.Append("'" + evaluador.laboral.clave_municipio_empresa + "', ");
            str.Append("'" + evaluador.laboral.clave_localidad_empresa + "', ");
            str.Append("'" + evaluador.laboral.codigo_postal_empresa + "'" + ");");
            
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            str = new StringBuilder();
            if (evaluador.experiencias.Count > 0)
            {
                foreach (ExperienciaLaboralVO experiencia in evaluador.experiencias)
                {
                    
                    str.Append("CALL sniiv.sp_registro_experiencias('" + id + "', ");
                    str.Append("'" + experiencia.periodo_experiencia + "', ");
                    str.Append("'" + experiencia.institucion_experiencia + "', ");
                    str.Append("'" + experiencia.cargo_experiencia + "'" + ");");
               
            
                }
                Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            }
            
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            id = 0;
        }

        return id;
    }

    #region Cuestionario

    public AlertaVO insertarCuestionario(List<CuestionarioPrnvVO> respuestas)
    {
        
        StringBuilder str = new StringBuilder();
        alerta = new AlertaVO();

        str.Append("DELETE FROM cuestionario_prnv WHERE id_evaluador = " + respuestas.First().id_evaluador + ";");
        foreach (CuestionarioPrnvVO respuesta in respuestas)
        {
            str.Append("INSERT INTO cuestionario_prnv VALUES (" + respuesta.id_evaluador + " , " + respuesta.id_pregunta + ", '" + respuesta.respuesta + "');");
        }

        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            alerta.text = "Cuestionario enviado correctamente.";
            alerta.type = AlertaVO.type_success;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            alerta.text = "Problemas al enviar cuestionario.";
            alerta.type = AlertaVO.type_danger;
        }

        return alerta;
    }

    #endregion

    public List<EvaluadorVO> seleccionarEvaluadores()
    {
        string str = "call sp_get_evaluadores()";
        List<EvaluadorVO> evaluadores = new List<EvaluadorVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);

            evaluadores = (from DataRow row in dt.Rows
                           select new EvaluadorVO()
                           {
                               id = Convert.ToInt32(row["id"].ToString()),
                               fecha_registro = Convert.ToDateTime(row["fecha_registro"].ToString()),
                               folio = row["folio_registro"].ToString(),
                               nombre = row["nombre"].ToString(),
                               paterno = row["paterno"].ToString(),
                               materno = row["materno"].ToString(),
                               genero = row["genero"].ToString(),
                               rfc = row["rfc"].ToString(),
                               curp = row["curp"].ToString(),
                               calle = row["calle"].ToString(),
                               numero = row["numero_exterior"].ToString(),
                               colonia = row["colonia"].ToString(),
                               cp = row["codigo_postal"].ToString(),
                               entidad = row["estado"].ToString(),
                               municipio = row["municipio"].ToString(),
                               localidad = row["localidad"].ToString(),
                               telefono = row["telefono"].ToString(),
                               celular = row["celular"].ToString(),
                               correo = row["correo_electronico"].ToString(),

                               escolaridad_grado = row["ESCOLARIDAD_grado"].ToString(),
                               escolaridad_institucion = row["ESCOLARIDAD_institucion"].ToString(),
                               escolaridad_disciplina = row["ESCOLARIDAD_disciplina"].ToString(),
                               escolaridad_periodo = row["ESCOLARIDAD_periodo"].ToString(),

                               curso_institucion = row["CURSO_institucion"].ToString(),
                               curso_tema = row["CURSO_institucion"].ToString(),
                               curso_periodo = row["CURSO_institucion"].ToString(),

                               empresa_razon_social = row["EMPRESA_razon_social"].ToString(),
                               empresa_rfc = row["EMPRESA_rfc"].ToString(),
                               empresa_calle = row["EMPRESA_calle"].ToString(),
                               empresa_numero_exterior = row["EMPRESA_numero_exterior"].ToString(),
                               empresa_colonia = row["EMPRESA_colonia"].ToString(),
                               empresa_estado = row["EMPRESA_estado"].ToString(),
                               empresa_municipio = row["EMPRESA_municipio"].ToString(),
                               empresa_localidad = row["EMPRESA_localidad"].ToString(),
                               empresa_codigo_postal = row["EMPRESA_codigo_postal"].ToString(),

                               experiencia_institucion = row["EXPERIENCIA_institucion"].ToString(),
                               experiencia_cargo = row["EXPERIENCIA_cargo"].ToString(),
                               experiencia_periodo = row["EXPERIENCIA_periodo"].ToString(),

                               activo = Convert.ToInt32(row["activo"].ToString())
                           }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return evaluadores;
    }

    public EvaluadorVO seleccionarEvaluador(int id_evaluador)
    {
        StringBuilder str = new StringBuilder();
        EvaluadorVO evaluador = new EvaluadorVO();

        str.Append("select ");
        str.Append("p.id, p.folio_registro, p.nombre, p.paterno, p.materno, e.descripcion as estado, ");
        str.Append("m.descripcion as municipio, l.descripcion as localidad, g.alias as genero, p.curp, p.rfc, ");
        str.Append("p.calle, p.numero_exterior, p.colonia, p.codigo_postal, p.correo_electronico, ");
        str.Append("p.telefono, p.celular ");
        str.Append("from ");
        str.Append("registro_evaluador_pnv p ");
        str.Append("join c_genero g on g.id = p.id_genero ");
        str.Append("join c_entidad_federativa e on e.clave = p.clave_entidad_federativa ");
        str.Append("join c_localidad l ");
        str.Append("on l.clave = p.clave_localidad and l.clave_entidad_federativa = p.clave_entidad_federativa and l.clave_municipio = p.clave_municipio ");
        str.Append("join c_municipio m ");
        str.Append("on m.clave = p.clave_municipio ");
        str.Append("and m.clave_entidad_federativa = p.clave_entidad_federativa ");
        str.Append("where p.id = " + id_evaluador);

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            evaluador = (from DataRow row in dt.Rows
                         select new EvaluadorVO()
                         {
                             id = Convert.ToInt32(row["id"].ToString()),
                             folio = row["folio_registro"].ToString(),
                             nombre = row["nombre"].ToString(),
                             paterno = row["paterno"].ToString(),
                             materno = row["materno"].ToString(),
                             entidad = row["estado"].ToString(),
                             municipio = row["municipio"].ToString(),
                             localidad = row["localidad"].ToString(),
                             genero = row["genero"].ToString(),
                             curp = row["curp"].ToString(),
                             rfc = row["rfc"].ToString(),
                             calle = row["calle"].ToString(),
                             numero = row["numero_exterior"].ToString(),
                             colonia = row["colonia"].ToString(),
                             cp = row["codigo_postal"].ToString(),
                             telefono = row["telefono"].ToString(),
                             celular = row["celular"].ToString(),
                             correo = row["correo_electronico"].ToString()
                         }).ToList().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return evaluador;
    }

    public List<CuestionarioPrnvVO> seleccionarCuestionario(int id_evaluador)
    {
        string str = "select id_evaluador, id_pregunta, respuesta from cuestionario_prnv where id_evaluador = " + id_evaluador;
        List<CuestionarioPrnvVO> cuestionario = new List<CuestionarioPrnvVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            cuestionario = (from DataRow row in dt.Rows
                            select new CuestionarioPrnvVO()
                            {
                                id_evaluador = Convert.ToInt32(row["id_evaluador"].ToString()),
                                id_pregunta = Convert.ToInt32(row["id_pregunta"].ToString()),
                                respuesta = row["respuesta"].ToString()
                            }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return cuestionario;
    }

}
