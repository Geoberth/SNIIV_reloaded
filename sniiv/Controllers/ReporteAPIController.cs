using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sniiv.Data;
using sniiv.Models;

namespace sniiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteAPIController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ReporteAPIController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetDocumentoAnio/{tipo}/{anio}/{formato}")]
        public IActionResult GetDocumentoAnio(int tipo, int anio, int formato)
        {
            string subsi;
            switch (tipo)
            {
                case 1:
                    subsi = "Subsidios";
                    break;
                case 2:
                    subsi = "Financiamientos";
                    break;
                case 3:
                    subsi = "Oferta vivienda";
                    break;
                case 4:
                    subsi = "Registro vivienda";
                    break;
                case 5:
                    subsi = "Días inventario";
                    break;
                case 6:
                    subsi = "Padrón beneficiario";
                    break;
                case 7:
                    subsi = "CNBV";
                    break;
                default:
                    subsi = "Subsidios";
                    break;
            }
            var query = _context.datos_abiertos
                .Where(d => d.tipo.Equals(subsi))
                .Where(d => d.anio.Equals(anio))
                .Where(d => d.formato.Equals(formato))
                .Select(d => new
                {
                    documento = d.url
                }).FirstOrDefault();
            return Ok(query);
        }

        [HttpGet("GetDocumentoMes/{tipo}/{anio}/{mes}/{formato}")]
        public IActionResult GetDocumentoMes(int tipo, int anio, int mes, int formato)
        {
            string subsi;
            switch (tipo)
            {
                case 1:
                    subsi = "Subsidios";
                    break;
                case 2:
                    subsi = "Financiamientos";
                    break;
                case 3:
                    subsi = "Oferta vivienda";
                    break;
                case 4:
                    subsi = "Registro vivienda";
                    break;
                case 5:
                    subsi = "Días inventario";
                    break;
                case 6:
                    subsi = "Padrón beneficiario";
                    break;
                case 7:
                    subsi = "CNBV";
                    break;
                default:
                    subsi = "Subsidios";
                    break;
            }
            var query = _context.datos_abiertos
                .Where(d => d.tipo.Equals(subsi))
                .Where(d => d.anio.Equals(anio))
                .Where(d => d.mes.Equals(mes))
                .Where(d => d.formato.Equals(formato))
                .Select(d => new
                {
                    documento = d.url
                }).FirstOrDefault();
            return Ok(query);
        }

        [HttpGet("GetReporteMensual/{anio}/{mes}")]
        public IActionResult GetReporteMensual(int anio, int mes)
        {
            var query = _context.reporte_mensual.Where(d => d.anio.Equals(anio)).Where(d => d.mes.Equals(mes))
                .Select(d => new
                {
                    documento = d.url
                }).FirstOrDefault();

            return Ok(query);
        }

        [HttpGet("GetFinanciamientosTotal/{añoinicio}/{añofin}")]
        public IActionResult GetFinanciamientosTotal(int añoinicio,int añofin)
        {
            IEnumerable<cubo_financiamientos> query = _context.cubo_financiamientos.Where(t => t.anio >= añoinicio).Where(t => t.anio <= añofin);
            var query1 = query
                .GroupBy(x => new {
                    x.anio,
                    x.id_modalidad
                }).Select(x => new { 
                    año = x.FirstOrDefault().anio,
                    modalidad = _context.c_modalidad_sniiv.Where( t => t.id.Equals(x.FirstOrDefault().id_modalidad)).FirstOrDefault().descripcion,
                    monto = x.Sum(t => t.monto),
                    acciones = x.Sum(t => t.acciones),
                }).OrderBy(x => x.año)
                .GroupBy(x => new { 
                    x.año
                }).Select( x => new { 
                    año = x.FirstOrDefault().año,
                    resultado = x.OrderBy(x => x.año)
                });
            return Ok(query1);
        }

    }
}
