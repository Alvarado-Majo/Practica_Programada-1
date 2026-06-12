using Microsoft.EntityFrameworkCore;
using PracticaProgramada1.DAL.Data;
using PracticaProgramada1.DAL.Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.DAL.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly PracticaDBContext _context;

        public ClienteRepositorio(PracticaDBContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateClienteAsync(Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DesactivarClienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> GetClienteByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<bool> UpdateClienteAsync(Cliente Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
