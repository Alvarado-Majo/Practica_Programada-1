using Microsoft.AspNetCore.Mvc;
using PracticaProgramada1.BLL.DTO;
using PracticaProgramada1.BLL.Services.Cliente;

namespace PracticaProgramada1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        // Vista principal
        public async Task<IActionResult> IndexClientes()
        {
            var respuesta = await _clienteServicio.GetClientes();
            return View(respuesta.Dato);
        }

        // DataTables (JSON)
        public async Task<IActionResult> ObtenerClientes()
        {
            var respuesta = await _clienteServicio.GetClientes();
            return Json(respuesta);
        }

        // Crear Cliente
        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var respuesta = await _clienteServicio.GetClientes();
                return View("IndexClientes", respuesta.Dato);
            }

            await _clienteServicio.CreateCliente(dto);

            return RedirectToAction("IndexClientes");
        }

        // Editar Cliente
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClienteDTO dto)
        {
            var respuesta = await _clienteServicio.UpdateCliente(id, dto);
            return Json(respuesta);
        }

        // Eliminar Cliente
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var respuesta = await _clienteServicio.DeleteCliente(id);

            return Json(respuesta);
        }

        // Índice principal redirigiendo a la vista de clientes
        public IActionResult Index()
        {
            return RedirectToAction("IndexClientes");
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerDetalle(int id)
        {
            var respuesta = await _clienteServicio.GetClienteById(id);

            return Json(respuesta);
        }

    }
}