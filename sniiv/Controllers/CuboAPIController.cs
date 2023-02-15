using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sniiv.Data;
using sniiv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sniiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuboAPIController : ControllerBase
    {
        private readonly AppDBContext _context;
        public CuboAPIController(AppDBContext context)
        {
            _context = context;
        }
        #region DEMANDA
        [HttpGet("GetFinanciamiento/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<FinanciamientosVO> GetFinanciamiento(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return FinanciamientosDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }

        [HttpGet("GetCONAVI/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<ConaviVO> GetCONAVI(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return ConaviDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }

        [HttpGet("GetFOVISSSTE/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<FovisssteVO> GetFOVISSSTE(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return FovisssteDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }

        [HttpGet("GetINFONAVIT/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<InfonavitVO> GetINFONAVIT(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return InfonavitDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }

        //Posiblemente obsoleto
        [HttpGet("GetFONHAPO/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<FonhapoVO> GetFONHAPO(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return FonhapoDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }

        [HttpGet("GetCNBV/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<CnbvVO> GetCNBV(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return CnbvDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }

        [HttpGet("GetISSSTE/{periodo}/{clave_estado}/{dimensiones}")]
        public List<IsssteVO> GetISSSTE(string periodo, string clave_estado, string dimensiones)
        {
            return IsssteDAO.instancia().getCubo(periodo, clave_estado, dimensiones);
        }

        [HttpGet("GetIMSS/{periodo}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<ImssVO> GetIMSS(string periodo, string clave_estado, string clave_municipio, string dimensiones)
        {
            return ImssDAO.instancia().getCubo(periodo, clave_estado, clave_municipio, dimensiones);
        }

        [HttpGet("GetIMSSEstatal/{periodo}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public IActionResult GetIMSSEstatal(string periodo, string clave_estado, string clave_municipio, string dimensiones)
        {
            var anio = Int32.Parse(periodo.Split(',').FirstOrDefault());
            var mes = Int32.Parse(periodo.Split(',').Last());
            var vars = dimensiones.Split(',');
            var includeAño = false;
            var includeEstado = false;
            var includeGenero = false;
            var includeEdad = false;
            var includeSalario = false;
            var includeEconomico = false;
            foreach (var parametro in vars)
            {
                switch (parametro)
                {
                    case "anio":
                        includeAño = true;
                        break;
                    case "estado":
                        includeEstado = true;
                        break;
                    case "genero":
                        includeGenero = true;
                        break;
                    case "rango_edad":
                        includeEdad = true;
                        break;
                    case "rango_salarial":
                        includeSalario = true;
                        break;
                    default:
                        includeEconomico = true;
                        break;
                }
            }
                IEnumerable<cubo_imss_rpt> ccb = _context.cubo_imss_rpt.Where(p => p.anio.Equals(anio)).Where(p => p.mes.Equals(mes));
                var hey = ccb.GroupBy(x =>
                        new {
                            año = includeAño ? x.anio : 0,
                            estado = includeEstado ? x.clave_entidad_federativa : null,
                            genero = includeGenero ? x.id_genero : 0,
                            edad = includeEdad ? x.id_rango_edad : 0,
                            salario = includeSalario ? x.id_rango_salarial : 0,
                            economico = includeEconomico ? x.id_sector_economico_1 : 0,

                        }
                    ).Select(x =>
                      new {
                          año = includeAño ? x.FirstOrDefault().anio : 0,
                          estado = includeEstado ? _context.c_entidad_federativa.ToList().Where(t => t.clave == x.FirstOrDefault().clave_entidad_federativa).FirstOrDefault().descripcion : null,
                          sexo = includeGenero ? _context.c_genero.ToList().Where(t => t.id == x.FirstOrDefault().id_genero).FirstOrDefault().descripcion : null,
                          grupo_edad = includeEdad ? _context.c_rango_edad_imss.ToList().Where(t => t.id_rango_edad_conavi == x.FirstOrDefault().id_rango_edad).FirstOrDefault().descripcion : null,
                          rango_salarial = includeSalario ? _context.c_rango_salarial_imss.ToList().Where(t => t.id_rango_salarial_conavi == x.FirstOrDefault().id_rango_salarial).FirstOrDefault().descripcion : null,
                          sector_economico = includeEconomico ? _context.c_sector_economico_1.ToList().Where(t => t.id == x.FirstOrDefault().id_sector_economico_1).FirstOrDefault().descripcion : null,
                          trabajadores = x.Sum(t => t.trabajadores)

                      }).ToList();

                return Ok(hey);
            
        }

        [HttpGet("GetInsus/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<InsusVO> GetInsus(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return InsusDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }
        #endregion

        #region OFERTA
        [HttpGet("GetInventario/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<InventarioVO> GetInventario(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return InventarioDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }

        [HttpGet("GetRegistro/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<RegistroViviendaVO> GetRegistro(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return RegistroViviendaDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }
        #endregion

        [HttpGet("GetSisevive/{anios}/{clave_estado}/{clave_municipio}/{dimensiones}")]
        public List<SiseviveVO> GetSisevive(string anios, string clave_estado, string clave_municipio, string dimensiones)
        {
            return SiseviveDAO.instancia().getCubo(anios, clave_estado, clave_municipio, dimensiones);
        }

        [HttpGet("GetDesarrollador/{anio}/{mes}/{clave_estado}/{clave_municipio}")]
        public List<DesarrolladorFovisssteVO> GetDesarrollador(string anio, string mes, string clave_estado, string clave_municipio)
        {
            return FovisssteDAO.instancia().getDesarrollador(anio, mes, clave_estado, clave_municipio);
        }

        [HttpGet("GetSemanal/{anios}/{clave_estado}/{dimensiones}")]
        public List<SemanalVO> GetSemanal(string anios, string clave_estado, string dimensiones)
        {
            return FinanciamientosDAO.instancia().getCubo(anios, clave_estado, dimensiones);
        }
    }
}
