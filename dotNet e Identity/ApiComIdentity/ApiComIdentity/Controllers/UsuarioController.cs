using ApiComIdentity.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiComIdentity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] CreateUsuarioDTO createUsuarioDTO)
        {
            return NoContent();
        }
    }
}
