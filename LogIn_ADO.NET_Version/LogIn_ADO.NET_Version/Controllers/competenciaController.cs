using LogIn_ADO.NET_Version.Data.Interfaz;
using LogIn_ADO.NET_Version.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> Index(int id, competencia com)
        {
            List<competencia> lista;
            lista = await _interC.ListaC(id);
            //Llama al método ListaC de la interfaz Intercompetencia para obtener la lista de competencias
            if (lista != null)
            {
                return View(lista);
            }
            return View();
        }

        // GET: competenciaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: competenciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: competenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
