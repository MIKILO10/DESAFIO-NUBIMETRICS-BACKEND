using AutoMapper;
using Desafios.Nubimetrics.Application.CurrenciesEntity.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Desafios.Nubimetrics.Application.CurrenciesEntity.Handlers.CurrenciesEventHandler;

namespace Desafios.Nubimetrics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CurrenciesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet("Currencies/All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new CurrenciesGetAll());
            return Ok(result);
        }

    }
}
