using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Libros

    {

        public int id { get; set; }
        public string? titulo { get; set; }
        public string? imagen { get; set; }
        public int cantidad { get; set; }
        public string? estado { get; set; }
        public string? año_publicacion { get; set; }
        public int id_editoriales { get; set; }

        [ForeignKey("id_editoriales")] public Editoriales? _id_editoriales { get; set; }

        //public Editoriales? Editoriales { get; set; }    
        //public List<Libros_Generos>? Libros_Generos { get; set; }
        //public List<Libros_Autores>? Libros_Autores { get; set; }
        //public List<Prestamos_Libros>? Prestamos_Libros { get; set; }

    }
}
