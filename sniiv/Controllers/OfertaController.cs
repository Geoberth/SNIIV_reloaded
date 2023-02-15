using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sniiv.Controllers
{
    public class OfertaController : Controller
    {
        public IActionResult Renaret()
        {
            List<CatalogoVO> lst = RenaretDAO.instancia().seleccionarAnio();
            List<SelectListItem> anios = lst.ConvertAll(d => 
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false

                }; 
            });
            ViewBag.anios = anios;
            ViewBag.fecha = Util.instancia().getLeyendaFecha(RenaretDAO.instancia().seleccionarFecha()).Replace("Al", "al"); ;
            return View();
        }

        public IActionResult Parque()
        {
            List<CatalogoVO> lst = ParqueHabitacionalDAO.instancia().seleccionarAnio();
            List<SelectListItem> anios = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false

                };
            });
            ViewBag.anios = anios;
            return View();
        }

        public IActionResult Mapa()
        {
            ViewBag.environment = "https://sniiv.sedatu.gob.mx/homemx/";
            return View();
        }

        public IActionResult Dias_inventario()
        {
            List<CatalogoVO> lst = DiasInventarioDAO.instancia().seleccionarAnio();
            List<SelectListItem> anios = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.anios = anios;
            lst = DiasInventarioDAO.instancia().seleccionarTrimestre(Convert.ToInt32(lst.First().id));
            List<SelectListItem> trimestres = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.trimestres = trimestres;
            return View();
        }
    }
}
