using PracticaProgramada1.BLL.DTO;


using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.BLL.Services
{
    public interface IClienteServicio
    {
        Task<Respuesta<List<MostrarClienteDTO>>> GetClientes();
        Task<Respuesta<MostrarClienteDTO?>> GetClienteById(int id);
        Task<Respuesta<MostrarClienteDTO>> CreateCliente(MostrarClienteDTO Cliente);
        Task<Respuesta<MostrarClienteDTO>> UpdateCliente(MostrarClienteDTO Cliente);
        Task<Respuesta<MostrarClienteDTO>> DeleteCliente(int id);
    }
}
