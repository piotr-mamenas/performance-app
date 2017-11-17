using System.Linq;
using AutoMapper;
using Core.Domain.Assets;
using Service.Dtos.Asset;

namespace Infrastructure.AutoMapper.Profiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Isin))
                .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ReverseMap();

            CreateMap<Bond, AssetDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Isin))
                .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ForMember(dest => dest.FaceValue, opt => opt.MapFrom(src => src.FaceValue))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.MaturityDate, opt => opt.MapFrom(src => src.MaturityDate))
                .ReverseMap();

            CreateMap<Equity, AssetDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Isin))
                .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ReverseMap();
        }
    }
}
