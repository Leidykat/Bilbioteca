using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Usuarios

    {

        public int id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? correo { get; set; }
        public string? telefono { get; set; }
        public int id_roles { get; set; }

        [ForeignKey("id_roles")] public Roles? _Roles { get; set; } 
        //public Roles? _id_roles { get; set; }
    }
}
