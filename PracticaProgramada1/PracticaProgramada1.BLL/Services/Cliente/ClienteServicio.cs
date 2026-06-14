using AutoMapper;
using PracticaProgramada1.BLL.DTO;
using PracticaProgramada1.DAL.Repositorios.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.BLL.Services.Cliente
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


        public async Task<Respuesta<ClienteDTO>> CreateCliente(ClienteDTO cliente)
        {
            var respuesta = new Respuesta<ClienteDTO>();

            /* Validaciones */

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "El nombre es obligatorio";
                respuesta.codigo = 001;
                return respuesta;
            }

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "El apellido es obligatorio";
                respuesta.codigo = 002;
                return respuesta;
            }

            if (string.IsNullOrWhiteSpace(cliente.Email))
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "El email es obligatorio";
                respuesta.codigo = 003;
                return respuesta;
            }

            if (!cliente.Email.Contains("@"))
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "El email no es válido";
                respuesta.codigo = 004;
                return respuesta;
            }

            /* Mapeo DTO vs Entidad */

            var entidad = _mapper.Map<PracticaProgramada1.DAL.Entidad.Cliente>(cliente);

            /* Proceso */

            if (!await _clienteRepositorio.CreateCliente(entidad))
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "No se pudo crear el cliente";
                respuesta.codigo = 005;
                return respuesta;
            }

            /* Respuesta final */

            respuesta.esCorrecto = true;
            respuesta.mensaje = "Cliente creado correctamente";
            respuesta.Dato = _mapper.Map<ClienteDTO>(entidad);

            return respuesta;
        }


        public async Task<Respuesta<ClienteDTO>> DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta<ClienteDTO>> GetClienteById(int id)
        {
            var respuesta = new Respuesta<ClienteDTO?>();
            var Cliente = await _clienteRepositorio.GetClienteById(id);
            if (Cliente == null)
            {
                respuesta.esCorrecto = false;
                respuesta.mensaje = "Cliente no encontrado";
                respuesta.codigo = 404;
                respuesta.Dato = null;
                return respuesta;
            }

            respuesta.Dato = _mapper.Map<ClienteDTO>(Cliente);
            return respuesta;
        }

        public async Task<Respuesta<List<ClienteDTO>>> GetClientes()
        {
            var respuesta = new Respuesta<List<ClienteDTO>>();
            var listaClientes = await _clienteRepositorio.GetClientes();
            respuesta.Dato = _mapper.Map<List<ClienteDTO>>(listaClientes);

            return respuesta;
        }

        public Task<Respuesta<ClienteDTO>> UpdateCliente(int id, ClienteDTO Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
