using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Prestamos
    {

        public int id { get; set; }
        public string? codigo { get; set; }
        public DateTime fecha_prestamo { get; set; }
        public DateTime fecha_devolucion { get; set; }
        public int id_usuarios { get; set; }

        [ForeignKey("id_usuarios")]
        public Usuarios? Usuarios { get; set; }
        //public Usuarios? _id_usuarios { get; set; }

        //public List<Usuarios>? Usuarios { get; set; }
        //public List<Prestamos_Libros>? Prestamos_Libros { get; set; }

    }
}
