using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de BeneficiarioDAO
/// </summary>
public class BeneficiarioDAO
{
    private static BeneficiarioDAO _instancia = null;

    public static BeneficiarioDAO instancia()
    {
        return _instancia == null ? new BeneficiarioDAO() : _instancia;
    }

    public BeneficiarioDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarAsistentes()
    {
        string str = "select clave, nombre_fiscal as descripcion from c_asistente_tecnico_insumo";
        List<CatalogoVO> lst = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new CatalogoVO()
                   {
                       id = row["clave"].ToString(),
                       descripcion = row["descripcion"].ToString()
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }
    public List<CatalogoVO> seleccionarComites(int tipo_comite)
    {
        string str = "select id, descripcion from c_comite_insumo where tipo = " + tipo_comite;
        List<CatalogoVO> lst = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new CatalogoVO()
                   {
                       id = row["id"].ToString(),
                       descripcion = row["descripcion"].ToString()
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }
    public List<CatalogoVO> seleccionarProgramas()
    {
        string str = "select id, abreviatura as descripcion from c_programa_reconstruccion";
        List<CatalogoVO> lst = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new CatalogoVO()
                   {
                       id = row["id"].ToString(),
                       descripcion = row["descripcion"].ToString()
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }
    public List<CatalogoVO> seleccionarTipoIntervenciones()
    {
        string str = "select id, descripcion from c_tipo_intervencion";
        List<CatalogoVO> lst = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows
                   select new CatalogoVO()
                   {
                       id = row["id"].ToString(),
                       descripcion = row["descripcion"].ToString()
                   }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public BeneficiarioVO seleccionarBeneficiario(int id)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT ");
        str.Append("id, folio_conavi, curp, fecha_captura, paterno, materno, nombre, ");
        str.Append("calle, numero_interior, numero_exterior, codigo_postal, clave_entidad_federativa, clave_municipio, clave_localidad, longitud, latitud, ");
        str.Append("id_tipo_intervencion, monto_intervencion, monto_asistente, clave_asistente_tecnico, id_comite_financiamiento, COALESCE(id_comite_evaluacion, 0) as id_comite_evaluacion, ");
        str.Append("estatus, persona, descargado, observaciones, id_programa, cast(explosion_insumos as unsigned) as explosion_insumos, material_vivienda, material_lugar, id_paquete_insumo ");
        str.Append("FROM beneficiario_insumo ");
        str.Append("WHERE id = '" + id + "' ");
        BeneficiarioVO beneficiario = null;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            beneficiario = (from DataRow row in dt.Rows
                            select new BeneficiarioVO()
                            {
                                id = Convert.ToInt32(row["id"].ToString()),
                                folio_conavi = row["folio_conavi"].ToString(),
                                fecha_captura = row["fecha_captura"].ToString(),
                                paterno = row["paterno"].ToString(),
                                materno = row["materno"].ToString(),
                                nombre = row["nombre"].ToString(),
                                curp = row["curp"].ToString(),

                                calle = row["calle"].ToString(),
                                numero_interior = row["numero_interior"].ToString(),
                                numero_exterior = row["numero_exterior"].ToString(),
                                codigo_postal = row["codigo_postal"].ToString(),
                                clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                                clave_municipio = row["clave_municipio"].ToString(),
                                clave_localidad = row["clave_localidad"].ToString(),
                                latitud = row["latitud"].ToString(),
                                longitud = row["longitud"].ToString(),

                                id_tipo_intervencion = Convert.ToInt32(row["id_tipo_intervencion"].ToString()),
                                monto_intervencion = row["monto_intervencion"].ToString(),
                                monto_asistente = row["monto_asistente"].ToString(),
                                clave_asistente_tecnico = row["clave_asistente_tecnico"].ToString(),
                                id_comite_financiamiento = Convert.ToInt32(row["id_comite_financiamiento"].ToString()),
                                id_comite_evaluacion = Convert.ToInt32(row["id_comite_evaluacion"].ToString()),

                                estatus = row["estatus"].ToString(),
                                persona = row["persona"].ToString(),
                                descargado = row["descargado"].ToString(),
                                observaciones = row["observaciones"].ToString(),
                                id_programa = Convert.ToInt32(row["id_programa"].ToString()),
                                explosion_insumos = Convert.ToInt32(row["explosion_insumos"].ToString()),

                                material_vivienda = Convert.ToBoolean(Convert.ToInt32(row["material_vivienda"].ToString())),
                                material_lugar = row["material_lugar"].ToString(),

                                id_paquete_insumo = Convert.ToInt32(row["id_paquete_insumo"].ToString())
                            }).ToList().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return beneficiario;
    }
    public BeneficiarioVO seleccionarBeneficiarioFolio(string folio_conavi)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT ");
        str.Append("id, folio_conavi, curp, fecha_captura, paterno, materno, nombre, ");
        str.Append("calle, numero_interior, numero_exterior, codigo_postal, clave_entidad_federativa, clave_municipio, clave_localidad, longitud, latitud, ");
        str.Append("id_tipo_intervencion, monto_intervencion, monto_asistente, clave_asistente_tecnico, id_comite_financiamiento, COALESCE(id_comite_evaluacion, 0) as id_comite_evaluacion, ");
        str.Append("estatus, persona, descargado, observaciones, id_programa, cast(explosion_insumos as unsigned) as explosion_insumos, material_vivienda, material_lugar ");
        str.Append("FROM beneficiario_insumo ");
        str.Append("WHERE folio_conavi = '" + folio_conavi + "' ");
        BeneficiarioVO beneficiario = null;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            beneficiario = (from DataRow row in dt.Rows
                            select new BeneficiarioVO()
                            {
                                id = Convert.ToInt32(row["id"].ToString()),
                                folio_conavi = row["folio_conavi"].ToString(),
                                fecha_captura = row["fecha_captura"].ToString(),
                                paterno = row["paterno"].ToString(),
                                materno = row["materno"].ToString(),
                                nombre = row["nombre"].ToString(),
                                curp = row["curp"].ToString(),

                                calle = row["calle"].ToString(),
                                numero_interior = row["numero_interior"].ToString(),
                                numero_exterior = row["numero_exterior"].ToString(),
                                codigo_postal = row["codigo_postal"].ToString(),
                                clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                                clave_municipio = row["clave_municipio"].ToString(),
                                clave_localidad = row["clave_localidad"].ToString(),
                                latitud = row["latitud"].ToString(),
                                longitud = row["longitud"].ToString(),

                                id_tipo_intervencion = Convert.ToInt32(row["id_tipo_intervencion"].ToString()),
                                monto_intervencion = row["monto_intervencion"].ToString(),
                                monto_asistente = row["monto_asistente"].ToString(),
                                clave_asistente_tecnico = row["clave_asistente_tecnico"].ToString(),
                                id_comite_financiamiento = Convert.ToInt32(row["id_comite_financiamiento"].ToString()),
                                id_comite_evaluacion = Convert.ToInt32(row["id_comite_evaluacion"].ToString()),

                                estatus = row["estatus"].ToString(),
                                persona = row["persona"].ToString(),
                                descargado = row["descargado"].ToString(),
                                observaciones = row["observaciones"].ToString(),
                                id_programa = Convert.ToInt32(row["id_programa"].ToString()),
                                explosion_insumos = Convert.ToInt32(row["explosion_insumos"].ToString()),

                                material_vivienda = Convert.ToBoolean(Convert.ToInt32(row["material_vivienda"].ToString())),
                                material_lugar = row["material_lugar"].ToString()
                            }).ToList().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return beneficiario;
    }
    /*
    public BeneficiarioVO seleccionarBeneficiarioCURP(string curp)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT ");
        str.Append("id, folio_conavi, curp, paterno, materno, nombre, ");
        str.Append("calle, numero_interior, numero_exterior, codigo_postal, clave_entidad_federativa, clave_municipio, clave_localidad, longitud, latitud, ");
        str.Append("cast(tipo_intervencion as unsigned) as tipo_intervencion, monto_intervencion, monto_asistente, clave_asistente_tecnico, id_comite_financiamiento, id_comite_evaluacion, ");
        str.Append("estatus, persona, descargado, observaciones, id_programa, cast(explosion_insumos as unsigned) as explosion_insumos ");
        str.Append("FROM beneficiario_insumo ");
        str.Append("WHERE curp = '" + curp + "' ");
        BeneficiarioVO beneficiario = null;

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            beneficiario = (from DataRow row in dt.Rows
                            select new BeneficiarioVO()
                            {
                                id = Convert.ToInt32(row["id"].ToString()),
                                folio_conavi = row["folio_conavi"].ToString(),
                                paterno = row["paterno"].ToString(),
                                materno = row["materno"].ToString(),
                                nombre = row["nombre"].ToString(),
                                curp = row["curp"].ToString(),

                                calle = row["calle"].ToString(),
                                numero_interior = row["numero_interior"].ToString(),
                                numero_exterior = row["numero_exterior"].ToString(),
                                codigo_postal = Convert.ToInt32(row["codigo_postal"].ToString()),
                                clave_entidad_federativa = row["clave_entidad_federativa"].ToString(),
                                clave_municipio = row["clave_municipio"].ToString(),
                                clave_localidad = row["clave_localidad"].ToString(),
                                latitud = row["latitud"].ToString(),
                                longitud = row["longitud"].ToString(),

                                tipo_intervencion = Convert.ToInt32(row["tipo_intervencion"].ToString()),
                                monto_intervencion = row["monto_intervencion"].ToString(),
                                monto_asistente = row["monto_asistente"].ToString(),
                                clave_asistente_tecnico = row["clave_asistente_tecnico"].ToString(),
                                id_comite_financiamiento = Convert.ToInt32(row["id_comite_financiamiento"].ToString()),
                                id_comite_evaluacion = Convert.ToInt32(row["id_comite_evaluacion"].ToString()),

                                estatus = row["estatus"].ToString(),
                                persona = row["persona"].ToString(),
                                descargado = row["descargado"].ToString(),
                                observaciones = row["observaciones"].ToString(),
                                id_programa = Convert.ToInt32(row["id_programa"].ToString()),
                                explosion_insumos = Convert.ToInt32(row["explosion_insumos"].ToString())
                            }).ToList().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return beneficiario;
    }
    */
    public List<string> seleccionarFolioConavi(int id_usuario, string folio_conavi)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT folio_conavi ");
        str.Append("FROM beneficiario_insumo ");
        str.Append("WHERE clave_asistente_tecnico = (SELECT COALESCE(clave_asistente_tecnico, 0) as clave_asistente_tecnico FROM usuario WHERE id = " + id_usuario + ") ");
        str.Append("AND folio_conavi LIKE '" + folio_conavi + "%'");
        List<string> lst = new List<string>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows select row["folio_conavi"].ToString()).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }
    public List<string> seleccionarCURPConavi(string curp)
    {
        string str = "SELECT curp FROM beneficiario_insumo WHERE curp LIKE '" + curp + "%'";
        List<string> lst = new List<string>();
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            lst = (from DataRow row in dt.Rows select row["curp"].ToString()).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lst;
    }

    public bool eliminarBeneficiarioExplosionInsumo(int id_beneficiario)
    {
        string str = "DELETE FROM beneficiario_explosion_insumo WHERE id_beneficiario_insumo = " + id_beneficiario;
        bool respuesta;
        try
        {
            Generico.instancia().eliminar(str.ToString(), Constante.BD_SNIIV);
            respuesta = true; ;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }

        return respuesta;
    }

    public bool insertarBeneficiarioExplosionInsumo(InsumoVO insumo, int id_beneficiario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("INSERT INTO beneficiario_explosion_insumo (id_beneficiario_insumo, id_explosion_insumo, cantidad, cantidad_2, precio) ");
        str.Append("VALUES (" + id_beneficiario + ", " + insumo.id + ", " + insumo.cantidad + ", " + insumo.cantidad_2 + ", '" + insumo.precio + "')");
        bool respuesta;
        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            respuesta = true; ;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }

        return respuesta;
    }

    public bool insertarBeneficiarioExplosionInsumo2(InsumoVO insumo, int id_beneficiario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("INSERT INTO beneficiario_explosion_insumo (id_beneficiario_insumo, id_explosion_insumo, cantidad, cantidad_2, cantidad_3, precio) ");
        str.Append("VALUES (" + id_beneficiario + ", " + insumo.id + ", " + insumo.cantidad + ", " + insumo.cantidad_2 + ", " + insumo.cantidad_3 + ", '" +  + insumo.precio + "')");
        bool respuesta;
        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            respuesta = true; ;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }

        return respuesta;
    }

    public bool actualizarBeneficiario(BeneficiarioVO beneficiario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("UPDATE beneficiario_insumo ");
        str.Append("SET paterno = '" + beneficiario.paterno + "', materno = '" + beneficiario.materno + "', nombre = '" + beneficiario.nombre + "', curp = '" + beneficiario.curp + "', ");
        str.Append("calle = '" + beneficiario.calle + "', numero_interior = '" + beneficiario.numero_interior + "', numero_exterior = '" + beneficiario.numero_exterior + "', codigo_postal = " + beneficiario.codigo_postal + ", ");
        str.Append("clave_entidad_federativa = '" + beneficiario.clave_entidad_federativa + "', clave_municipio = '" + beneficiario.clave_municipio + "', clave_localidad = '" + beneficiario.clave_localidad + "', longitud = '" + beneficiario.longitud + "', latitud = '" + beneficiario.latitud + "', ");
        str.Append("id_tipo_intervencion = " + beneficiario.id_tipo_intervencion + ", monto_intervencion = " + beneficiario.monto_intervencion + ", monto_asistente = " + beneficiario.monto_asistente + ", ");
        str.Append("clave_asistente_tecnico = '" + beneficiario.clave_asistente_tecnico + "', id_comite_financiamiento = " + beneficiario.id_comite_financiamiento + ", id_comite_evaluacion = " + beneficiario.id_comite_evaluacion + ", "); //+ ", estatus = " + beneficiario.estatus
        str.Append("persona = '" + beneficiario.persona + "', descargado = '" + beneficiario.descargado  + "', observaciones = '" + beneficiario.observaciones + "', id_programa = '" + beneficiario.id_programa + "', explosion_insumos = " + beneficiario.explosion_insumos);
        str.Append(", material_vivienda = " + (beneficiario.material_vivienda ? 1 : 0) + ", material_lugar = '" + beneficiario.material_lugar + "'");
        str.Append(" WHERE id = " + beneficiario.id);
        bool respuesta;
        try
        {
            Generico.instancia().actializar(str.ToString(), Constante.BD_SNIIV);
            respuesta = eliminarBeneficiarioExplosionInsumo(beneficiario.id);
            if (respuesta) {
                foreach (InsumoVO insumo in beneficiario.insumos) {
                    insertarBeneficiarioExplosionInsumo(insumo, beneficiario.id);
                }
                Generico.instancia().actializar("UPDATE beneficiario_insumo SET fecha_captura = NOW() WHERE id = " + beneficiario.id, Constante.BD_SNIIV);
            }
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }

        return respuesta;
    }

    public bool actualizarDomicilioBeneficiario(BeneficiarioVO beneficiario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("UPDATE beneficiario_insumo ");
        str.Append("SET longitud = '" + beneficiario.longitud + "', latitud = '" + beneficiario.latitud + "'");
        //str.Append("SET longitud = '" + beneficiario.longitud + "', latitud = '" + beneficiario.latitud + "', ");
        //str.Append("calle = '" + beneficiario.calle + "', numero_interior = '" + beneficiario.numero_interior + "', codigo_postal = " + beneficiario.codigo_postal + ", ");
        //str.Append("clave_entidad_federativa = '" + beneficiario.clave_entidad_federativa + "', clave_municipio = '" + beneficiario.clave_municipio + "', clave_localidad = '" + beneficiario.clave_localidad + "', ");
        str.Append(" WHERE id = " + beneficiario.id);
        bool respuesta;
        try
        {
            Generico.instancia().actializar(str.ToString(), Constante.BD_SNIIV);
            respuesta = eliminarBeneficiarioExplosionInsumo(beneficiario.id);
            if (respuesta)
            {
                foreach (InsumoVO insumo in beneficiario.insumos)
                {
                    insertarBeneficiarioExplosionInsumo2(insumo, beneficiario.id);
                }
                Generico.instancia().actializar("UPDATE beneficiario_insumo SET fecha_captura = NOW() WHERE id = " + beneficiario.id, Constante.BD_SNIIV);
            }
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }

        return respuesta;
    }

    public DataTable seleccionarBeneficiarios()
    {
        DataTable beneficiarios = new DataTable();

        try { beneficiarios = Generico.instancia().seleccionar("call sp_get_beneficiarios()", Constante.BD_SNIIV); }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return beneficiarios;
    }

    public DataTable seleccionarBeneficiariosAsistenteTecnico(string clave_at)
    {
        DataTable beneficiarios = new DataTable();

        try { beneficiarios = Generico.instancia().seleccionar("call sp_get_beneficiarios_at('" + clave_at + "')", Constante.BD_SNIIV); }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return beneficiarios;
    }

    public bool actualizarEstatusBeneficiario(int id_beneficiario)
    {
        string str = "UPDATE beneficiario_insumo SET estatus = 1 WHERE id = " + id_beneficiario;
        bool respuesta;
        try
        {
            Generico.instancia().actializar(str, Constante.BD_SNIIV);
            respuesta = true; ;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }

        return respuesta;
    }
}