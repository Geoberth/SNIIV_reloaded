using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sniiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardAPIController : ControllerBase
    {
        // CONAVI
        [HttpGet("GetKPIsCONAVI")]
        public List<ConaviVO> GetKPIsCONAVI()
        {
            return ConaviDAO.instancia().getKPIs();
        }
        [HttpGet("GetKPIsCONAVI2")]
        public List<ConaviVO> GetKPIsCONAVI2()
        {
            return ConaviDAO.instancia().getKPIs2();
        }
        [HttpGet("GetKPIsCONAVI/{programa}/{clave}/{anio}")]
        public List<ReportePresidenciaVO> GetKPIsCONAVI(int programa, string clave, int anio)
        {
            return ReportePresidenciaDAO.instancia().getKPIs(programa, Convert.ToBoolean(Int16.Parse(clave)), anio);
        }

        // Financiamientos
        [HttpGet("GetKPIsFinanciamiento")]
        public List<FinanciamientosVO> GetKPIsFinanciamiento()
        {
            return FinanciamientosDAO.instancia().getKPIs();
        }
        [HttpGet("GetKPIsFinanciamiento2")]
        public List<FinanciamientosVO> GetKPIsFinanciamiento2()
        {
            return FinanciamientosDAO.instancia().getKPIs2();
        }

        // Registro
        [HttpGet("GetKPIsRegistro")]
        public List<RegistroViviendaVO> GetKPIsRegistro()
        {
            return RegistroViviendaDAO.instancia().getKPIs();
        }
        [HttpGet("GetKPIsRegistro2/{anio_inicio}/{anio_fin}")]
        public List<OfertaVO> GetKPIsRegistro2(int anio_inicio, int anio_fin)
        {
            return OfertaDAO.instancia().getKPIsOferta(anio_inicio, anio_fin);
        }

        // Inventario
        [HttpGet("GetKPIsInventario")]
        public List<InventarioVO> GetKPIsInventario()
        {
            return InventarioDAO.instancia().getKPIs();
        }
        [HttpGet("GetKPIsInventario2/{anio}/{mes}")]
        public List<OfertaInventarioVO> GetKPIsInventario2(int anio, int mes)
        {
            return OfertaInventarioDAO.instancia().getKPIsOfertaInventario(anio, mes);
        }

        // Sisevive
        [HttpGet("GetKPIsSisevive/{anio_inicio}/{anio_fin}")]
        public List<SiseviveVO> GetKPIsSisevive(int anio_inicio, int anio_fin)
        {
            return SiseviveDAO.instancia().getKPIs(anio_inicio, anio_fin);
        }

        // Imss
        [HttpGet("GetKPIsImss/{anio}")]
        public List<ImssVO> GetKPIsImss(int anio)
        {
            return ImssDAO.instancia().getKPIs(anio);
        }

        // Issste
        [HttpGet("GetKPIsIssste/{anio}")]
        public List<IsssteVO> GetKPIsIssste(int anio)
        {
            return IsssteDAO.instancia().getKPIs(anio);
        }

        // Metas
        [HttpGet("getMetasConavi/{anio}")]
        [Produces("application/json")]
        public Stream getMetasConavi(int anio)
        {
           
            DataTable tblMeta = ConaviDAO.instancia().seleccionarMeta(anio);
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tblMeta, Formatting.Indented)));
        }

        [HttpGet("getMetasFovissste/{anio}")]
        [Produces("application/json")]
        public Stream getMetasFovissste(int anio)
        {
            DataTable tblMeta = FovisssteDAO.instancia().seleccionarMeta(anio);
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tblMeta, Formatting.Indented)));
        }

        [HttpGet("getMetasInfonavit/{anio}")]
        [Produces("application/json")]
        public Stream getMetasInfonavit(int anio)
        {
            DataTable tblMeta = InfonavitDAO.instancia().seleccionarMeta(anio);
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tblMeta, Formatting.Indented)));
        }

        //Semanal
        [HttpGet("getKPIsSemanalFinanciamientos/{id_region}")]
        public List<SemanalVO> getKPIsSemanalFinanciamientos(int id_region)
        {
            return FinanciamientosDAO.instancia().getKPIsSemanalFinanciamientos(id_region);
        }
        [HttpGet("getKPIsSemanalHipotecario/{id_region}")]
        public List<SemanalVO> getKPIsSemanalHipotecario(int id_region)
        {
            return FinanciamientosDAO.instancia().getKPIsSemanalHipotecario(id_region);
        }
        [HttpGet("getSemanalFinanciamientos/{id_region}/{clave_estado}/{anio}/{semanas}/{organismo}")]
        public List<SemanalVO> getSemanalFinanciamientos(int id_region, string clave_estado, int anio, string semanas, string organismo)
        {
            return FinanciamientosDAO.instancia().getSemanalFinanciamientos(id_region, clave_estado, anio, semanas, organismo);
        }
        [HttpGet("getSemanalHipotecario/{id_region}/{clave_estado}/{anio}/{semanas}/{organismo}")]
        public List<SemanalVO> getSemanalHipotecario(int id_region, string clave_estado, int anio, string semanas, string organismo)
        {
            return FinanciamientosDAO.instancia().getSemanalHipotecario(id_region, clave_estado, anio, semanas, organismo);
        }
        [HttpGet("getSemanas/{anio}")]
        public string getSemanas(int anio)
        {
            return FinanciamientosDAO.instancia().getSemanaMinMax(anio);
        }
    }
}
