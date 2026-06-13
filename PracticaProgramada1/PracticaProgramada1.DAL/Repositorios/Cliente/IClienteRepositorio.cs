using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.DAL.Repositorios.Cliente
{
    public interface IClienteRepositorio
    {
        Task<List<Entidad.Cliente>> GetClientes();
        Task<Entidad.Cliente> GetClienteById(int id);
        Task<Entidad.Cliente> GetClienteByEmail(string email);
        Task<bool> CreateCliente(Entidad.Cliente Cliente);
        Task<bool> UpdateCliente(Entidad.Cliente Cliente);
        Task<bool> DeleteCliente(int id);
        Task<bool> DesactivarCliente(int id);
    }
}
