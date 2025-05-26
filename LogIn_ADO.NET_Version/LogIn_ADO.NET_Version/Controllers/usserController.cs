using LogIn_ADO.NET_Version.Data;
using LogIn_ADO.NET_Version.Data.Interfaz;
using LogIn_ADO.NET_Version.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogIn_ADO.NET_Version.Controllers
{
    public class usserController : Controller
    {
        private readonly InterUsser _interU;
        //Conecta con la interfaz
        private readonly Conect _con;
        //Conecta con la DB
        public usserController(InterUsser IU, Conect Pretexto)
        {
            _interU = IU;
            _con = Pretexto;
        }
        //Este es el contructor para el sistema


        // GET: usserController
        public async Task<ActionResult> Index(usser _uss)
        {
            List<usser> lista;
            lista = await _interU.ListaU();
            if (lista != null)
            {
                return View(lista);
            }
            //Verifica que haya contenido en la lista
            return View();
        }

        // GET: usserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: usserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usserController/Create
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

        // GET: usserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: usserController/Edit/5
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

        // GET: usserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: usserController/Delete/5
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
