using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class GenerosAplicacion : IGenerosAplicacion
    {
        private IConexion? IConexion = null;
        public GenerosAplicacion(IConexion iConexion)

        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Generos? Borrar(Generos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Generos!.Remove(entidad);
            GuardarAuditoria("Borrar Género");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Generos? Guardar(Generos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Generos!.Add(entidad);
            GuardarAuditoria("Guardar Género");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Generos> Listar()
        {
            GuardarAuditoria("Listar Género");
            return this.IConexion!.Generos!.Take(20).ToList();
        }

        public List<Generos> PorUsuario(Generos? entidad)
        {
            return this.IConexion!.Generos!.Where(x => x.nombre!.Contains(entidad!.nombre!)).ToList();
        }

        public Generos? Modificar(Generos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Generos>(entidad);
            entry.State = EntityState.Modified;
            GuardarAuditoria("Modificar Género");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void GuardarAuditoria(string? accion)
        {
            var conexion = this.IConexion!.Auditorias;
            var entidad = new Auditorias()
            {
                accion = accion,
                tabla = "Géneros",
                fecha = DateTime.Now
            };
            this.IConexion.Auditorias!.Add(entidad);
            this.IConexion.SaveChanges();
        }
    }
}
