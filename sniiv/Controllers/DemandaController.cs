using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sniiv.Controllers
{
    public class DemandaController : Controller
    {
        public IActionResult Potencial()
        {
            List<CatalogoVO> lst = DemandaPotencialDAO.instancia().seleccionarAnio();
            List<SelectListItem> anios = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            lst = DemandaPotencialDAO.instancia().seleccionarMes(Convert.ToInt32(lst.First().id));
            List<SelectListItem> meses = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            ViewBag.anios = anios;
            ViewBag.meses = meses;
            return View();
        }
        public IActionResult Rezago_estatal()
        {
            List<CatalogoVO> lst = RezagoDAO.instancia().seleccionarAnioEstatal();
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

        public IActionResult Rezago_municipal()
        {
            List<CatalogoVO> lst = RezagoDAO.instancia().seleccionarAnioMunicipal();
            List<SelectListItem> anios = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = CatalogoDAO.instancia().seleccionarEntidadFederativa();
            List<SelectListItem> estados = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            ViewBag.anios = anios;
            ViewBag.estados = estados;
            return View();
        }

        public IActionResult Poblacion_historico()
        {
            return View();
        }

        public IActionResult Poblacion_proyeccion()
        {
            return View();
        }
    }
}
