using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class EditorialesAplicacion : IEditorialesAplicacion
    {
        private IConexion? IConexion = null;
        public EditorialesAplicacion(IConexion iConexion)

        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Editoriales? Borrar(Editoriales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Editoriales!.Remove(entidad);
            GuardarAuditoria("Borrar Editorial");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Editoriales? Guardar(Editoriales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Editoriales!.Add(entidad);
            GuardarAuditoria("Guardar Editorial");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Editoriales> Listar()
        {
            GuardarAuditoria("Listar Editorial");
            return this.IConexion!.Editoriales!.Take(20).ToList();
        }

        public List<Editoriales> PorUsuario(Editoriales? entidad)
        {
            return this.IConexion!.Editoriales!.Where(x => x.nombre!.Contains(entidad!.nombre!)).ToList();
        }

        public Editoriales? Modificar(Editoriales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Editoriales>(entidad);
            entry.State = EntityState.Modified;
            GuardarAuditoria("Modificar Editorial");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void GuardarAuditoria(string? accion)
        {
            var conexion = this.IConexion!.Auditorias;
            var entidad = new Auditorias()
            {
                accion = accion,
                tabla = "Editoriales",
                fecha = DateTime.Now
            };
            this.IConexion.Auditorias!.Add(entidad);
            this.IConexion.SaveChanges();
        }
    }
}
