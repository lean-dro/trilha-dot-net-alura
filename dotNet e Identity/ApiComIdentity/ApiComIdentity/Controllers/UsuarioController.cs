using ApiComIdentity.Data.Dtos;
using ApiComIdentity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiComIdentity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioDTO createUsuarioDTO)
        {
            await _usuarioService.Cadastrar(createUsuarioDTO);
            return Ok("Cadastrado com sucesso");
        }

        [HttpPost("logar")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioDTO loginUsuarioDTO)
        { 
            var token = await _usuarioService.Login(loginUsuarioDTO);
            return Ok(token);
        }
    }
}
