using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafios.Nubimetrics.Web.API.Controllers
{
    [Route("MyRestfulApp/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        [HttpGet("{pais:alpha}")]
        public IActionResult GetByCountries(string pais)
        {
            return Ok(new string[] { pais });
        }

    }

}
