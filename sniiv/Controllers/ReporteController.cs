using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using sniiv.Data;
using sniiv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sniiv.Controllers
{
    public class ReporteController : Controller
    {
        private readonly AppDBContext _context;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public ReporteController(AppDBContext context, UserManager<IdentityUser> userManager,SignInManager<IdentityUser>signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Datos_abiertos()
        {
            List<CatalogoVO> lst = DatosAbiertosDAO.instancia().seleccionarAnio(1);
            List<SelectListItem> aniosSubsidio = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio(2);
            List<SelectListItem> aniosFinanciamiento = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio(3);
            List<SelectListItem> aniosOferta = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio(4);
            List<SelectListItem> aniosRegistro = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio(5);
            List<SelectListItem> aniosInventario = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio_bak(7);
            List<SelectListItem> aniosCnbv = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            string mes_financiamiento = Util.instancia().getMes(FinanciamientosDAO.instancia().seleccionarMes());
            string mes_subsidio = Util.instancia().getMes(ConaviDAO.instancia().seleccionarMes());
            string mes_cnbv = Util.instancia().getMes(CnbvDAO.instancia().seleccionarMes());
            string mes_registro = Util.instancia().getMes(RegistroViviendaDAO.instancia().seleccionarMes());
            string trimestre_inventario = Util.instancia().getTrimestre(DiasInventarioDAO.instancia().seleccionarTrimestre());

            ViewBag.aniosSubsidio = aniosSubsidio;
            ViewBag.aniosFinanciamiento = aniosFinanciamiento;
            ViewBag.aniosOferta = aniosOferta;
            ViewBag.aniosRegistro = aniosRegistro;
            ViewBag.aniosInventario = aniosInventario;
            ViewBag.aniosCnbv = aniosCnbv;

            ViewBag.mes_financiamiento = mes_financiamiento;
            ViewBag.mes_subsidio = mes_subsidio;
            ViewBag.mes_cnbv = mes_cnbv;
            ViewBag.mes_registro = mes_registro;
            ViewBag.trimestre_inventario = trimestre_inventario;
            return View();
        }

        public IActionResult Datos_abiertos_anterior()
        {
            List<CatalogoVO> lst = DatosAbiertosDAO.instancia().seleccionarAnio(1);
            List<SelectListItem> aniosSubsidio = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = DatosAbiertosDAO.instancia().seleccionarMes(1, Convert.ToInt32(lst.First().id));
            List<SelectListItem> mesesSubsidio = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio(2);
            List<SelectListItem> aniosFinanciamiento = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = DatosAbiertosDAO.instancia().seleccionarMes(2, Convert.ToInt32(lst.First().id));
            List<SelectListItem> mesesFinanciamiento = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio(3);
            List<SelectListItem> aniosOferta = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = DatosAbiertosDAO.instancia().seleccionarMes(3, Convert.ToInt32(lst.First().id));
            List<SelectListItem> mesesOferta = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio(4);
            List<SelectListItem> aniosRegistro = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = DatosAbiertosDAO.instancia().seleccionarMes(4, Convert.ToInt32(lst.First().id));
            List<SelectListItem> mesesRegistro = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio(5);
            List<SelectListItem> aniosInventario = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = DatosAbiertosDAO.instancia().seleccionarMes(5, Convert.ToInt32(lst.First().id));
            List<SelectListItem> mesesInventario = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            lst = DatosAbiertosDAO.instancia().seleccionarAnio(7);
            List<SelectListItem> aniosCnbv = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = DatosAbiertosDAO.instancia().seleccionarMes(7, Convert.ToInt32(lst.First().id));
            List<SelectListItem> mesesCnbv = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            ViewBag.aniosSubsidio = aniosSubsidio;
            ViewBag.aniosFinanciamiento = aniosFinanciamiento;
            ViewBag.aniosOferta = aniosOferta;
            ViewBag.aniosRegistro = aniosRegistro;
            ViewBag.aniosInventario = aniosInventario;
            ViewBag.aniosCnbv = aniosCnbv;
            ViewBag.mesesSubsidio = mesesSubsidio;
            ViewBag.mesesFinanciamiento = mesesFinanciamiento;
            ViewBag.mesesOferta = mesesOferta;
            ViewBag.mesesRegistro = mesesRegistro;
            ViewBag.mesesInventario = mesesInventario;
            ViewBag.mesesCnbv = mesesCnbv;
            return View();
        }

        public IActionResult Analisis() {
            return View();
        }

        public IActionResult Padron()
        {
            List<CatalogoVO> lst = DatosAbiertosDAO.instancia().seleccionarAnio(6);
            List<SelectListItem> anios = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = DatosAbiertosDAO.instancia().seleccionarMes(6, Convert.ToInt32(lst.First().id));
            List<SelectListItem> meses = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            ViewBag.anios = anios;
            ViewBag.meses = meses;
            return View();
        }

        public IActionResult Mensual() {
            List<CatalogoVO> lst = ReporteMensualDAO.instancia().seleccionarAnio();
            List<SelectListItem> anios = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = ReporteMensualDAO.instancia().seleccionarMes(Convert.ToInt32(lst.First().id));
            List<SelectListItem> meses = lst.ConvertAll(d =>
            { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });

            ViewBag.anios = anios;
            ViewBag.meses = meses;
            return View();
        }

        public IActionResult Meta() {
            List<CatalogoVO> lst = ConaviDAO.instancia().seleccionarAnioMeta();
            List<SelectListItem> anios_conavi = lst.ConvertAll(d => { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = FovisssteDAO.instancia().seleccionarAnioMeta();
            List<SelectListItem> anios_fovissste = lst.ConvertAll(d => { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            lst = InfonavitDAO.instancia().seleccionarAnioMeta();
            List<SelectListItem> anios_infonavit = lst.ConvertAll(d => { return new SelectListItem() { Value = d.id, Text = d.descripcion, Selected = false }; });
            ViewBag.anios_conavi = anios_conavi;
            ViewBag.anios_fovissste = anios_fovissste;
            ViewBag.anios_infonavit = anios_infonavit;
            return View();
        }
        [Authorize(Roles = "Reporte semanal,Consulta beneficiarios análisis")]

        public IActionResult Semanal_empleo() {
            return View();
        }
        [Authorize(Roles = "Reporte semanal,Consulta beneficiarios análisis")]

        public IActionResult Semanal_m2()
        {
            return View();
        }

        public IActionResult Indicadores()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Login()
        {
            var model = new LoginViewModel { ReturnUrl = "" };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Usuario, model.Contraseña, isPersistent: false, lockoutOnFailure:false );

                if (result.Succeeded)
                {
                    var myUser = _userManager.FindByNameAsync(model.Usuario).Result;
                    var rol = _userManager.GetRolesAsync(myUser).Result.First();
                    var rol_id = _roleManager.FindByNameAsync(rol).Result;
                    var modulo_rol =_context.rol_modulo.FirstOrDefault(rm => rm.id_rol == rol_id.Id);
                    var modulo = _context.c_modulo.FirstOrDefault(mod => mod.id == modulo_rol.id_modulo);
                    var modulo2 = modulo.url.Split('/')[1];
                    var modulo1 = modulo.url.Split('/')[2];

                    return RedirectToAction(modulo1, modulo2);

                }
            }
            ModelState.AddModelError("", "El usuario y/o constraseña que ingresaste son incorrectos");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Response.Cookies.Delete(".AspNetCore.Antiforgery");
                await _signInManager.SignOutAsync();

                return RedirectToAction("acerca_de", "inicio");
            }
            else
            {
                return View();
            }
        }


    }
}
