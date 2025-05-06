using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Libros_Autores
    {

        public int id { get; set; }
        public int id_libros { get; set; }
        public int id_autores { get; set; }

        [ForeignKey("id_libros")]
        public Libros? Libros { get; set; }

        [ForeignKey("id_autores")]
        public Autores? Autores { get; set; }

        //public Libros? _id_libros { get; set; }
        //public Autores? _id_autores { get; set; }

    }
}
