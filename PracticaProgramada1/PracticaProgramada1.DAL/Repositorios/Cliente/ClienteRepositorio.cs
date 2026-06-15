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


        public async Task<bool> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Telefonos)
                .FirstOrDefaultAsync(c => c.ID == id);

            if (cliente == null)
                return false;

            _context.Telefonos.RemoveRange(cliente.Telefonos);

            _context.Clientes.Remove(cliente);

            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> DesactivarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Entidad.Cliente> GetClienteByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Entidad.Cliente> GetClienteById(int id)
        {
            var cliente = await _context.Clientes
    .Include(c => c.Telefonos)
    .FirstOrDefaultAsync(c => c.ID == id);
            return cliente;
        }


        public async Task<List<Entidad.Cliente>> GetClientes()
        {
            return await _context.Clientes
                                 .Include(c => c.Telefonos)
                                 .ToListAsync();
        }


        public async Task<bool> UpdateCliente(Entidad.Cliente cliente)
{
    var clienteExistente = await _context.Clientes
        .FirstOrDefaultAsync(c => c.ID == cliente.ID);

    if (clienteExistente == null)
        return false;

    clienteExistente.Nombre = cliente.Nombre;
    clienteExistente.Apellido = cliente.Apellido;
    clienteExistente.Email = cliente.Email;

    return await _context.SaveChangesAsync() > 0;
}
    }
}
