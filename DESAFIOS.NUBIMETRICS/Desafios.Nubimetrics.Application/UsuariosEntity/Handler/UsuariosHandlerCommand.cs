using Desafios.Nubimetrics.Application.UsuariosEntity.Services;
using Desafios.Nubimetrics.DTO.UsuarioEntity;
using Desafios.Nubimetrics.DTO.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.UsuariosEntity.Handler
{
    public class UsuariosCreateCommand : UsuariosCreateDTO, IRequest<Result<UsuariosGetDTO>> { }


    public class UsuariosUpdateCommand : UsuariosUpdateDTO, IRequest<Result<UsuariosGetDTO>> { }


    public class UsuariosDeleteCommand : UsuariosDeleteDTO, IRequest<Result<UsuariosGetDTO>> { }



    public partial class UsuariosEventHandler : IRequestHandler<UsuariosCreateCommand, Result<UsuariosGetDTO>>,
                                                IRequestHandler<UsuariosUpdateCommand, Result<UsuariosGetDTO>>,
                                                IRequestHandler<UsuariosDeleteCommand,Result<UsuariosGetDTO>>
    {
        private readonly UsuariosService _usuariosService;
        public UsuariosEventHandler(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;

        }

        public async Task<Result<UsuariosGetDTO>> Handle(UsuariosCreateCommand request, CancellationToken cancellationToken)
        {
            return await _usuariosService.Create(request);
        }

        public async Task<Result<UsuariosGetDTO>> Handle(UsuariosUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _usuariosService.Update(request);
        }

        public async Task<Result<UsuariosGetDTO>> Handle(UsuariosDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _usuariosService.Delete(request);
        }

    }
}


