using AutoMapper;
using EFCoreDB.Models;
using EFCoreDB.Models.DTOs;
using EFCoreDB.Models.DTOs.Franchises;

namespace EFCoreDB.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile() 
        {
            CreateMap<Franchise, FranchiseDto>()
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.FranchiseId));
            CreateMap<FranchiseCreateDto, Franchise>();
            CreateMap<FranchiseUpdateDto, Franchise>();
        }
    }
}
