using Desafios.Nubimetrics.Application.BusquedasEntity.Handler;
using Desafios.Nubimetrics.DTO.BusquedaEntity;
using Desafios.Nubimetrics.DTO.CurrenciesEntity;
using Desafios.Nubimetrics.DTO.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.CurrenciesEntity.Handlers
{

    public class CurrenciesGetAll : IRequest<Result<List<CurrenciesGetDTO>>> { }

    public partial class CurrenciesEventHandler : IRequestHandler<CurrenciesGetAll, Result<List<CurrenciesGetDTO>>>
    {
        public async Task<Result<List<CurrenciesGetDTO>>> Handle(CurrenciesGetAll request, CancellationToken cancellationToken)
        {
            return await _currenciesService.GetAllFrom();
        }

    }
}
