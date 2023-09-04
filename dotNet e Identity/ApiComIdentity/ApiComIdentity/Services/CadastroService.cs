using ApiComIdentity.Data.Dtos;
using ApiComIdentity.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiComIdentity.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public CadastroService(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
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
    }
}
