using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PaqueteDAO
{
    private static PaqueteDAO _instancia = null;

    public static PaqueteDAO instancia()
    {
        if (_instancia == null)
        {
            _instancia = new PaqueteDAO();
        }
        return _instancia;
    }

    public PaqueteDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<CatalogoVO> seleccionarPaquete(string clave_estado)
    {
        string str = "select id, nombre from c_paquete_insumo where clave_entidad_federativa = " + clave_estado;
        List<CatalogoVO> paquetes = new List<CatalogoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            paquetes = (from DataRow row in dt.Rows
                          select new CatalogoVO()
                          {
                              id = row["id"].ToString(),
                              descripcion = row["nombre"].ToString()
                          }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return paquetes;
    }

    public List<InsumoVO> seleccionarInsumos(int id_paquete, bool active_only = false)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select p.id_paquete, i.id, i.codigo, i.descripcion, i.detalle, i.activo, ");
        str.Append("p.cantidad, u.descripcion as unidad_medida, p.precio ");
        str.Append("from paquete_explosion_insumo p ");
        str.Append("join c_explosion_insumo i on i.id = p.id_explosion_insumo ");
        str.Append("join c_unidad_medida u on u.id = i.id_unidad_medida ");
        str.Append("where p.id_paquete = " + id_paquete);
        if (active_only)
            str.Append(" and i.activo = 1");
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
                           cantidad = Convert.ToInt32(row["cantidad"].ToString()),
                           unidad_medida = row["unidad_medida"].ToString(),
                           precio = float.Parse(row["precio"].ToString()),
                           activo = Convert.ToBoolean(Convert.ToInt32(row["activo"].ToString()))
                       }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return insumos;
    }
}
