using AutoMapper;
using PracticaProgramada1.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.BLL
{
    public class MapeoClases :Profile
    {
        public MapeoClases()
        {
            CreateMap<DAL.Entidad.Cliente, DTO.ClienteDTO>().ReverseMap();
            CreateMap<DAL.Entidad.Telefono, DTO.TelefonoDTO>().ReverseMap();
        }
    }
}
    