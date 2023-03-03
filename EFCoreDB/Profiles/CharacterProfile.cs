using AutoMapper;
using EFCoreDB.Models;
using EFCoreDB.Models.DTOs;
    
namespace EFCoreDB.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDto>()
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.MovieId));
            CreateMap<CharacterCreateDto, Character>();
            CreateMap<CharacterUpdateDto, Character>();
        }
    }
}