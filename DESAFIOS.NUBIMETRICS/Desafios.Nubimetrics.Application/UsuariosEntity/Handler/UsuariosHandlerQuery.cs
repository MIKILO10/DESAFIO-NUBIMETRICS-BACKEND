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
    public class UsuariosGetAll : IRequest<Result<List<UsuariosGetDTO>>> { }
    public class UsuariosGetById : IRequest<Result<UsuariosGetDTO>>
    {
        public int Id { get; set; }
        public UsuariosGetById(int id) => Id = id;
    }
     


    public partial class UsuariosEventHandler: IRequestHandler<UsuariosGetAll, Result<List<UsuariosGetDTO>>>,
                                              IRequestHandler<UsuariosGetById, Result<UsuariosGetDTO>>
    {
        public async Task<Result<List<UsuariosGetDTO>>> Handle(UsuariosGetAll request, CancellationToken cancellationToken)
        {
            return await _usuariosService.GetAll();
        }

        public async Task<Result<UsuariosGetDTO>> Handle(UsuariosGetById request, CancellationToken cancellationToken)
        {
           return await _usuariosService.GetById(request.Id);

        }
    }
}
