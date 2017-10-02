using AutoMapper;
using Core.Domain.Assets;
using Service.Dtos;

namespace Infrastructure.AutoMapper.Profiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Isin))
                .ReverseMap();

            CreateMap<Bond, AssetDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Isin))
                .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
                .ForMember(dest => dest.FaceValue, opt => opt.MapFrom(src => src.FaceValue))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.MaturityDate, opt => opt.MapFrom(src => src.MaturityDate))
                .ReverseMap();

            CreateMap<Equity, AssetDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Isin))
                .ReverseMap();
        }
    }
}
