using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CuestionarioViviendaDAO
{
    private static CuestionarioViviendaDAO _instancia = null;

    public static CuestionarioViviendaDAO instancia()
    {
        return _instancia == null ? new CuestionarioViviendaDAO() : _instancia;
    }

    public CuestionarioViviendaDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<CatalogoVO> seleccionarOpcion(int tipo_opcion)
    {
        List<CatalogoVO> opciones = new List<CatalogoVO>();
        string nombre_tabla = string.Empty;
        switch (tipo_opcion)
        {
            case (int)CuestionarioViviendaVO.Tipo.tipo:
                nombre_tabla = "c_tipo";
                break;
            case (int)CuestionarioViviendaVO.Tipo.situacion:
                nombre_tabla = "c_situacion";
                break;
            case (int)CuestionarioViviendaVO.Tipo.riesgo:
                nombre_tabla = "c_riesgo";
                break;
            case (int)CuestionarioViviendaVO.Tipo.seguridad:
                nombre_tabla = "c_seguridad";
                break;
            case (int)CuestionarioViviendaVO.Tipo.agua:
                nombre_tabla = "c_agua";
                break;
            case (int)CuestionarioViviendaVO.Tipo.banio:
                nombre_tabla = "c_banio";
                break;
            case (int)CuestionarioViviendaVO.Tipo.cocina:
                nombre_tabla = "c_cocina";
                break;
            case (int)CuestionarioViviendaVO.Tipo.electricidad:
                nombre_tabla = "c_electricidad";
                break;
            case (int)CuestionarioViviendaVO.Tipo.paredes:
                nombre_tabla = "c_paredes";
                break;
            case (int)CuestionarioViviendaVO.Tipo.techo:
                nombre_tabla = "c_techo";
                break;
            case (int)CuestionarioViviendaVO.Tipo.piso:
                nombre_tabla = "c_piso";
                break;
            case (int)CuestionarioViviendaVO.Tipo.mejoramiento:
                nombre_tabla = "c_mejoramiento";
                break;
            case (int)CuestionarioViviendaVO.Tipo.ampliacion:
                nombre_tabla = "c_ampliacion";
                break;
            case (int)CuestionarioViviendaVO.Tipo.necesidad:
                nombre_tabla = "c_necesidad";
                break;
        }
        try
        {
            DataTable dt = Generico.instancia().seleccionar("select id, descripcion from " + nombre_tabla, Constante.BD_APOYO_VIVIENDA);
            opciones = (from DataRow row in dt.Rows
                     select new CatalogoVO()
                     {
                         id = row["id"].ToString(),
                         descripcion = row["descripcion"].ToString()
                     }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return opciones;
    }
}
