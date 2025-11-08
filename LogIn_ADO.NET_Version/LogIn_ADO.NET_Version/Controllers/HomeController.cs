using LogIn_ADO.NET_Version.Data.Interfaz;
using LogIn_ADO.NET_Version.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

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
            if (Lusser.IDU != 0)
            {
                var claims = new List<Claim> {
                  new Claim (ClaimTypes.Name, Lusser.Nombre),
                  new Claim (ClaimTypes.Email, Lusser.Correo),
                };

                if (Lusser.Adm == 0 && Lusser.Own == 0)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Basico"));
                }//Si el usser no es admin ni owner; no da autorización para ninguna página
                
                if (Lusser.Adm == 1)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Administrador"));
                }//Si el usser es admin; permite ver solo la página usuarios

                if (Lusser.Own == 1)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Owner"));
                }//Si el usser es owner; permite ver la página usuarios y admins y la página usuarios

                var claimsIden = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIden));


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
                else
                {
                    return RedirectToAction("Común", "Home");
                    //Si solo es un usuario, lo enviará a otra página
                }

            }
            else {
                ViewBag.Error = "Usuario no encontrado";
                return View();
                //Si no encuentra el usuario, solo regresará la vista de log in
            }
                
        }

        public async Task<ActionResult> Log_out() {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
            //Retira las cookies y regresa a la página de log in
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Común()
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
