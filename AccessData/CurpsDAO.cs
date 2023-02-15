using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de CurpsDAO
/// </summary>
public class CurpsDAO
{
    private static CurpsDAO _instancia = null;

    public static CurpsDAO instancia()
    {
        return _instancia == null ? new CurpsDAO() : _instancia;
    }

    public CurpsDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }


    ////Validación CURP SEBICO
    public List<CurpsVO> getCurps()
    {
        string str = "SELECT curp  FROM proyecto_emergente.encuesta where estatus is null;";
        List<CurpsVO> curps = new List<CurpsVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            curps = (from DataRow row in dt.Rows select new CurpsVO() { curp = row["curp"].ToString() }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return curps;
    }
    public void insertConsulta(CurpsVO lstcurp)
    {
        string str = "call proyecto_emergente.sp_insert_consulta('" + lstcurp.curp+"','"+lstcurp.nombres + "','" +lstcurp.apellido1 + "','" + lstcurp.apellido2 + "','" + lstcurp.nacionalidad + "','" + lstcurp.fechNac + "','" + lstcurp.sexo + "','" + lstcurp.cveEntidadNac + "','" + lstcurp.docProbatorio + "','" + lstcurp.numEntidadReg + "','" + lstcurp.cveMunicipioReg + "','" + lstcurp.anioReg + "','" + lstcurp.numActa + "','" + lstcurp.foja + "','" + lstcurp.libro + "','" + lstcurp.tomo + "','" + lstcurp.statusCurp + "','" + lstcurp.cveEntidadEmisora + "','" + lstcurp.statusOper + "','" + lstcurp.message + "','" + lstcurp.nr_descEntidadNac + "','" + lstcurp.nr_descDocProbatorio + "','" + lstcurp.nr_descEntidadReg + "','" + lstcurp.nr_descMunicipioReg + "','" + lstcurp.nr_descStatusCurp + "','" + lstcurp.nr_descTipoStatusCurp + "','" + lstcurp.curphistorica + "','" + lstcurp.codigoError + "','" + lstcurp.crip + "','" + lstcurp.folioCarta + "','" + lstcurp.numRegExtranjeros + "','" + lstcurp.tipoError + "','" + lstcurp.sessionID + "');";

        try { Generico.instancia().seleccionar(str.ToString(), Constante.BD_SNIIV); }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
    }

}