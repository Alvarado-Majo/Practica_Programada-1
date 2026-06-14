using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada1.DAL.Entidad
{
    public class Cliente
    {

        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }= null!;
        public string Apellido { get; set; }= null!;
        public string Email { get; set; }= null!;
        public DateTime FechaRegistro { get; set; }

        public ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
    }
}

