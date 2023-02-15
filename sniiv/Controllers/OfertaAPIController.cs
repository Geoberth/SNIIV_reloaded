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
    public class OfertaAPIController : ControllerBase
    {
        //Renaret
        [HttpGet("GetRenaretEstatal/{anio}")]
        public List<RenaretVO> GetRenaretEstatal(int anio)
        {
            return RenaretDAO.instancia().getRenaretEstatal(anio);
        }
        [HttpGet("GetRenaretMunicipal/{anio}/{clave_estado}")]
        public List<RenaretVO> GetRenaretMunicipal(int anio, string clave_estado)
        {
            return RenaretDAO.instancia().getRenaretMunicipal(anio, clave_estado);

        }

        //Parque habitacional
        [HttpGet("GetParqueEstatal/{anio}")]
        public List<ParqueHabitacionalVO> GetParqueEstatal(int anio)
        {
            return ParqueHabitacionalDAO.instancia().seleccionarEstatal(anio);
        }
        [HttpGet("GetParqueMunicipal/{anio}/{clave_estado}")]
        public List<ParqueHabitacionalVO> GetParqueMunicipal(int anio, string clave_estado)
        {
            return ParqueHabitacionalDAO.instancia().seleccionarMunicipal(anio, clave_estado);

        }

        //Días de inventario
        [HttpGet("GetInventarioEstatal/{anio}/{trimestre}")]
        public List<DiasInventarioVO> GetInventarioEstatal(int anio, int trimestre)
        {
            return DiasInventarioDAO.instancia().seleccionarEstatal(anio, trimestre);
        }
        [HttpGet("GetTotalInventarioEstatal/{anio}/{trimestre}")]
        public DiasInventarioVO GetTotalInventarioEstatal(int anio, int trimestre)
        {
            return DiasInventarioDAO.instancia().getTotalEstatal(anio, trimestre);
        }
        [HttpGet("GetInventarioMunicipal/{anio}/{trimestre}/{clave_estado}/{registro}")]
        public List<DiasInventarioVO> GetInventarioMunicipal(int anio, int trimestre, string clave_estado, int registro)
        {
            return DiasInventarioDAO.instancia().seleccionarMunicipal(anio, trimestre, clave_estado, registro);

        }
        [HttpGet("GetTotalInventarioMunicipal/{anio}/{trimestre}/{clave_estado}")]
        public DiasInventarioVO GetTotalInventarioMunicipal(int anio, int trimestre, string clave_estado)
        {
            return DiasInventarioDAO.instancia().getTotalMunicipal(anio, trimestre, clave_estado);

        }
    }
}
