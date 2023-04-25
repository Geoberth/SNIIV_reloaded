using Microsoft.AspNetCore.Mvc;
using sniiv.Data;
using sniiv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sniiv.Controllers
{
    public class InicioController : Controller
    {
        private readonly AppDBContext _context;

        public InicioController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Acerca_de()
        {
            string bn = "Banner";
            IEnumerable<datos_abiertos> ccb = _context.datos_abiertos.Where(t => t.tipo.Equals(bn));
            ViewBag.banner = ccb.FirstOrDefault().url;
            return View();
        }
        public IActionResult Tutorial_cubos()
        {
            return View();
        }

        public IActionResult Tutorial_swagger()
        {
            return View();
        }
    }
}
