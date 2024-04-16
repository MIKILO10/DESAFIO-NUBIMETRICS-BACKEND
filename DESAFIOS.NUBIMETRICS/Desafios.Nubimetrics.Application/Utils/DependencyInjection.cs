using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Desafios.Nubimetrics.Application.Utils.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Desafios.Nubimetrics.Application.Utils
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
