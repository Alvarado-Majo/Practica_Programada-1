using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.DAL.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<List<Entidad.Cliente>> GetClientesAsync();
        Task<Entidad.Cliente> GetClienteByIdAsync(int id);
        Task<Entidad.Cliente> GetClienteByEmailAsync(string email);
        Task<bool> CreateClienteAsync(Entidad.Cliente Cliente);
        Task<bool> UpdateClienteAsync(Entidad.Cliente Cliente);
        Task<bool> DeleteClienteAsync(int id);
        Task<bool> DesactivarClienteAsync(int id);
    }
}
