using LogIn_ADO.NET_Version.Data.Interfaz;
using LogIn_ADO.NET_Version.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LogIn_ADO.NET_Version.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterUsser _interU;

        // UN SOLO CONSTRUCTOR con todas las dependencias
        public HomeController(InterUsser IU, ILogger<HomeController> logger)
        {
            _interU = IU;
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(usser _usser)
        {
            var Lusser = await _interU.LogIn(_usser.Correo, _usser.Pass);
            if (Lusser != null)
            {
                if (Lusser.Adm == 1 && Lusser.Own == 1)
                {
                    return RedirectToAction("IndexA", "usser");
                    //Si el usuario buscado es administrador y usuario, envíará a las vistas del owner
                }
                else if (Lusser.Adm == 1 && Lusser.Own == 0)
                {
                    return RedirectToAction("Index", "usser");
                    //Si el usuario buscado solo es administrador, enviará a las vistas del admin
                }
                else {
                    return RedirectToAction("Privacy", "Home");
                    //Si solo es un usuario, lo enviará a otra página
                }

            }
            else {
                return View();
                //Si no encuentra el usuario, solo regresará la vista de log in
            }
                
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
