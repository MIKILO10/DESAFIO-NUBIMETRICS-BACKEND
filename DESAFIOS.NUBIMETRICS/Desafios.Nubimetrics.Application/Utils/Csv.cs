using CsvHelper;
using CsvHelper.Configuration;
using Desafios.Nubimetrics.Application.Utils.Interfaces;
using Desafios.Nubimetrics.DTO.CurrenciesEntity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.Utils
{
    public class Csv : IDisposable
    {
        private readonly StreamWriter _streamWriter;
        private readonly CsvConfiguration _config;

        public Csv(string filePath, CsvConfiguration config)
        {
            _streamWriter = new StreamWriter(filePath);
            _config = config;
        }
        public Csv()
        {
            
        }
        public async Task WriteRatiosAsync(List<CurrenciesGetDTO> conversions, string filePath)
        {
            try
            {
                // Filtrar solo las ratios
                var ratios = conversions.Select(conversion => conversion.TodoDolar.Ratio).Where(x=>x.Value!=null).ToList();

                // Escribir las ratios en un archivo CSV
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (var ratio in ratios)
                    {
                        csv.WriteField(ratio);
                      //  csv.NextRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir ratios en el archivo CSV: {ex.Message}");
            }
        }

        public async Task DisposeAsync()
        {
            if (_streamWriter != null)
            {
                await _streamWriter.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _streamWriter?.Dispose();
        }
    }
}
