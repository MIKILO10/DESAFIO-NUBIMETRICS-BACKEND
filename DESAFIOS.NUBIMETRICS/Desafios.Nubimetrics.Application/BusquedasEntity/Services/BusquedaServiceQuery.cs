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
using Desafios.Nubimetrics.DTO.BusquedaEntity;
using Desafios.Nubimetrics.DTO.PaisEntity;

namespace Desafios.Nubimetrics.Application.BusquedasEntity.Services
{
    public partial class BusquedaService
    {
        private readonly NubimetricsUnitOfWork unitOfWork;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IOptions<MercadoLibreMicroservices> microservices;
        private readonly IGenericCommunication communication;

        public BusquedaService(NubimetricsUnitOfWork unitOfWork, IMediator mediator, IMapper mapper, IOptions<MercadoLibreMicroservices> microservices, IGenericCommunication communication)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
            this.mapper = mapper;
            this.microservices = microservices;
            this.communication = communication;
        }

        public async Task<Result<BusquedaGetDTO>> BusquedaGetByTerm(string request)
        {
            {
                // Obtener los datos de la comunicación
                var result = await communication.GetByTerm<BusquedaGetDTO>(microservices.Value.Busqueda, request);

                return result;
            }
        }
    }
}
