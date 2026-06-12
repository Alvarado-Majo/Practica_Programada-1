using AutoMapper;
using PracticaProgramada1.BLL.DTO;
using PracticaProgramada1.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.BLL.Services
{
    
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteServicio(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public Task<Respuesta<MostrarClienteDTO>> CreateCliente(MostrarClienteDTO Cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta<MostrarClienteDTO>> DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta<MostrarClienteDTO>> GetClienteById(int id)
        {
            var respuesta = new Respuesta<MostrarClienteDTO?>();
            var Cliente = await _clienteRepositorio.GetClienteByIdAsync(id);
            if (Cliente == null)
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "Cliente no encontrado";
                respuesta.codigo = 404;
                respuesta.Dato = null;
                return respuesta;
            }

            respuesta.Dato = _mapper.Map<MostrarClienteDTO>(Cliente);
            return respuesta;
        }

        public async Task<Respuesta<List<MostrarClienteDTO>>> GetClientes()
        {
            var respuesta = new Respuesta<List<MostrarClienteDTO>>();
            var listaClientes = await _clienteRepositorio.GetClientesAsync();
            respuesta.Dato = _mapper.Map<List<MostrarClienteDTO>>(listaClientes);

            return respuesta;
        }

        public Task<Respuesta<MostrarClienteDTO>> UpdateCliente(MostrarClienteDTO Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
