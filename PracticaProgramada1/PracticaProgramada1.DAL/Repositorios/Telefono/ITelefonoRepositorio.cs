using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.DAL.Repositorios.Telefono
{
    public interface ITelefonoRepositorio
    {
        Task<List<Entidad.Telefono>> GetTelefonos();
        Task<Entidad.Telefono?> GetTelefonoById(int id);
        Task<Entidad.Telefono?> GetTelefonoByNumero(string numero);
        Task<bool> CreateTelefono(Entidad.Telefono telefono);
        Task<bool> UpdateTelefono(Entidad.Telefono telefono);
        Task<bool> DeleteTelefono(int id);
        Task<bool> DesactivarTelefono(int id);
    }
}
