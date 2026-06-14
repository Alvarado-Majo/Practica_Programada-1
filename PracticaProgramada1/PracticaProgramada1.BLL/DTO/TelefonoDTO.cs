using PracticaProgramada1.DAL.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticaProgramada1.BLL.DTO
{
    public class TelefonoDTO
    {
        public int Id_Telefono { get; set; }
        public string Numero { get; set; } = null!;
        public string? Tipo { get; set; }
        public int FKCLIENTE { get; set; }
      
    }
}

