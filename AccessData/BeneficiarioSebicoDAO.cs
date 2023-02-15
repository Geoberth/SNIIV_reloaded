using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

public class BeneficiarioSebicoDAO
{
    private static BeneficiarioSebicoDAO _instancia = null;

    public static BeneficiarioSebicoDAO instancia()
    {
        return _instancia == null ? new BeneficiarioSebicoDAO() : _instancia;
    }

    public BeneficiarioSebicoDAO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<BeneficiarioSebicoVO> seleccionarBeneficiarios()
    {
        string str = "call proyecto_emergente.sp_get_beneficiario_sebico(0);";
        List<BeneficiarioSebicoVO> evaluadores = new List<BeneficiarioSebicoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            evaluadores = (from DataRow row in dt.Rows
                           select new BeneficiarioSebicoVO()
                           {
                               id = Convert.ToInt32(row["id"].ToString()),
                               curp = row["curp"].ToString(),
                               nombre = row["nombre"].ToString(),
                               paterno = row["primer_apellido"].ToString(),
                               materno = row["segundo_apellido"].ToString(),
                               entidad = row["estado"].ToString(),
                               //municipio = row["municipio"].ToString(),
                               //localidad = row["localidad"].ToString(),
                               total_ampliacion = row["total_ampliacion"].ToString(),
                               total_mejoramiento = row["total_mejoramiento"].ToString(),
                               estatus_curp = row["estatus_curp"].ToString(),
                               estatus_sap = row["estatus_sap"].ToString(),
                               estatus_eligibilidad = row["estatus_eligibilidad"].ToString()
                           }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return evaluadores;
    }

    public List<BeneficiarioSebicoVO> seleccionarEncuesta(string id)
    {
        string str = "call proyecto_emergente.sp_get_beneficiario_sebico(" + id + ");";
        List<BeneficiarioSebicoVO> evaluadores = new List<BeneficiarioSebicoVO>();

        try
        {
            DataTable dt = Generico.instancia().seleccionar(str, Constante.BD_SNIIV);
            evaluadores = (from DataRow row in dt.Rows
                           select new BeneficiarioSebicoVO()
                           {
                               id = Convert.ToInt32(row["id"].ToString()),
                               curp = row["curp"].ToString(),
                               nombre = row["nombre"].ToString(),
                               paterno = row["primer_apellido"].ToString(),
                               materno = row["segundo_apellido"].ToString(),
                               entidad = row["estado"].ToString(),
                               municipio = row["municipio"].ToString(),
                               localidad = row["localidad"].ToString(),
                               cp = row["cp"].ToString(),
                               calle = row["calle"].ToString(),
                               colonia = row["colonia"].ToString(),
                               num_ext = row["num_ext"].ToString(),
                               num_int = row["num_int"].ToString(),
                               telefono = row["telefono"].ToString(),
                               ingreso_mensual_hogar = row["ingreso_mensual_hogar"].ToString(),
                               integrantes_ingreso_hogar = row["integrantes_ingreso_hogar"].ToString(),
                               cantidad_individual = row["cantidad_individual"].ToString(),
                               cantidad_integrantes = row["cantidad_integrantes"].ToString(),

                               derechohabiente = row["derechohabiente"].ToString(),
                               tipo_vivienda = row["tipo_vivienda"].ToString(),
                               situacion_vivienda = row["situacion_vivienda"].ToString(),
                               propietario = row["propietario"].ToString(),

                               num_personas = row["num_personas"].ToString(),
                               num_indigenas = row["num_indigenas"].ToString(),
                               num_discapacitados = row["num_discapacitados"].ToString(),
                               num_menores = row["num_menores"].ToString(),
                               num_madres_solteras = row["num_madres_solteras"].ToString(),
                               madre_soltera = row["madre_soltera"].ToString(),
                               num_cuartos = row["num_cuartos"].ToString(),
                               num_recamaras = row["num_recamaras"].ToString(),

                               alto_riesgo = row["alto_riesgo"].ToString(),
                               riesgo = row["riesgo"].ToString(),
                               seguridad = row["seguridad"].ToString(),
                               agua = row["agua"].ToString(),
                               sanitario = row["sanitario"].ToString(),
                               cocina = row["cocina"].ToString(),
                               electricidad = row["electricidad"].ToString(),
                               pared = row["pared"].ToString(),
                               techo = row["techo"].ToString(),
                               piso = row["piso"].ToString(),
                               tipo_apoyo = row["tipo_apoyo"].ToString(),
                               uso_ampliacion = row["uso_ampliacion"].ToString(),
                               uso_mejoramiento = row["uso_mejoramiento"].ToString(),
                               uso_ampliacion2 = row["uso_ampliacion2"].ToString(),
                               uso_mejoramiento2 = row["uso_mejoramiento2"].ToString()
                           }).ToList();
        }
        catch (Exception ex) { Util.instancia().setLogError(ex); }
        return evaluadores;
    }
}
