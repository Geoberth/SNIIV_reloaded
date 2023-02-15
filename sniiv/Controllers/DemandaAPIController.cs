using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sniiv.Data;
using sniiv.Models;
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
    public class DemandaAPIController : ControllerBase
    {

        private readonly AppDBContext _context;

        public DemandaAPIController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetDemandaPotencial/{anio}/{mes}")]
        public IActionResult GetDemandaPotencial(int anio,int mes)
        {
            IEnumerable<demanda_potencial_infonavit> ccb = _context.demanda_potencial_infonavit.Where(x => x.anio.Equals(anio)).Where(x => x.mes.Equals(mes));
            var hey = ccb
                .GroupBy(x => new
                {
                    x.id_salario_infonavit,
                    x.clave_entidad_federativa
                })
                .Select(x =>
             new
             {

                 id_estado = x.FirstOrDefault().clave_entidad_federativa,
                 estado = _context.c_entidad_federativa.Where(t => t.clave.Equals(x.FirstOrDefault().clave_entidad_federativa)).FirstOrDefault().descripcion,
                 id_salario = x.FirstOrDefault().id_salario_infonavit,
                 descripcion = _context.c_salario_infonavit.Where(t => t.id.Equals(x.FirstOrDefault().id_salario_infonavit)).FirstOrDefault().descripcion,
                 total = x.Sum(t => t.valor)
             }).ToList()
             .GroupBy(x => new
             {
                 x.id_estado
             }).Select( x => new{
                 id_estado = x.FirstOrDefault().id_estado,
                 estado = _context.c_entidad_federativa.Where(t => t.clave.Equals(x.FirstOrDefault().id_estado)).FirstOrDefault().descripcion,
                 total = x.Last().total,
                 resultado = x.OrderBy(x=> x.id_salario),
                 
             });
            

            return Ok(hey);
        }


        [HttpGet("GetDemandaPotencialMunicipal/{anio}/{mes}/{estado}")]
        public IActionResult GetDemandaPotencialMunicpal(int anio, int mes, string estado)
        {
            IEnumerable<demanda_potencial_infonavit> ccb = _context.demanda_potencial_infonavit.Where(x => x.anio.Equals(anio)).Where(x => x.mes.Equals(mes)).Where(x => x.clave_entidad_federativa.Equals(estado));
            var hey = ccb
                .GroupBy(x => new
                {
                    x.id_salario_infonavit,
                    x.clave_municipio
                })
                .Select(x =>
             new
             {

                 id_estado = x.FirstOrDefault().clave_municipio,
                 estado = _context.c_municipio.Where(t => t.clave_entidad_federativa.Equals(x.FirstOrDefault().clave_entidad_federativa)).Where(t => t.clave_mun.Equals(x.FirstOrDefault().clave_municipio)).FirstOrDefault().descripcion,
                 id_salario = x.FirstOrDefault().id_salario_infonavit,
                 descripcion = _context.c_salario_infonavit.Where(t => t.id.Equals(x.FirstOrDefault().id_salario_infonavit)).FirstOrDefault().descripcion,
                 total = x.Sum(t => t.valor)
             })
             .GroupBy(x => new
             {
                 x.id_estado
             }).Select(x => new {
                 id_estado = x.FirstOrDefault().id_estado,
                 estado = x.FirstOrDefault().estado,
                 total = x.Last().total,
                 resultado = x.OrderBy(x => x.id_salario),

             });


            return Ok(hey);
        }

        // Rezago
        [HttpGet("GetRezagoEstatal/{anio}")]
        public List<RezagoVO> GetRezagoEstatal(int anio)
        {
            return RezagoDAO.instancia().getRezagoEstatal(anio);
        }
        [HttpGet("GetTotalRezagoEstatal/{anio}/{clave_estado}")]
        public RezagoVO GetTotalRezagoEstatal(int anio, string clave_estado)
        {
            return RezagoDAO.instancia().getTotalRezagoEstatal(anio, clave_estado);
        }

        [HttpGet("GetRezagoMunicipal/{anio}/{clave_estado}")]
        public List<RezagoVO> GetRezagoMunicipal(int anio, string clave_estado)
        {
            return RezagoDAO.instancia().getRezagoMunicipal(anio, clave_estado);
        }
        [HttpGet("GetTotalRezagoMunicipal/{anio}/{clave_estado}/{clave_municipio}")]
        public RezagoVO GetTotalRezagoMunicipal(int anio, string clave_estado, string clave_municipio)
        {
            return RezagoDAO.instancia().getTotalRezagoMunicipal(anio, clave_estado, clave_municipio);
        }

        // Población
        // Transform SP to SQL Query
        [HttpGet("GetPoblacionEstatal/{anio}")]
        public Stream GetPoblacionEstatal()
        {
            DataTable tblEstatal = InegiDAO.instancia().seleccionarPoblacionEstatal();
            //WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tblEstatal, Formatting.Indented)));
        }
        [HttpGet("GetPoblacionMunicipal/{clave_estado}")]
        public Stream GetPoblacionMunicipal(string clave_estado)
        {
            DataTable tblMunicipal = InegiDAO.instancia().seleccionarPoblacionMunicipal(clave_estado);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tblMunicipal, Formatting.Indented)));
        }
        // Proyección
        [HttpGet("GetProyeccionEstatal/{anio}")]
        public Stream GetProyeccionEstatal()
        {
            DataTable tblEstatal = ConapoDAO.instancia().seleccionarPoblacionEstatal();
            //WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tblEstatal, Formatting.Indented)));
        }
        [HttpGet("GetProyeccionMunicipal/{clave_estado}")]
        public Stream GetProyeccionMunicipal(string clave_estado)
        {
            DataTable tblMunicipal = ConapoDAO.instancia().seleccionarPoblacionMunicipal(clave_estado);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
            return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tblMunicipal, Formatting.Indented)));
        }
    }
}
