using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaProgramada1.BLL.Services;

namespace PracticaProgramada1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController (IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        public IActionResult Clientes() 
        {

            return View();
        }



        public async Task<IActionResult> ObtenerClientes() 
        {
            var respuesta = await _clienteServicio.GetClientes();
            return Json(respuesta);
        }
    }
}
