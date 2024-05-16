using Desafios.Nubimetrics.Application.BusquedasEntity.Handler;
using Desafios.Nubimetrics.Application.BusquedasEntity.Services;
using Desafios.Nubimetrics.Application.CurrenciesEntity.Handlers;
using Desafios.Nubimetrics.Application.CurrenciesEntity.Services;
using Desafios.Nubimetrics.Application.PaisesEntity.Handlers;
using Desafios.Nubimetrics.Application.PaisesEntity.Services;
using Desafios.Nubimetrics.Application.UsuariosEntity.Handler;
using Desafios.Nubimetrics.Application.UsuariosEntity.Services;
using Desafios.Nubimetrics.Application.Utils;
using Desafios.Nubimetrics.Application.Utils.Interfaces;
using Desafios.Nubimetrics.Persistence;
using Desafios.Nubimetrics.Persistence.UnitOfWork;
using MediatR;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
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

            services.Configure<MercadoLibreMicroservices>(Configuration.GetSection("Microservices"));
            services.AddScoped<MercadoLibreMicroservices>();
            services.AddHttpClient<IGenericCommunication, HttpCommunication>();



            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddControllers();

  // Configurar Data Protection
        services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"/root/.aspnet/DataProtection-Keys"))
            .ProtectKeysWithDpapi();



            services.AddApplication();

            services.AddPersistence(Configuration);




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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddHttpContextAccessor();
            services.AddScoped<NubimetricsUnitOfWork>();

            services.AddMediatR(typeof(PaisesEventHandler));
            services.AddTransient<PaisService>();

            services.AddMediatR(typeof(BusquedaEventHandler));
            services.AddTransient<BusquedaService>();

            services.AddMediatR(typeof(UsuariosEventHandler));
            services.AddTransient<UsuariosService>();

            services.AddMediatR(typeof(CurrenciesEventHandler));
            services.AddTransient<CurrenciesService>();



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
