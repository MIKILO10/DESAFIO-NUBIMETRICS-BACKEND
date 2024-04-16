using AutoMapper;
using Desafios.Nubimetrics.Application.Utils.Interfaces;
using Desafios.Nubimetrics.Application.Utils;
using Desafios.Nubimetrics.Persistence.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafios.Nubimetrics.DTO.Utils;
using Desafios.Nubimetrics.DTO.CurrenciesEntity;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace Desafios.Nubimetrics.Application.CurrenciesEntity.Services
{
    public partial class CurrenciesService
    {
        private readonly NubimetricsUnitOfWork unitOfWork;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IOptions<MercadoLibreMicroservices> microservices;
        private readonly IGenericCommunication communication;

     

        public CurrenciesService(NubimetricsUnitOfWork unitOfWork, IMediator mediator, IMapper mapper, IOptions<MercadoLibreMicroservices> microservices, IGenericCommunication communication)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
            this.mapper = mapper;
            this.microservices = microservices;
            this.communication = communication;


        }

        public async Task<Result<List<CurrenciesGetDTO>>> GetAllFrom()
        {
            // Obtener datos de Currencies
            var result = await communication.GetAll<List<CurrenciesGetDTO>>(microservices.Value.Currencies);
            if (!result.IsSuccess)
            {
                return Result<List<CurrenciesGetDTO>>.Failure("Error al obtener los datos de Currencies", 500);
            }

            var currencies = result.Data.Where(x => x.Id != null).ToList();
            if (!currencies.Any())
            {
                return Result<List<CurrenciesGetDTO>>.Failure("No se encontraron datos", 404);
            }

            // Obtener datos de TodoDolar para cada moneda
            var todoDolarTasks = currencies
                .Select(async currency =>
                {
                    var todoDolarResult = await communication.GetAllFrom<TodoDolarGetDTO>(microservices.Value.Currency, currency.Id);
                    return todoDolarResult.IsSuccess ? todoDolarResult.Data : null;
                });

            var todoDolars = (await Task.WhenAll(todoDolarTasks)).Where(x => x != null).ToList();
            if (!todoDolars.Any())
            {
                return Result<List<CurrenciesGetDTO>>.Failure("No se encontraron datos de TodoDolar", 404);
            }

            // Unir datos de Currencies y TodoDolar
            var joinedResults = currencies
                .GroupJoin(todoDolars, currency => currency.Id, todoDolar => todoDolar.Currency_Base, (currency, todoDolarGroup) => new { currency, todoDolarGroup })
                .SelectMany(x => x.todoDolarGroup.DefaultIfEmpty(), (currency, todoDolar) => new CurrenciesGetDTO
                {
                    Id = currency.currency.Id,
                    Symbol = currency.currency.Symbol,
                    Description = currency.currency.Description,
                    Decimal_Places = currency.currency.Decimal_Places,
                    TodoDolar = todoDolar ?? new TodoDolarGetDTO()
                }).ToList();

            // Escribir registros en el archivo CSV
            var csvWriter = new Csv();
            await csvWriter.WriteRatiosAsync(joinedResults, "CSV/Currencies.csv");
            // Cerrar csvWriter
            csvWriter.Dispose();

            // Retornar el resultado
            return Result<List<CurrenciesGetDTO>>.Success(joinedResults);

        }
    }
}
