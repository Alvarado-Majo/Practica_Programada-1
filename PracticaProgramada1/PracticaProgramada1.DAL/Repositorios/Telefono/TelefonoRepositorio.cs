using Microsoft.EntityFrameworkCore;
using PracticaProgramada1.DAL.Data;
using PracticaProgramada1.DAL.Entidad;

namespace PracticaProgramada1.DAL.Repositorios.Telefono
{
    public class TelefonoRepositorio : ITelefonoRepositorio
    {
        private readonly PracticaDBContext _context;

        public TelefonoRepositorio(PracticaDBContext context)
        {
            _context = context;
        }

        // Obtener teléfonos tabla completa
        public async Task<List<Entidad.Telefono>> GetTelefonos()
        {
            return await _context.Telefonos
                                 .Include(t => t.Cliente)
                                 .ToListAsync();
        }

        // Obtener teléfonos por ID
        public async Task<Entidad.Telefono?> GetTelefonoById(int id)
        {
            return await _context.Telefonos
                                 .FirstOrDefaultAsync(t => t.Id_Telefono == id);
        }

        // Obtener teléfonos por número
        public async Task<Entidad.Telefono?> GetTelefonoByNumero(string numero)
        {
            return await _context.Telefonos
                                 .FirstOrDefaultAsync(t => t.Numero == numero);
        }

        // Crear un teléfono
        public async Task<bool> CreateTelefono(Entidad.Telefono telefono)
        {
            await _context.Telefonos.AddAsync(telefono);
            return await _context.SaveChangesAsync() > 0;
        }

        // Actualizar teléfonos
        public async Task<bool> UpdateTelefono(Entidad.Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
            return await _context.SaveChangesAsync() > 0;
        }

        // Eliminar
        public async Task<bool> DeleteTelefono(int id)
        {
            var telefono = await _context.Telefonos
                                         .FirstOrDefaultAsync(t => t.Id_Telefono == id);

            if (telefono == null)
                return false;

            _context.Telefonos.Remove(telefono);
            return await _context.SaveChangesAsync() > 0;
        }

        // Desactivar (No eliminar, solo marcar como inactivo, tabla no tiene campo de estado para utilizar esto)
        public async Task<bool> DesactivarTelefono(int id)
        {
            var telefono = await _context.Telefonos
                                         .FirstOrDefaultAsync(t => t.Id_Telefono == id);

            if (telefono == null)
                return false;

            telefono.Tipo = "INACTIVO";

            _context.Telefonos.Update(telefono);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}