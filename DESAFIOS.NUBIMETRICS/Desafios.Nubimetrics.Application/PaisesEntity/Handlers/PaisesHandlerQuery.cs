using Desafios.Nubimetrics.DTO.PaisEntity;
using Desafios.Nubimetrics.DTO.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.PaisesEntity.Handlers
{
    public class PaisGetAll : IRequest<Result<List<PaisGetDTO>>> { }
    public class PaisGetById : IRequest<Result<PaisArgGetDTO>>
    {
        public string Id { get; set; }
        public PaisGetById(string id) => Id = id;
    }


    public partial class PaisesEventHandler : IRequestHandler<PaisGetAll, Result<List<PaisGetDTO>>>,
                                              IRequestHandler<PaisGetById, Result<PaisArgGetDTO>>
    {

        public async Task<Result<List<PaisGetDTO>>> Handle(PaisGetAll request, CancellationToken cancellationToken)
        {
            return await _paisService.GetAll();
        }

        public async Task<Result<PaisArgGetDTO>> Handle(PaisGetById request, CancellationToken cancellationToken)
        {
            return await _paisService.GetById(request.Id);
        }
    }

}
