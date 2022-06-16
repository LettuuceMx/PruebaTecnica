using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Repositorio;
using System.Diagnostics;

namespace PruebaTecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFarmacia ifarmacia;

        public HomeController(IFarmacia Ifarmacia)
        {
            ifarmacia = Ifarmacia;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var modelo = await ifarmacia.ObtenerClientes();

            return View(modelo);
        }

        [HttpGet]
        public async Task<IActionResult> RegistroCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente(ModelCliente modelCliente, ModelDireccion modelDireccion)
        {
            ModeloMultiple modeloMultiple = new ModeloMultiple();

            ModelState.Remove("modelDireccion.NumeroInterior");
            if (!ModelState.IsValid)
            {
                modeloMultiple.modelCliente = modelCliente;

                modeloMultiple.modelDireccion = modelDireccion;

                return View("RegistroCliente", modeloMultiple);
            }

            int idCliente = await ifarmacia.InsertarDatosCliente(modelCliente);

            //if (idCliente == 0)
            //{
            //    TempData["Error"] = "Ocurrio un error al insertar los datos del cliente";
            //}
            modelDireccion.idCliente = idCliente;
            int idDireccion = await ifarmacia.InsertarDatosDireccionCliente(modelDireccion);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}