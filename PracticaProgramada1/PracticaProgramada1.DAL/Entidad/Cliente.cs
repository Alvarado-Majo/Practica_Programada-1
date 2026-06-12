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
        public string ID { get; set; }=null!;
        public string nombre { get; set; }= null!;
        public string apellido { get; set; }= null!;
        public string email { get; set; }= null!;
        public DateTime fechaRegistro { get; set; }
    }
}

