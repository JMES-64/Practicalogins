using LogIn_ADO.NET_Version.Data.Interfaz;
using LogIn_ADO.NET_Version.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace LogIn_ADO.NET_Version.Controllers
{
    public class competenciaController : Controller
    {
        private readonly Intercompetencia _interC;
        //Conecta con la interfaz Intercompetencia

        public competenciaController(Intercompetencia IC)
        {
            _interC = IC;
            //Asigna la interfaz Intercompetencia a la variable _interC
        }
        //Este es el constructor para el sistema

        // GET: competenciaController
        public async Task<ActionResult> Index(int? id = null)
        {
            try
            {
                if (id.HasValue && id.Value > 0)
                {
                    // Obtener las competencias específicas de este usuario usando tu método existente
                    var competencias = await _interC.ListaC(id.Value);

                    // IMPORTANTE: Siempre pasar el IDU a la vista, incluso si no hay competencias
                    ViewData["IDU"] = id.Value;

                    return View(competencias);
                }
                else
                {
                    // Si no se proporciona ID, mostrar lista vacía o redirigir
                    return RedirectToAction("Index", "Usser");
                }
            }
            catch
            {
                // En caso de error, mantener el ID en ViewData si está disponible
                if (id.HasValue)
                {
                    ViewData["IDU"] = id.Value;
                }
                return View(new List<competencia>());
            }
        }

        // Método CreateC GET - recibe el IDU como parámetro
        public ActionResult CreateC(int? idu = null)
        {
            // Crear una nueva instancia del modelo con el IDU pre-establecido
            var model = new competencia();

            if (idu.HasValue)
            {
                model.IDU = idu.Value;
            }

            return View(model);
        }

        // POST: competenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateC(competencia com)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    competencia Ncom = await _interC.CreaC(com);

                    // Redirigir al Index con el IDU para mantener el contexto del usuario
                    return RedirectToAction(nameof(Index), new { id = com.IDU });
                }

                // Si el modelo no es válido, devolver la vista con errores
                return View(com);
            }
            catch (Exception ex)
            {
                // En caso de error, mantener los datos y mostrar la vista
                ModelState.AddModelError("", "Error al crear la competencia: " + ex.Message);
                return View(com);
            }
        }

        // GET: competenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: competenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: competenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: competenciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
