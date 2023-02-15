using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace sniiv.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Inicio()
        {
            ViewBag.fechaSubsidios = replaceDate(Util.instancia().getLeyendaFecha(ConaviDAO.instancia().seleccionarFecha()));
            ViewBag.fechaFinanciamientos = replaceDate(Util.instancia().getLeyendaFecha(FinanciamientosDAO.instancia().seleccionarFecha()));
            ViewBag.fechaRegistro = replaceDate(Util.instancia().getLeyendaFecha(RegistroViviendaDAO.instancia().seleccionarFecha()));
            ViewBag.fechaInventario = InventarioDAO.instancia().seleccionarFecha().Year.ToString();
            return View();
        }

        public string replaceDate(string fecha) {
            return fecha.Replace("Al", "Del");
        }

        public IActionResult Oferta()
        {
            List<CatalogoVO> lst = RegistroViviendaDAO.instancia().seleccionarAnio();
            List<SelectListItem> aniosRegistro = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.aniosRegistro = aniosRegistro;
            ViewBag.fechaRegistro = Util.instancia().getLeyendaFecha(RegistroViviendaDAO.instancia().seleccionarFecha());

            lst = InventarioDAO.instancia().seleccionarAnioInventario();
            List<SelectListItem> aniosInventario = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.aniosInventario = aniosInventario;
            lst = InventarioDAO.instancia().seleccionarMesInventario(Convert.ToInt32(lst.First().id));
            List<SelectListItem> mesesInventario = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.mesesInventario = mesesInventario;
            ViewBag.fechaInventario = Util.instancia().getLeyendaFecha(InventarioDAO.instancia().seleccionarFecha());
            return View();
        }

        public IActionResult Demanda()
        {
            ViewBag.fechaSubsidios = Util.instancia().getLeyendaFecha(ConaviDAO.instancia().seleccionarFecha());
            ViewBag.fechaFinanciamientos = Util.instancia().getLeyendaFecha(FinanciamientosDAO.instancia().seleccionarFecha());
            return View();
        }

        public IActionResult Sisevive()
        {
            List<CatalogoVO> lst = SiseviveDAO.instancia().seleccionarAnio();
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
            ViewBag.fecha = Util.instancia().getLeyendaFecha(SiseviveDAO.instancia().seleccionarFecha());
            return View();
        }

        public IActionResult Conavi()
        {
            List<CatalogoVO> lst = ReportePresidenciaDAO.instancia().seleccionarAnio();
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
            lst = ReportePresidenciaDAO.instancia().seleccionarPrograma(Convert.ToInt16(lst.First().id));
            List<SelectListItem> programas = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.programas = programas;
            ViewBag.fecha = Util.instancia().getLeyendaFecha(ReportePresidenciaDAO.instancia().seleccionarFecha());
            return View();
        }

        public IActionResult Imss()
        {
            List<CatalogoVO>  lst = ImssDAO.instancia().seleccionarAnio();
            List<SelectListItem> anios = lst.ConvertAll(d => { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            ViewBag.anios = anios;
            /*lst = ImssDAO.instancia().seleccionarMes(Convert.ToInt32(lst.First().id));
            List<SelectListItem> meses = lst.ConvertAll(d => { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            ViewBag.meses = meses;*/
            ViewBag.fecha = Util.instancia().getLeyendaFecha(ImssDAO.instancia().seleccionarFecha());
            return View();
        }

        public IActionResult Issste()
        {
            List<CatalogoVO> lst = IsssteDAO.instancia().seleccionarAnio();
            List<SelectListItem> anios = lst.ConvertAll(d => { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            ViewBag.anios = anios;
            lst = IsssteDAO.instancia().seleccionarMes(Convert.ToInt32(lst.First().id));
            List<SelectListItem> meses = lst.ConvertAll(d => { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            ViewBag.meses = meses;
            ViewBag.fecha = Util.instancia().getLeyendaFecha(IsssteDAO.instancia().seleccionarFecha());
            return View();
        }

        [Authorize(Roles = "Reporte semanal,Consulta beneficiarios análisis")]
        public IActionResult Semanal_financiamiento() {
            List<CatalogoVO> lst = FinanciamientosDAO.instancia().seleccionarAnioSemanal();
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
            lst = CatalogoDAO.instancia().seleccionarRegion();
            List<SelectListItem> regiones = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.regiones = regiones;
            ViewBag.regiones2 = regiones;
            /*lst = CatalogoDAO.instancia().seleccionarEntidadFederativa(Convert.ToInt16(lst.First().id));
            List<SelectListItem> estados = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.estados = estados;*/

            DateTime fecha = FinanciamientosDAO.instancia().seleccionarFechaSemanal();
            int num_semana = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(fecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            string semana = Util.instancia().getLeyendaFecha(fecha) + " (semana " + num_semana + ")";
            ViewBag.semana = semana;
            return View();
        }

        [Authorize(Roles = "Reporte semanal,Consulta beneficiarios análisis")]
        public IActionResult Semanal_hipotecario()
        {
            List<CatalogoVO> lst = FinanciamientosDAO.instancia().seleccionarAnioSemanal();
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
            lst = CatalogoDAO.instancia().seleccionarRegion();
            List<SelectListItem> regiones = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.regiones = regiones;
            ViewBag.regiones2 = regiones;

            DateTime fecha = FinanciamientosDAO.instancia().seleccionarFechaSemanal();
            int num_semana = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(fecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            string semana = Util.instancia().getLeyendaFecha(fecha) + " (semana " + num_semana + ")";
            ViewBag.semana = semana;
            return View();
        }
    }
}
