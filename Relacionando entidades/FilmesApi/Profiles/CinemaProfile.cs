using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
    public CinemaProfile()
        {

        CreateMap<CreateCinemaDTO, Cinema>();
        CreateMap<UpdateCinemaDTO, Cinema>();
        CreateMap<Cinema, ReadCinemaDTO>()
                .ForMember(dto => dto.Endereco, 
            opt=> opt.MapFrom(cinema=> cinema.Endereco))
                .ForMember(dto => dto.Sessoes,
            opt=>opt.MapFrom(cinema => cinema.Sessoes));
         
        }
    }
}
