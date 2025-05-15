using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;
namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        
        { 
            Configuration = configuration; 
        }
        public static IConfiguration? Configuration { set; get; }
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; }); 
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; }); 
            services.AddControllers(); 
            services.AddEndpointsApiExplorer(); 
            //services.AddSwaggerGen(); 
            // Repositorios
            services.AddScoped<IConexion, Conexion>(); 
            // Aplicaciones
            services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>(); //PREGUNTAR SI ESTE TAMBIEN VA 
            services.AddScoped<IAutoresAplicacion, AutoresAplicacion>();
            services.AddScoped<IEditorialesAplicacion, EditorialesAplicacion>();
            services.AddScoped<IGenerosAplicacion, GenerosAplicacion>();
            services.AddScoped<ILibros_AutoresAplicacion, Libros_AutoresAplicacion>();
            services.AddScoped<ILibros_GenerosAplicacion, Libros_GenerosAplicacion>();
            services.AddScoped<ILibrosAplicacion, LibrosAplicacion>();
            services.AddScoped<IPrestamos_LibrosAplicacion, Prestamos_LibrosAplicacion>();
            services.AddScoped<IPrestamosAplicacion, PrestamosAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors();
        }
    }
}