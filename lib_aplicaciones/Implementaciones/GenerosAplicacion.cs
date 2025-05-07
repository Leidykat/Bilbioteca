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
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Generos? Guardar(Generos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            /*entidad!.NotaFinal = 
                (entidad.Nota1 + 
                entidad.Nota2 + 
                entidad.Nota3 + 
                entidad.Nota4 + 
                entidad.Nota5) / 5;*/

            this.IConexion!.Generos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Generos> Listar()
        {
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

            /*entidad!.NotaFinal =
                (entidad.Nota1 + 
                entidad.Nota2 + 
                entidad.Nota3 + 
                entidad.Nota4 + 
                entidad.Nota5) / 5;
            CALCULOS
            */

            var entry = this.IConexion!.Entry<Generos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
