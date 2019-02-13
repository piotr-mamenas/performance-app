using System.Linq;
using AutoMapper;
using Core.Domain.Assets;
using Service.Dtos.Asset;

namespace Service.Mapping.Profiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetDto>()
                .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Currency.Code))
                .ReverseMap();

            CreateMap<Bond, AssetDto>()
                .ForMember(dest => dest.CurrentPrice,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ForMember(dest => dest.CurrencyCode,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Currency
                        .Code))
                .ReverseMap();

            CreateMap<Equity, AssetDto>()
                .ForMember(dest => dest.CurrentPrice,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ForMember(dest => dest.CurrencyCode,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Currency
                        .Code))
                .ReverseMap();

            CreateMap<AssetPrice, AssetPriceDto>()
                .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.Name))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Asset.Class.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Asset.Isin))
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.Currency.Code))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => $"{src.Timestamp:d}"))
                .ReverseMap();
        }
    }
}
