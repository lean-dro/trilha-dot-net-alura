using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<Filme, ReadFilmeDTO>();
        }
    }
}
