using AutoMapper;
using EFCoreDB.Models;
using EFCoreDB.Models.DTOs;

namespace YourProjectName.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterCreateDto>()
                .ForMember(dest => dest.MovieIds, opt => opt.MapFrom(src => src.Movies.Select(m => m.MovieId)));
            CreateMap<CharacterForCreationDTO, Character>();
            CreateMap<CharacterForUpdateDTO, Character>();
            CreateMap<Character, CharacterForUpdateDTO>();
        }
    }
}