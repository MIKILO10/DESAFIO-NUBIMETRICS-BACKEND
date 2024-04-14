using AutoMapper;
using Desafios.Nubimetrics.Application.PaisesEntity.Handlers;
using Desafios.Nubimetrics.Application.UsuariosEntity.Handler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafios.Nubimetrics.API.Controllers
{
    [Route("MyRestfulApp/[controller]")]
    [ApiController]
    public class UsuariosController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsuariosController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet("All")]
        public async Task<IActionResult> GetByAll()
        {
            var result = await _mediator.Send(new UsuariosGetAll());

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new UsuariosGetById(id));

            return Ok(result);
        }

    }
}
