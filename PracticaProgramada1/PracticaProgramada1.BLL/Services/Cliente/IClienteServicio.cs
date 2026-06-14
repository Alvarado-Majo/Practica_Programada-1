using PracticaProgramada1.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.BLL.Services.Cliente
{
    public interface IClienteServicio
    {
        Task<Respuesta<List<ClienteDTO>>> GetClientes();
        Task<Respuesta<ClienteDTO?>> GetClienteById(int id);
        Task<Respuesta<ClienteDTO>> CreateCliente(ClienteDTO Cliente);
        Task<Respuesta<ClienteDTO>> UpdateCliente(int id, ClienteDTO Cliente);
        Task<Respuesta<ClienteDTO>> DeleteCliente(int id);
    }
}
