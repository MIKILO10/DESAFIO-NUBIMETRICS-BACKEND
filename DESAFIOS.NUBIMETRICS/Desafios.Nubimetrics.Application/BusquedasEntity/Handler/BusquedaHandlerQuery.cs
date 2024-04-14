using Desafios.Nubimetrics.Application.BusquedasEntity.Services;
using Desafios.Nubimetrics.DTO.BusquedaEntity;
using Desafios.Nubimetrics.DTO.PaisEntity;
using Desafios.Nubimetrics.DTO.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.BusquedasEntity.Handler
{
    public class  BusquedaGetByTerm : IRequest<Result<BusquedaGetDTO>>
    {
        public string Term { get; set; }
        public BusquedaGetByTerm(string term) => Term = term;
    }

    public partial class BusquedaEventHandler : IRequestHandler<BusquedaGetByTerm, Result<BusquedaGetDTO>>
    {
        public async Task<Result<BusquedaGetDTO>> Handle(BusquedaGetByTerm request, CancellationToken cancellationToken)
        {
            return await _busquedaService.BusquedaGetByTerm(request.Term);
        }
    }
}
