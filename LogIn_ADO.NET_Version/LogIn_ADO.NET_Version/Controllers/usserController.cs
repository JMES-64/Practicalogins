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
            //Asigna la interfaz InterUsser a la variable _interU
            _con = Pretexto;
            //Asigna la clase Conect a la variable _con, que se utiliza para establecer la conexión con la base de datos
        }
        //Este es el contructor para el sistema


        // GET: usserController
        public async Task<ActionResult> Index(usser _uss)
        {
            List<usser> lista;
            lista = await _interU.ListaU();
            //Llama al método ListaU de la interfaz InterUsser para obtener la lista de usuarios
            if (lista != null)
            {
                return View(lista);
            }
            //Verifica que haya contenido en la lista
            return View();
        }

        public async Task<ActionResult> IndexA(usser _uss)
        {
            List<usser> lista;
            lista = await _interU.ListaAU();
            //Llama al método ListaAU de la interfaz InterUsser para obtener la lista de usuarios y administradores
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
        public ActionResult CreateU()
        {
            return View();
        }

        // POST: usserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateU( usser Cuser)
        {
            try
            {
                usser Nusser = await _interU.CreateU(Cuser);
                //Llama al método CreateU de la interfaz InterUsser para crear un nuevo usuario
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: usserController/CreateA
        public ActionResult CreateAU()
        {
            return View();
        }

        // POST: usserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAU(usser Causser)
        {
            try
            {
                usser NAUsser = await _interU.CreateAU(Causser);
                return RedirectToAction(nameof(IndexA));
            }
            catch
            {
                return View();
            }
        }

        // GET: usserController/Edit/5
        public async Task<ActionResult> EditU(int id)
        {
            var Eusser = await _interU.Buscador(id);
            return View(Eusser);
        }

        // POST: usserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditU(usser Eusser)
        {
            try
            {
                usser NUusser = await _interU.EditU(Eusser);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditAU(int id)
        {
            return View();
        }

        // POST: usserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAU(int id, IFormCollection collection)
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
