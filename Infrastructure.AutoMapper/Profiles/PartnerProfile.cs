using AutoMapper;
using Core.Domain.Partners;
using Service.Dtos;

namespace Infrastructure.AutoMapper.Profiles
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ReverseMap();

            CreateMap<AssetManager, PartnerDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ReverseMap();
        }
    }
}
