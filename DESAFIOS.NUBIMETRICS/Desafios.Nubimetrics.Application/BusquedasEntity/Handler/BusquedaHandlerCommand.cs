using Desafios.Nubimetrics.Application.BusquedasEntity.Services;

namespace Desafios.Nubimetrics.Application.BusquedasEntity.Handler
{
    public partial class BusquedaEventHandler
    {
        private readonly BusquedaService _busquedaService;

        public BusquedaEventHandler(BusquedaService busquedaService)
        {
            _busquedaService = busquedaService;

        }
    }
}
