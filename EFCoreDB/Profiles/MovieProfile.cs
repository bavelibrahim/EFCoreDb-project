using AutoMapper;
using EFCoreDB.Models;
using EFCoreDB.Models.DTOs;

namespace EFCoreDB.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Characters, opt => opt.MapFrom(src => src.MovieId));
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();
        }
    }
}
