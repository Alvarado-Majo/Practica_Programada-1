using PracticaProgramada1.DAL.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticaProgramada1.BLL.DTO
{
    public class MostrarClienteDTO
    {

        public int ID { get; set; }
     
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public decimal Email { get; set; }

        public DateTime FechaRegistro { get; set; } 

        public Telefono Telefono { get; set; } = null!;


    }
}
