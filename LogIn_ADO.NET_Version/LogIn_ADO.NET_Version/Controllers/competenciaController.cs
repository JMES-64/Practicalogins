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

        //Index de los administradores y usuarios
        public async Task<ActionResult> IndexAC(int? id = null)
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
                    return RedirectToAction("IndexA", "Usser");
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

        //Crear competencias de los administradores
        public ActionResult CreateCAC(int? idu = null)
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
        public async Task<ActionResult> CreateCAC(competencia com)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    competencia Ncom = await _interC.CreaC(com);

                    // Redirigir al Index con el IDU para mantener el contexto del usuario
                    return RedirectToAction(nameof(IndexAC), new { id = com.IDU });
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
        public async Task<ActionResult> Edit(int id)
        {
            var Ecomp = await _interC.Buscador(id);
            //Llama a la función de buscador para recopilar los datos relacionados a la competencia a editar
            return View(Ecomp);
        }

        // POST: competenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(competencia Ecomp)
        {
            try
            {
                competencia NCcomp = await _interC.EditC(Ecomp);
                //Llama al método EditC de la interfaz InterCompetencia para editar un usuario existente
                // Redirigir al Index con el IDU para mantener el contexto del usuario
                return RedirectToAction(nameof(Index), new { Id = NCcomp.IDU});
            }
            catch
            {
                return View();
            }
        }

        //Editar competencias de los administradores
        public async Task<ActionResult> EditAC(int id)
        {
            var Ecomp = await _interC.Buscador(id);
            //Llama a la función de buscador para recopilar los datos relacionados a la competencia a editar
            return View(Ecomp);
        }

        // POST: competenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAC(competencia Ecomp)
        {
            try
            {
                competencia NCcomp = await _interC.EditC(Ecomp);
                //Llama al método EditC de la interfaz InterCompetencia para editar un usuario existente
                // Redirigir al Index con el IDU para mantener el contexto del usuario
                return RedirectToAction(nameof(IndexAC), new { Id = NCcomp.IDU });
            }
            catch
            {
                return View();
            }
        }

        // GET: competenciaController/Delete/5
        public async Task <ActionResult> Delete(int id)
        {
            var Dcomp = await _interC.Buscador(id);
            //Llama a la función de buscador para recopilar los datos relacionados a la competencia a eliminar
            return View(Dcomp);
        }

        // POST: competenciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Delete(competencia comp)
        {
            try
            {
                var Borrado = await _interC.Borra(comp.IDC);
                //Llama al método Borra de la interfaz Intercompetencia para eliminar una competencia existente
                return RedirectToAction(nameof(Index), new { Id = comp.IDU});
            }
            catch
            {
                return View();
            }
        }

        //Borrar competencias de los administradores
        public async Task<ActionResult> DeleteAC(int id)
        {
            var Dcomp = await _interC.Buscador(id);
            //Llama a la función de buscador para recopilar los datos relacionados a la competencia a eliminar
            return View(Dcomp);
        }

        // POST: competenciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAC(competencia comp)
        {
            try
            {
                var Borrado = await _interC.Borra(comp.IDC);
                //Llama al método Borra de la interfaz Intercompetencia para eliminar una competencia existente
                return RedirectToAction(nameof(IndexAC), new { Id = comp.IDU });
            }
            catch
            {
                return View();
            }
        }
    }
}
