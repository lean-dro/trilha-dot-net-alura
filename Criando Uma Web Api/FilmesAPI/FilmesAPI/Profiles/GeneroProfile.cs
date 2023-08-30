using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GeneroProfile : Profile
    {
        public GeneroProfile()
        {
            CreateMap<CreateGeneroDTO, Genero>();
            CreateMap<Genero, ReadGeneroDTO>();
            CreateMap<UpdateGeneroDTO, Genero>();
            CreateMap<Genero, UpdateGeneroDTO>();
            
        }
    }
}
