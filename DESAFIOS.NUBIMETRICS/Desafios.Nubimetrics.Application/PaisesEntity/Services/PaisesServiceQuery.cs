using AutoMapper;
using Azure;
using Desafios.Nubimetrics.Application.PaisesEntity.Handlers;
using Desafios.Nubimetrics.Application.Utils;
using Desafios.Nubimetrics.Application.Utils.Interfaces;
using Desafios.Nubimetrics.DTO.PaisEntity;
using Desafios.Nubimetrics.DTO.Utils;
using Desafios.Nubimetrics.Persistence.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Options;
using System.Net;

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

        public async Task<Result<PaisArgGetDTO>> GetById(string request)
        {
            List<string> Ids = new List<string>() { "BR", "CO" };

            if (Ids.Contains(request.ToUpper()))
            {
                return Result<PaisArgGetDTO>.Failure($"Error {(int)HttpStatusCode.Unauthorized} {HttpStatusCode.Unauthorized} de http",(int) HttpStatusCode.Unauthorized);
            }
            var result = await communication.GetById<PaisArgGetDTO>(microservices.Value.Pais, request.ToUpper());
            return result;
        }
    }
}

