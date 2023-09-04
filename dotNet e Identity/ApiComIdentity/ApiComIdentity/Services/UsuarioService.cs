using ApiComIdentity.Data.Dtos;
using ApiComIdentity.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiComIdentity.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;
        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task Cadastrar(CreateUsuarioDTO createUsuarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(createUsuarioDTO);
            IdentityResult resultadoCadastro = await _userManager.CreateAsync(usuario, createUsuarioDTO.Password);


            if (!resultadoCadastro.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar o usuário");

            }

        }
        
        public async Task<string> Login(LoginUsuarioDTO loginUsuarioDTO)
        {
            var resultado = await _signInManager.PasswordSignInAsync(loginUsuarioDTO.Username, loginUsuarioDTO.Password, false, false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao autenticar o usuário");
            }

            var usuario =  _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == loginUsuarioDTO.Username.ToUpper());
            
            var token = _tokenService.GerarToken(usuario);
            return token;
        }
    }
}
