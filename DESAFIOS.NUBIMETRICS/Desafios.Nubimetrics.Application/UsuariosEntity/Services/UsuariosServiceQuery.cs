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
using Desafios.Nubimetrics.DTO.UsuarioEntity;
using Desafios.Nubimetrics.DTO.Utils;

namespace Desafios.Nubimetrics.Application.UsuariosEntity.Services
{
    public partial class UsuariosService
    {
        private readonly NubimetricsUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IOptions<MercadoLibreMicroservices> _microservices;
        private readonly IGenericCommunication _communication;

        public UsuariosService(NubimetricsUnitOfWork unitOfWork, IMediator mediator, IMapper mapper, IOptions<MercadoLibreMicroservices> microservices, IGenericCommunication communication)
        {

            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
            _microservices = microservices;
            _communication = communication;
        }

        public async Task<Result<List<UsuariosGetDTO>>> GetAll()
        {
            // Obtener los datos de la comunicación
            var result = await _unitOfWork.usuariosRepository.GetAll();
            var mapeo = _mapper.Map<Result<List<UsuariosGetDTO>>>(result);

            return mapeo;
        }

        public async Task<Result<UsuariosGetDTO>> GetById(int id)
        {
            // Obtener los datos de la comunicación
            var result = await _unitOfWork.usuariosRepository.GetById(id);
            var mapeo = _mapper.Map<Result<UsuariosGetDTO>>(result);

            return mapeo;
            
        }
    }
}
