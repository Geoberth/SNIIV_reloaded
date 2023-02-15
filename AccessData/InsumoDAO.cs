using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de InsumoDAO
/// </summary>
public class InsumoDAO
{
    private static InsumoDAO _instancia = null;

    public static InsumoDAO instancia()
    {
        return _instancia == null ? new InsumoDAO() : _instancia;
    }

    public InsumoDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarUnidades()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select id, simbolo from c_unidad_medida");
        List<CatalogoVO> lstUnidades = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstUnidades = (from DataRow row in dt.Rows
                           select new CatalogoVO()
                           {
                               id = row["id"].ToString(),
                               descripcion = row["simbolo"].ToString()
                           }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstUnidades;
    }

    public List<CatalogoVO> seleccionarGrupos()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select codigo, descripcion from c_explosion_insumo_grupo");
        List<CatalogoVO> lstgrupos = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            lstgrupos = (from DataRow row in dt.Rows
                           select new CatalogoVO()
                           {
                               id = row["codigo"].ToString(),
                               descripcion = row["descripcion"].ToString()
                           }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return lstgrupos;
    }


    public InsumoVO seleccionarInsumo(int id_insumo)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT id, codigo, descripcion ");
        str.Append("FROM c_explosion_insumo WHERE id = " + id_insumo);
        InsumoVO insumo = null;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            insumo = (from DataRow row in dt.Rows
                      select new InsumoVO()
                      {
                          id = Convert.ToInt32(row["id"].ToString()),
                          codigo = row["codigo"].ToString(),
                          descripcion = row["descripcion"].ToString()
                      }).ToList().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return insumo;
    }

    public InsumoVO seleccionarInsumo(string codigo_insumo)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT id, codigo, descripcion ");
        str.Append("FROM c_explosion_insumo WHERE codigo = '" + codigo_insumo + "'");
        InsumoVO insumo = null;
        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            insumo = (from DataRow row in dt.Rows
                      select new InsumoVO()
                      {
                          id = Convert.ToInt32(row["id"].ToString()),
                          codigo = row["codigo"].ToString(),
                          descripcion = row["descripcion"].ToString()
                      }).ToList().First();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return insumo;
    }

    public List<InsumoVO> seleccionarBeneficiarioInsumos(int id_beneficiario)
    {
        StringBuilder str = new StringBuilder();
        str.Append("SELECT ");
        str.Append("i.id, i.codigo, i.descripcion, u.simbolo as unidad_medida, bi.cantidad, bi.cantidad_2, bi.cantidad_3, bi.precio, i.activo ");
        str.Append("from beneficiario_explosion_insumo bi ");
        str.Append("join c_explosion_insumo i on i.id = bi.id_explosion_insumo ");
        str.Append("join c_unidad_medida u on u.id = i.id_unidad_medida ");
        str.Append("WHERE bi.id_beneficiario_insumo = " + id_beneficiario);
        List<InsumoVO> insumos = new List<InsumoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            insumos = (from DataRow row in dt.Rows
                       select new InsumoVO()
                       {
                           id = Convert.ToInt32(row["id"].ToString()),
                           codigo = row["codigo"].ToString(),
                           descripcion = row["descripcion"].ToString(),
                           unidad_medida = row["unidad_medida"].ToString(),
                           cantidad = Convert.ToInt32(row["cantidad"].ToString()),
                           cantidad_2 = Convert.ToInt32(row["cantidad_2"].ToString()),
                           cantidad_3 = Convert.ToInt32(row["cantidad_3"].ToString()),
                           precio = float.Parse(row["precio"].ToString()),
                           activo = Convert.ToBoolean(Convert.ToInt32(row["activo"].ToString()))
                       }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return insumos;
    }

    public List<InsumoVO> seleccionarInsumos(bool active_only = false)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select i.id, i.activo, i.codigo, i.descripcion, i.detalle, u.simbolo as unidad_medida from c_explosion_insumo i ");
        str.Append("join c_unidad_medida u on u.id = i.id_unidad_medida");
        if (active_only)
            str.Append(" where activo = 1");
        str.Append(" order by i.codigo");
        List<InsumoVO> insumos = new List<InsumoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            insumos = (from DataRow row in dt.Rows
                       select new InsumoVO()
                       {
                           id = Convert.ToInt32(row["id"].ToString()),
                           codigo = row["codigo"].ToString(),
                           descripcion = row["descripcion"].ToString(),
                           detalle = row["detalle"].ToString(),
                           unidad_medida = row["unidad_medida"].ToString(),
                           activo = Convert.ToBoolean(Convert.ToInt32(row["activo"].ToString()))
                       }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return insumos;
    }

    public List<InsumoVO> seleccionarInsumosPaquete(int id_paquete)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select i.id, i.codigo, i.descripcion, i.detalle, u.simbolo as unidad_medida, p.cantidad, p.precio ");
        str.Append("from c_explosion_insumo i ");
        str.Append("join paquete_explosion_insumo p on p.id_explosion_insumo = i.id ");
        str.Append("join c_unidad_medida u on u.id = i.id_unidad_medida ");
        str.Append(" where id_paquete = " + id_paquete);
        str.Append(" order by i.codigo");
        List<InsumoVO> insumos = new List<InsumoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            insumos = (from DataRow row in dt.Rows
                       select new InsumoVO()
                       {
                           id = Convert.ToInt32(row["id"].ToString()),
                           codigo = row["codigo"].ToString(),
                           descripcion = row["descripcion"].ToString(),
                           detalle = row["detalle"].ToString(),
                           unidad_medida = row["unidad_medida"].ToString(),
                           cantidad = Convert.ToInt32(row["cantidad"].ToString()),
                           precio = float.Parse(row["precio"].ToString())
                       }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return insumos;
    }

    public List<InsumoVO> seleccionarBeneficiariosInsumos()
    {
        StringBuilder str = new StringBuilder();
        str.Append("select b.folio_conavi, i.codigo, i.descripcion, i.detalle, u.simbolo as unidad_medida, ");
        str.Append("bi.cantidad, bi.cantidad_2, bi.precio ");
        str.Append("from beneficiario_explosion_insumo bi ");
        str.Append("join beneficiario_insumo b on b.id = bi.id_beneficiario_insumo ");
        str.Append("join c_explosion_insumo i on i.id = bi.id_explosion_insumo ");
        str.Append("join c_unidad_medida u on u.id = i.id_unidad_medida ");
        str.Append("where b.estatus = 1 ");
        str.Append("order by b.folio_conavi, i.codigo");
        List<InsumoVO> insumos = new List<InsumoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            insumos = (from DataRow row in dt.Rows
                       select new InsumoVO()
                       {
                           codigo_grupo = row["folio_conavi"].ToString(),
                           codigo = row["codigo"].ToString(),
                           descripcion = row["descripcion"].ToString(),
                           detalle = row["detalle"].ToString(),
                           unidad_medida = row["unidad_medida"].ToString(),
                           cantidad = Convert.ToInt32(row["cantidad"].ToString()),
                           cantidad_2 = Convert.ToInt32(row["cantidad_2"].ToString()),
                           precio = float.Parse(row["precio"].ToString())
                       }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return insumos;
    }

    public bool insertarInsumo(InsumoVO articulo)
    {
        StringBuilder str = new StringBuilder();
        str.Append("insert into c_explosion_insumo (codigo, descripcion, detalle, id_unidad_medida, codigo_grupo) ");
        str.Append("VALUES (fn_traer_consecutivo_articulo('" + articulo.codigo_grupo + "'), '" + articulo.descripcion + "', '" + articulo.detalle + "', '" + articulo.unidad_medida + "', '" + articulo.codigo_grupo + "')");
        bool respuesta;
        try
        {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            respuesta = true;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }

        return respuesta;
    }

    public bool actualizarInsumo(List<InsumoVO> insumos)
    {
        StringBuilder str = new StringBuilder();
        bool respuesta;
        try
        {
            foreach (InsumoVO insumo in insumos)
            {
                str.Append("update c_explosion_insumo set activo = " + (insumo.activo ? 1 : 0) + " where id = " + insumo.id + ";");
            }
            Generico.instancia().actializar(str.ToString(), Constante.BD_SNIIV);
            respuesta = true; ;
        }
        catch (Exception ex)
        {
            Util.instancia().setLogError(ex);
            respuesta = false;
        }
        return respuesta;
    }

    public bool actualizarPrecioInsumo(string clave_estado, string clave_municipio, List<InsumoVO> insumos)
    {
        bool respuesta;
        StringBuilder str = new StringBuilder();
        try
        {
            respuesta = eliminarPrecioInsumo(clave_estado, clave_municipio);
            if (respuesta)
            {
                foreach (InsumoVO insumo in insumos)
                {
                    str.Append("INSERT INTO explosion_insumo_precio (clave_entidad_federativa, clave_municipio, id_explosion_insumo, precio) ");
                    str.Append("VALUES ('" + clave_estado + "', '" + clave_municipio + "', " + insumo.id + ", " + insumo.precio + ");");
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
    public bool eliminarPrecioInsumo(string clave_estado, string clave_municipio)
    {
        bool respuesta;
        string str = "delete from explosion_insumo_precio where clave_entidad_federativa = '" + clave_estado + "' and clave_municipio = '" + clave_municipio + "'";
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

    public List<InsumoVO> seleccionarPrecioInsumo(string clave_estado, string clave_municipio)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select i.id, i.codigo, i.descripcion, p.precio, i.activo ");
        str.Append("from c_explosion_insumo i ");
        str.Append("left join explosion_insumo_precio p on p.id_explosion_insumo = i.id ");
        str.Append("where clave_entidad_federativa = '" + clave_estado + "' and clave_municipio = '" + clave_municipio + "' and activo = 1");
        List<InsumoVO> insumos = new List<InsumoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            insumos = (from DataRow row in dt.Rows
                       select new InsumoVO()
                       {
                           id = Convert.ToInt32(row["id"].ToString()),
                           codigo = row["codigo"].ToString(),
                           descripcion = row["descripcion"].ToString(),
                           precio = float.Parse(row["precio"].ToString()),
                           activo = Convert.ToBoolean(Convert.ToInt32(row["activo"].ToString()))
                       }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return insumos;
    }

}