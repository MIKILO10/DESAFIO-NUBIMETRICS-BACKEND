using Desafios.Nubimetrics.Application.PaisesEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.PaisesEntity.Handlers
{
    public partial class PaisesEventHandler
    {
        private readonly PaisService _paisService;
        public PaisesEventHandler(PaisService paisService)
        {
            _paisService = paisService;

        }
    }
}
