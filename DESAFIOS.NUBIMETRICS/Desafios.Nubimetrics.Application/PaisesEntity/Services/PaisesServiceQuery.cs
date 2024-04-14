using AutoMapper;
using Desafios.Nubimetrics.Application.Utils;
using Desafios.Nubimetrics.Application.Utils.Interfaces;
using Desafios.Nubimetrics.DTO.PaisEntity;
using Desafios.Nubimetrics.DTO.Utils;
using Desafios.Nubimetrics.Persistence.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Options;

namespace Desafios.Nubimetrics.Application.PaisesEntity.Services
{
    public partial class PaisService
    {
        private readonly NubimetricsUnitOfWork unitOfWork;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IOptions<MercadoLibreMicroservices> microservices;
        private readonly IGenericCommunication communication;


        public PaisService(NubimetricsUnitOfWork unitOfWork, IMediator mediator, IMapper mapper, IOptions<MercadoLibreMicroservices> microservices, IGenericCommunication communication)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
            this.mapper = mapper;
            this.microservices = microservices;
            this.communication = communication;
        }

        public async Task<Result<List<PaisGetDTO>>> GetAll()
        {
            // Obtener los datos de la comunicación
            var result = await communication.GetAll<List<PaisGetDTO>>(microservices.Value.Pais);

            return result;
        }


    }
}
