using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sniiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoAPIController : ControllerBase
    {
        [HttpGet("GetEntidadFederativa/{desa}")]
        public List<CatalogoVO> GetEntidadFederativa(int desa)
        {
            List<CatalogoVO> lst = new List<CatalogoVO>();
            lst.Add(new CatalogoVO { id = "0", descripcion = "..." });
            if (desa.Equals(1))
            {
                lst.Add(new CatalogoVO { id = Constante.FORMATO_ESTATAL, descripcion = "Todos los estados" });
            }
            lst.AddRange(CatalogoDAO.instancia().seleccionarEntidadFederativa());
            return lst;
        }

        [HttpGet("GetEntidadFederativaRegion/{region}")]
        public List<CatalogoVO> GetEntidadFederativaRegion(int region)
        {
            List<CatalogoVO> lst = new List<CatalogoVO>();
            lst.Add(new CatalogoVO { id = "0", descripcion = "Todos los estados" });
            lst.AddRange(CatalogoDAO.instancia().seleccionarEntidadFederativa(region));
            return lst;
        }

        [HttpGet("GetMunicipio/{clave_estado}/{desa}")]
        public List<CatalogoVO> GetMunicipio(string clave_estado,int desa)
        {
            List<CatalogoVO> lst = new List<CatalogoVO>();
            lst.Add(new CatalogoVO { id = "0", descripcion = "..." });
            if (desa.Equals(1))
            {
                lst.Add(new CatalogoVO { id = Constante.FORMATO_MUNICIPAL, descripcion = "Todos los municipios" });
            }
            lst.AddRange(CatalogoDAO.instancia().seleccionarMunicipio(clave_estado));
            return lst;
        }

        [HttpGet("GetMesInventario/{anio}")]
        public List<CatalogoVO> GetMesInventario(int anio)
        {
            return InventarioDAO.instancia().seleccionarMesInventario(anio);
        }

        [HttpGet("GetTrimestreInventario/{anio}")]
        public List<CatalogoVO> GetTrimestreInventario(int anio)
        {
            return DiasInventarioDAO.instancia().seleccionarTrimestre(anio);
        }

        [HttpGet("GetPrograma/{anio}")]
        public List<CatalogoVO> GetPrograma(int anio)
        {
            return ReportePresidenciaDAO.instancia().seleccionarPrograma(anio);
        }

        [HttpGet("GetMesDatosAbiertos/{tipo}/{anio}")]
        public List<CatalogoVO> GetMesDatosAbiertos(int tipo, int anio)
        {
            return DatosAbiertosDAO.instancia().seleccionarMes(tipo, anio);
        }

        [HttpGet("GetMesReporteMensual/{anio}")]
        public List<CatalogoVO> GetMesReporteMensual(int anio)
        {
            return ReporteMensualDAO.instancia().seleccionarMes(anio);
        }

        [HttpGet("GetMesImss/{anio}")]
        public List<CatalogoVO> GetMesImss(int anio)
        {
            return ImssDAO.instancia().seleccionarMes(anio);
        }

        [HttpGet("GetMesIssste/{anio}")]
        public List<CatalogoVO> GetMesIssste(int anio)
        {
            return IsssteDAO.instancia().seleccionarMes(anio);
        }

        [HttpGet("GetMesFovissste/{anio}")]
        public List<CatalogoVO> GetMesFovissste(int anio)
        {
            return FovisssteDAO.instancia().seleccionarMes(anio);
        }

        [HttpGet("GetFechasMapa")]
        public List<CatalogoVO> GetFechasMapa()
        {
            return CatalogoDAO.instancia().seleccionarFechasMapa();
        }

        [HttpGet("GetRegion")]
        public List<CatalogoVO> GetRegion()
        {
            return CatalogoDAO.instancia().seleccionarRegion();
        }

        [HttpGet("GetMesPotencial/{anio}")]
        public List<CatalogoVO> GetMesPotencial(int anio)
        {
            return DemandaPotencialDAO.instancia().seleccionarMes(anio);
        }

    }
}
