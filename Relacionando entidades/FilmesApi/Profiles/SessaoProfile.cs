using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<Sessao, ReadSessaoDTO>(); 
          
            CreateMap<CreateSessaoDTO, Sessao>();
        }
    }
}
