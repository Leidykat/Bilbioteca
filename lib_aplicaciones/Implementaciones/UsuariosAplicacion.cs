using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion? IConexion = null;
        public UsuariosAplicacion(IConexion iConexion)

        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Usuarios? Borrar(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Usuarios!.Remove(entidad);
            GuardarAuditoria("Borrar Usuario");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Usuarios? Guardar(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Usuarios!.Add(entidad);
            GuardarAuditoria("Guardar Usuario");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Usuarios> Listar()
        {
            GuardarAuditoria("Listar Usuario");
            return this.IConexion!.Usuarios!.Take(20).Include(x => x._Roles).ToList();
        }

        public List<Usuarios> PorNombre(Usuarios? entidad)
        {
            return this.IConexion!.Usuarios!.Where(x => x.nombre!.Contains(entidad!.nombre!)).Include(x => x._Roles).ToList();
        }

        public Usuarios? Modificar(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            GuardarAuditoria("Modificar Usuario");
            this.IConexion.SaveChanges();
            return entidad;
        }
        public void GuardarAuditoria(string? accion)
        {
            var conexion = this.IConexion!.Auditorias;
            var entidad = new Auditorias()
            {
                accion = accion,
                tabla = "Usuarios",
                fecha = DateTime.Now
            };
            this.IConexion.Auditorias!.Add(entidad);
            this.IConexion.SaveChanges();
        }
    }
}
