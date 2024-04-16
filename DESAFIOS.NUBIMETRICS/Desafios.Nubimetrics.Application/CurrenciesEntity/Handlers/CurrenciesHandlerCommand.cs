using Desafios.Nubimetrics.Application.CurrenciesEntity.Services;
using Desafios.Nubimetrics.Application.PaisesEntity.Handlers;
using Desafios.Nubimetrics.DTO.CurrenciesEntity;
using Desafios.Nubimetrics.DTO.PaisEntity;
using Desafios.Nubimetrics.DTO.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.CurrenciesEntity.Handlers
{
    public partial class CurrenciesEventHandler
    {
        private readonly CurrenciesService _currenciesService;
        public CurrenciesEventHandler(CurrenciesService currenciesService)
        {
            _currenciesService = currenciesService;
        }
    }
}
