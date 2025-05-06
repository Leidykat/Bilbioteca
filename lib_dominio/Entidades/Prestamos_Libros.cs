using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Prestamos_Libros
    {

        public int id { get; set; }
        public DateTime fecha_devolucion { get; set; }
        public int id_libros { get; set; }
        public int id_prestamos { get; set; }

        [ForeignKey("id_libros")]
        public Libros? Libros { get; set; }

        [ForeignKey("id_prestamos")]
        public Prestamos? Prestamos { get; set; }
        //public Libros? _id_libros { get; set; }
        //public Prestamos? _id_prestamos { get; set; }

    }
}
