using AutoMapper;
using Desafios.Nubimetrics.Application.PaisesEntity.Handlers;
using Desafios.Nubimetrics.Application.UsuariosEntity.Handler;
using Desafios.Nubimetrics.Domain.Entities;
using Desafios.Nubimetrics.DTO.UsuarioEntity;
using Desafios.Nubimetrics.DTO.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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


        //[HttpGet("All")]
        //public async Task<IActionResult> GetByAll()
        //{
        //    var result = await _mediator.Send(new UsuariosGetAll());

        //    return Ok(result);
        //}

        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _mediator.Send(new UsuariosGetById(id));

        //    return Ok(result);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] UsuariosCreateCommand request)
        //{
        //    var result = await _mediator.Send(request);

        //    return Ok(result);
        //}

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update(int id, [FromBody] UsuariosUpdateCommand request)
        //{
        //    if (id != request.Id)
        //    {
        //        var badRequest = Result<UsuariosUpdateDTO>.Failure("Error al validar el Id de la Entidad solicitada", (int)HttpStatusCode.BadRequest);
        //        return BadRequest(badRequest);
        //    }
        //    var result = await _mediator.Send(request);

        //    return Ok(result);
        //}

        //[HttpDelete("{id:int}")]

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _mediator.Send(new UsuariosDeleteCommand { Id = id });

        //    return Ok(result);
        //}

    }
}
