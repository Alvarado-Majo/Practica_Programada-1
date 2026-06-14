using PracticaProgramada1.DAL.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticaProgramada1.BLL.DTO
{
    public class ClienteDTO
    {

        public int ID { get; set; }
     
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string? Email { get; set; } //Se corrige, estaba como decimal pero es un correo electrónico

        public DateTime FechaRegistro { get; set; }

        public List<TelefonoDTO>? Telefonos { get; set; }


    }
}
