using Microsoft.EntityFrameworkCore;
using PracticaProgramada1.DAL.Data;
using PracticaProgramada1.DAL.Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.DAL.Repositorios.Cliente
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly PracticaDBContext _context;

        public ClienteRepositorio(PracticaDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCliente(Entidad.Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            return await _context.SaveChangesAsync() > 0; 
        }


        public Task<bool> DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DesactivarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Entidad.Cliente> GetClienteByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Entidad.Cliente> GetClienteById(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Entidad.Cliente>> GetClientes()
        {
            return await _context.Clientes
                                 .Include(c => c.Telefonos)
                                 .ToListAsync();
        }


        public Task<bool> UpdateCliente(Entidad.Cliente Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
