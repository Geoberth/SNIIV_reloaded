using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de OfertaInventarioDAO
/// </summary>
public class OfertaInventarioDAO
{
    private static OfertaInventarioDAO _instancia = null;

    public static OfertaInventarioDAO instancia()
    {
        return _instancia == null ? new OfertaInventarioDAO() : _instancia;
    }

    public OfertaInventarioDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<OfertaInventarioVO> getKPIsOfertaInventario(int anio, int mes)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select ef.descripcion as estado, vsm.descripcion as segmento, uma.descripcion as segmento_uma, ");
        str.Append("ao.descripcion as avance_obra, tv.descripcion as tipo_vivienda, viviendas ");
        str.Append("from (select clave_estado, id_segmento, id_segmento_uma, id_avance_obra, id_tipo_vivienda, sum(viviendas) as viviendas ");
        str.Append("from cubo_inventario_vivienda ");
        str.Append("where anio = " + anio + " AND mes = " + mes);
        str.Append(" group by clave_estado, id_segmento, id_segmento_uma, id_avance_obra, id_tipo_vivienda) t ");
        str.Append("join c_entidad_federativa ef on t.clave_estado=ef.clave ");
        str.Append("join c_valor_vivienda vsm on t.id_segmento = vsm.id ");
        str.Append("join c_valor_vivienda_uma uma on t.id_segmento_uma = uma.id ");
        str.Append("join c_avance_obra ao on ao.id=t.id_avance_obra ");
        str.Append("join c_tipo_vivienda tv on t.id_tipo_vivienda = tv.id");
        List<OfertaInventarioVO> KPIs = new List<OfertaInventarioVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new OfertaInventarioVO()
                    {
                        estado = row["estado"].ToString(),
                        segmento = row["segmento"].ToString(),
                        segmento_uma = row["segmento_uma"].ToString(),
                        avance_obra = row["avance_obra"].ToString(),
                        tipo_vivienda = row["tipo_vivienda"].ToString(),
                        viviendas = int.Parse(row["viviendas"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }
   
}