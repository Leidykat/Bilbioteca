using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Editoriales? Editoriales()
        {
            var entidad = new Editoriales();
            entidad.nombre = " Pruebas - " + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.correo = "Pruebas";
            return entidad;
        }

        public static Generos? Generos()
        {
            var entidad = new Generos();
            entidad.nombre = " Pruebas - " + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.descripcion = "Pruebas";
            return entidad;
        }

        public static Autores? Autores()
        {
            var entidad = new Autores();
            entidad.nombre = " Pruebas - " + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.apellido = "Pruebas";
            return entidad;
        }
        public static Roles? Roles()
        {
            var entidad = new Roles();
            entidad.nombre = " Pruebas - " + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.descripcion = "Pruebas";
            return entidad;
        }

        public static Usuarios? Usuarios()
        {
            var entidad = new Usuarios();
            entidad.nombre = " Pruebas - " + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.apellido = "Pruebas";
            entidad.correo = "Pruebas";
            entidad.telefono = "1234";
            entidad.id_roles = 1;
            return entidad;
        }

        public static Libros? Libros()
        {
            var entidad = new Libros();
            entidad.titulo = " Pruebas - " + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.cantidad = 2;
            entidad.estado = "Prueba";
            entidad.año_publicacion = "2001";
            entidad.id_editoriales = 2;
            return entidad;
        }

        public static Prestamos? Prestamos()
        {
            var entidad = new Prestamos();
            entidad.codigo = "1234";
            entidad.fecha_prestamo = DateTime.Now;
            entidad.fecha_devolucion = DateTime.Now;
            entidad.id_usuarios = 1;
            return entidad;
        }

        public static Prestamos_Libros? Prestamos_Libros()
        {
            var entidad = new Prestamos_Libros();
            entidad.fecha_devolucion = DateTime.Now;
            entidad.id_libros = 1;
            entidad.id_prestamos = 2;
            return entidad;
        }

        public static Libros_Autores? Libros_Autores()
        {
            var entidad = new Libros_Autores();
            entidad.id_libros = 1;
            entidad.id_autores = 1;
            return entidad;
        }

        public static Libros_Generos? Libros_Generos()
        {
            var entidad = new Libros_Generos();
            entidad.id_libros = 1;
            entidad.id_generos = 1;
            return entidad;
        }
    }
}