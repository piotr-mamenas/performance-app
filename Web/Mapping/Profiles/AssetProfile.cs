using System.Linq;
using AutoMapper;
using Core.Domain.Assets;
using Web.ViewModels.PortfolioViewModels;

namespace Web.Mapping.Profiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, PortfolioAssetViewModel>()
                .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Currency.Code))
                .ReverseMap();

            CreateMap<Bond, PortfolioAssetViewModel>()
                .ForMember(dest => dest.CurrentPrice,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ForMember(dest => dest.CurrencyCode,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Currency.Code))
                .ReverseMap();

            CreateMap<Equity, PortfolioAssetViewModel>()
                .ForMember(dest => dest.CurrentPrice,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ForMember(dest => dest.CurrencyCode,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Currency.Code))
                .ReverseMap();
        }
    }
}