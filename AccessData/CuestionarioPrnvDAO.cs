using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de CnbvDAO
/// </summary>
public class CuestionarioPrnvDAO
{
    private static CuestionarioPrnvDAO _instancia = null;

    public static CuestionarioPrnvDAO instancia()
    {
        return _instancia == null ? new CuestionarioPrnvDAO() : _instancia;
    }

    public CuestionarioPrnvDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    AlertaVO alerta;

    public AlertaVO insertarCuestionario(List<CuestionarioPrnvVO> respuestas) {
        StringBuilder str = new StringBuilder();
        alerta = new AlertaVO();

        str.Append("DELETE FROM cuestionario_prnv WHERE folio = '" + respuestas.First().folio + "';");
        foreach (CuestionarioPrnvVO respuesta in respuestas) {
            str.Append("INSERT INTO cuestionario_prnv VALUES (" + respuesta.folio + ", " + respuesta.id_pregunta + ", '" +respuesta.respuesta + "');");
        }

        try {
            Generico.instancia().insertar(str.ToString(), Constante.BD_SNIIV);
            alerta.text = "Cuestionario enviado correctamente.";
            alerta.type = AlertaVO.type_success;
        }
        catch (Exception ex) {
            Util.instancia().setLogError(ex);
            alerta.text = "Problemas al enviar cuestionario.";
            alerta.type = AlertaVO.type_danger;
        }

        return alerta;
    }
}
