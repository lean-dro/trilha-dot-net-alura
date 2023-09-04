using ApiComIdentity.Data.Dtos;
using ApiComIdentity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiComIdentity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private CadastroService _cadastroService;

        public UsuarioController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioDTO createUsuarioDTO)
        {
            await _cadastroService.Cadastrar(createUsuarioDTO);
            return Ok("Cadastrado com sucesso");
        }
    }
}
