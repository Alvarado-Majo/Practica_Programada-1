using AutoMapper;
using PracticaProgramada1.BLL.DTO;
using PracticaProgramada1.DAL.Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1.BLL
{
    public class MapeoClases :Profile
    {
        public MapeoClases()
        {
            CreateMap<Cliente, MostrarClienteDTO>().ReverseMap();
        }
    }
}
