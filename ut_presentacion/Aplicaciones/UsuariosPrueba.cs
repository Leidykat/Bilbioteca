using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class UsuariosPrueba
    {
        private readonly IUsuariosAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Usuarios>? lista;
        private Usuarios? entidad;

        public UsuariosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new UsuariosAplicacion(iConexion);
        }

        [TestMethod]

        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Listar()
        {
            this.lista = this.iAplicacion!.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Usuarios()!;
            this.iAplicacion!.Guardar(this.entidad);
            return true;
        }
        public bool Modificar()
        {
            this.iAplicacion!.Modificar(this.entidad);
            return true;
        }

        public bool Borrar()
        {
            this.iAplicacion!.Borrar(this.entidad);
            return true;
        }
    }
}
