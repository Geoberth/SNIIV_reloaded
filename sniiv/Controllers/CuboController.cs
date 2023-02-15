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
    public class CuboController : Controller
    {
        public IActionResult Financiamiento()
        {
            List<CatalogoVO> lst = FinanciamientosDAO.instancia().seleccionarAnio();
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
            string fecha = Util.instancia().getLeyendaFecha(FinanciamientosDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Conavi()
        {
            List<CatalogoVO> lst = ConaviDAO.instancia().seleccionarAnioSemanal();
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
            string fecha = Util.instancia().getLeyendaFecha(ConaviDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Fovissste()
        {
            List<CatalogoVO> lst = FovisssteDAO.instancia().seleccionarAnio();
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
            string fecha = Util.instancia().getLeyendaFecha(FovisssteDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Infonavit()
        {
            List<CatalogoVO> lst = InfonavitDAO.instancia().seleccionarAnio();
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
            string fecha = Util.instancia().getLeyendaFecha(InfonavitDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Fonhapo()
        {
            List<CatalogoVO> lst = FonhapoDAO.instancia().seleccionarAnio();
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
            string fecha = Util.instancia().getLeyendaFecha(FonhapoDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Cnbv()
        {
            List<CatalogoVO> lst = CnbvDAO.instancia().seleccionarAnio();
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
            string fecha = Util.instancia().getLeyendaFecha(CnbvDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Issste()
        {
            List<CatalogoVO> lst = IsssteDAO.instancia().seleccionarAnio();
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
            lst = IsssteDAO.instancia().seleccionarMes(Convert.ToInt32(lst.First().id));
            List<SelectListItem> meses = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.meses = meses;
            string fecha = Util.instancia().getLeyendaFecha(IsssteDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Imss()
        {
            List<CatalogoVO> lst = ImssDAO.instancia().seleccionarAnio();
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
            /*lst = ImssDAO.instancia().seleccionarMes(Convert.ToInt32(lst.First().id));
            List<SelectListItem> meses = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.meses = meses;*/
            string fecha = Util.instancia().getLeyendaFecha(ImssDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Inventario()
        {
            List<CatalogoVO> lst = InventarioDAO.instancia().seleccionarAnioInventario();
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
            lst = InventarioDAO.instancia().seleccionarMesInventario(Convert.ToInt32(lst.First().id));
            List<SelectListItem> meses = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.meses = meses;
            string fecha = Util.instancia().getLeyendaFecha(InventarioDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Registro()
        {
            List<CatalogoVO> lst = RegistroViviendaDAO.instancia().seleccionarAnio();
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
            string fecha = Util.instancia().getLeyendaFecha(RegistroViviendaDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
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
            string fecha = Util.instancia().getLeyendaFecha(SiseviveDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }

        public IActionResult Desarrollador() {
            List<CatalogoVO> lst = FovisssteDAO.instancia().seleccionarAnio();
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
            lst = FovisssteDAO.instancia().seleccionarMes(Convert.ToInt32(lst.First().id));
            List<SelectListItem> meses = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            meses.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Acumulado",
                Selected = false
            });
            ViewBag.meses = meses;
            string fecha = Util.instancia().getLeyendaFecha(FovisssteDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }
        [Authorize(Roles ="Reporte semanal,Consulta beneficiarios análisis")]
        
        public IActionResult Semanal()
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
            lst = lst.OrderBy(x => x.descripcion).ToList();
            List<SelectListItem> anios2 = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Value = d.id,
                    Text = d.descripcion,
                    Selected = false
                };
            });
            ViewBag.anios2 = anios2;

            DateTime fecha = FinanciamientosDAO.instancia().seleccionarFechaSemanal();
            int num_semana = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(fecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            string semana = Util.instancia().getLeyendaFecha(fecha) + " (semana " + num_semana + ")";
            ViewBag.semana = semana;
            return View();
        }

        public IActionResult Insus()
        {
            List<CatalogoVO> lst = InsusDAO.instancia().seleccionarAnio();
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
            string fecha = Util.instancia().getLeyendaFecha(InsusDAO.instancia().seleccionarFecha());
            ViewBag.fecha = fecha;
            return View();
        }
    }
}
