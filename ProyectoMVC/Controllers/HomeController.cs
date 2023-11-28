using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;
using System.Diagnostics;

namespace ProyectoMVC.Controllers
{
    public class HomeController : Controller
    {
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

        public IActionResult VistaTest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(string nombre, int edad)
        {
            var nombreRecibido =nombre.Trim();
            var edadRecibido = edad;
            return View("Index");

        }
    }
}