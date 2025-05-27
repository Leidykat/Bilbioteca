using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class AutoresAplicacion : IAutoresAplicacion
    {
        private IConexion? IConexion = null;
        public AutoresAplicacion(IConexion iConexion)

        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Autores? Borrar(Autores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Autores!.Remove(entidad);
            GuardarAuditoria("Borrar Autor");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Autores? Guardar(Autores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Autores!.Add(entidad);
            GuardarAuditoria("Guardar Autor");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Autores> Listar()
        {
            GuardarAuditoria("Listar Autor");
            return this.IConexion!.Autores!.Take(20).ToList();
        }

        public List<Autores> PorUsuario(Autores? entidad)
        {

            return this.IConexion!.Autores!.Where(x => x.nombre!.Contains(entidad!.nombre!)).ToList();
        }

        public Autores? Modificar(Autores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Autores>(entidad);
            entry.State = EntityState.Modified;
            GuardarAuditoria("Modificar Autor");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void GuardarAuditoria(string? accion)
        {
            var conexion = this.IConexion!.Auditorias;
            var entidad = new Auditorias()
            {
                accion = accion,
                tabla = "Autores",
                fecha = DateTime.Now
            };
            this.IConexion.Auditorias!.Add(entidad);
            this.IConexion.SaveChanges();
        }
    }
}

