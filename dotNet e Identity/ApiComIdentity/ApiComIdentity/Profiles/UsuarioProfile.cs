using ApiComIdentity.Data.Dtos;
using ApiComIdentity.Models;
using AutoMapper;

namespace ApiComIdentity.Profiles
{
    public class UsuarioProfile : Profile 
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
        }
    }
}
