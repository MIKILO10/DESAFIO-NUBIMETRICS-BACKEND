using Desafios.Nubimetrics.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Persistence
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de Serilog para escribir en archivos de texto
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/mylog-.txt", rollingInterval: RollingInterval.Day) // Configuración para escribir en archivos de texto
                .CreateLogger();

            // Agregar el contexto de base de datos con Entity Framework Core
            services.AddDbContext<NubimetricsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("defaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            // Registrar el logger de aplicación con Serilog
            services.AddSingleton<Serilog.ILogger>(svc =>
            {
                return Log.Logger;
            });

            // Retornar los servicios configurados
            return services;
        }

    }
}
