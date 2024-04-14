using AutoMapper;
using Desafios.Nubimetrics.Application.BusquedasEntity.Handler;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafios.Nubimetrics.API.Controllers
{
    [Route("MyRestfulApp/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BusquedaController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet("Busqueda/{Termino}")]
        public async Task<IActionResult> GetByTermino(string Termino)
        {
            var result = await _mediator.Send(new BusquedaGetByTerm(Termino));
            return Ok(result);
        }
    }
}
