using AutoMapper;
using Desafios.Nubimetrics.Application.PaisesEntity.Handlers;
using Desafios.Nubimetrics.DTO.PaisEntity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafios.Nubimetrics.Web.API.Controllers
{
    [Route("MyRestfulApp/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PaisesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;

        }
        [HttpGet("All")]
        public async Task<IActionResult> GetByAll()
        {
            var result = await _mediator.Send(new PaisGetAll());
      
            return Ok(result);
        }

    }

}
