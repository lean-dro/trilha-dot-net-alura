using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiComIdentity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy ="VerificarIdade")]
        public IActionResult Get()
        {
            return Ok("Acesso permitido");
        }
    }
}
