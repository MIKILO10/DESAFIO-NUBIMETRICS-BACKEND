using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Desafios.Nubimetrics.Web.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddControllers();





            // Agrega servicios de explorador de API de puntos de conexión.
            services.AddEndpointsApiExplorer();

            // Agrega servicios de generación de Swagger para la documentación de la API.
            services.AddSwaggerGen(c =>
            {
                // Agrega un requisito de seguridad para el esquema de autenticación de tipo Bearer.
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id ="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
            });

            // Agrega servicios de protección de datos.
            services.AddDataProtection();

            // Agrega políticas CORS predeterminadas que permiten cualquier origen, método y encabezado.
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // Método para configurar el middleware de la aplicación.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            // Agrega middleware de enrutamiento.
            app.UseRouting();

            // Agrega middleware CORS para manejar las solicitudes de recursos de origen cruzado.
            app.UseCors();

            // Agrega middleware de autorización.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
