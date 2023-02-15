using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de RegistroViviendaDAO
/// </summary>
public class OfertaDAO
{
    private static OfertaDAO _instancia = null;

    public static OfertaDAO instancia()
    {
        return _instancia == null ? new OfertaDAO() : _instancia;
    }

    public OfertaDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<OfertaVO> getKPIsOferta(int anio_inicio, int anio_fin)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select ef.descripcion as estado, tv.descripcion as tipo_vivienda, p.descripcion as pcu, ");
        str.Append("vsm.descripcion as segmento, uma.descripcion as segmento_uma, viviendas ");
        str.Append("from (select clave_estado, id_tipo_vivienda, id_pcu, id_segmento, id_segmento_uma, sum(viviendas) as viviendas ");
        str.Append("from cubo_registro_vivienda_bak ");
        str.Append("where anio between " + anio_inicio + " AND " + anio_fin);
        str.Append(" group by clave_estado,id_tipo_vivienda, id_pcu, id_segmento,id_segmento_uma) t ");
        str.Append("join c_entidad_federativa ef on t.clave_estado=ef.clave ");
        str.Append("join c_tipo_vivienda tv on t.id_tipo_vivienda = tv.id ");
        str.Append("join c_pcu p on t.id_pcu = p.id ");
        str.Append("join c_valor_vivienda_vsm vsm on t.id_segmento = vsm.id ");
        str.Append("join c_valor_vivienda_uma uma on t.id_segmento_uma = uma.id");
        List<OfertaVO> KPIs = new List<OfertaVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV);
            KPIs = (from DataRow row in dt.Rows
                    select new OfertaVO()
                    {
                        estado = row["estado"].ToString(),
                        tipo_vivienda = row["tipo_vivienda"].ToString(),
                        pcu = row["pcu"].ToString(),
                        segmento = row["segmento"].ToString(),
                        segmento_uma = row["segmento_uma"].ToString(),
                        viviendas = int.Parse(row["viviendas"].ToString())
                    }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return KPIs;
    }
   
}