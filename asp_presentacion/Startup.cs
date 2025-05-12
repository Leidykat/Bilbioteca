using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
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
            // Presentaciones
            services.AddScoped<IAutoresPresentacion, AutoresPresentacion>();
            services.AddScoped<IEditorialesPresentacion, EditorialesPresentacion>(); 
            services.AddScoped<IGenerosPresentacion, GenerosPresentacion>();
            services.AddScoped<ILibros_AutoresPresentacion, Libros_AutoresPresentacion>();
            services.AddScoped<ILibros_GenerosPresentacion, Libros_GenerosPresentacion>();
            services.AddScoped<ILibrosPresentacion, LibrosPresentacion>();
            services.AddScoped<IPrestamos_LibrosPresentacion, Prestamos_LibrosPresentacion>();
            services.AddScoped<IPrestamosPresentacion, PrestamosPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();





            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}