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


        public usserController(InterUsser IU)
        {
            _interU = IU;
            //Asigna la interfaz InterUsser a la variable _interU}
        }
        //Este es el contructor para el sistema
        
        

        // GET: usserController
        public async Task<ActionResult> Index()
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
        public async Task<ActionResult> Competencia(int id)
        {
            return RedirectToAction("Index","competencia", new {id=id});
            //Redirige a la acción Index del controlador competencia, pasando el id como parámetro
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
            //Llama a la función de buscador para recopilar los datos relacionados al usuario a editar
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
                //Llama al método EditU de la interfaz InterUsser para editar un usuario existente
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> EditAU(int id)
        {
            var EAusser = await _interU.Buscador(id);
            //Llama a la función de buscador para recopilar los datos relacionados al usuario a editar
            return View(EAusser);
        }

        // POST: usserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAU(usser Usser)
        {
            try
            {
                usser Ausser= await _interU.EditAU(Usser);
                //Llama al método EditAU de la interfaz InterUsser para editar un usuario existente
                return RedirectToAction(nameof(IndexA));
            }
            catch
            {
                return View();
            }
        }

        // GET: usserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var Dusser = await _interU.Buscador(id);
            //Llama a la función de buscador para recopilar los datos relacionados al usuario a eliminar
            return View(Dusser);
        }

        // POST: usserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(usser Dusser)
        {
            try
            {
                var Borrado = await _interU.Borra(Dusser.IDU);
                //Llama al método Borra de la interfaz InterUsser para eliminar un usuario existente
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> DeleteAU(int id)
        {
            var Dusser = await  _interU.Buscador(id);
            //Llama a la función de buscador para recopilar los datos relacionados al usuario a eliminar
            return View(Dusser);
        }

        // POST: usserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAU(usser Dusser)
        {
            try
            {
                var Borrado = _interU.Borra(Dusser.IDU);
                //Llama al método Borra de la interfaz InterUsser para eliminar un usuario existente
                return RedirectToAction(nameof(IndexA));
            }
            catch
            {
                return View();
            }
        }
    }
}
