using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sniiv.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace sniiv.Controllers
{
    public class HomeController : Controller
    {
        [Route("Test_Swagger")]
        [HttpGet]
        public async Task<string> TestSwagger()
        {
            return "This is Just a test Norberto";
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
