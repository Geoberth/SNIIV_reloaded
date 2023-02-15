using Microsoft.AspNetCore.Mvc;
using sniiv.Data;
using sniiv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace sniiv.Controllers
{
    public class IndicadoresController : Controller
    {

        private readonly IConfiguration _mySettings;
        private string environmentPath;

        public IndicadoresController(IConfiguration mySettings)
        {
           /* _mySettings = mySettings;
            var environment = _mySettings["EnvironmentPath"];
            var context = environment.Equals("DEV") ? "dev-" : environment.Equals("QA") ? "qa-" : "";
            environmentPath = "https://" + context + "sniiv.sedatu.gob.mx/sniiv/";
            environmentPath = (environment.Equals("LOC") ? "http://localhost/sniiv/" : environmentPath);*/
        }

        public IActionResult Pnv()
        {
            ViewBag.environment = "https://sniiv.sedatu.gob.mx/homemx/";
            return View();
        }
        public IActionResult Avances()
        {
            ViewBag.environment = "https://sniiv.sedatu.gob.mx/homemx/";
            return View();
        }
        public IActionResult Vivienda()
        {
            ViewBag.environment = "https://sniiv.sedatu.gob.mx/homemx/";
            return View();
        }
    }
}
