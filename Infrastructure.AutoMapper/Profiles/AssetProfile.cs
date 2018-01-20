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
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Currency.Code))
                .ReverseMap();

            CreateMap<Bond, AssetDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Isin))
                .ForMember(dest => dest.CurrentPrice,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ForMember(dest => dest.CurrencyCode,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Currency
                        .Code))
                .ForMember(dest => dest.FaceValue, opt => opt.MapFrom(src => src.FaceValue))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.MaturityDate, opt => opt.MapFrom(src => src.MaturityDate))
                .ReverseMap();

            CreateMap<Equity, AssetDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Isin))
                .ForMember(dest => dest.CurrentPrice,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Amount))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Name))
                .ForMember(dest => dest.CurrencyCode,
                    opt => opt.MapFrom(src => src.Prices.OrderByDescending(p => p.Timestamp).FirstOrDefault().Currency
                        .Code))
                .ReverseMap();

            CreateMap<AssetPrice, AssetPriceDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.Name))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Asset.Class.Name))
                .ForMember(dest => dest.Isin, opt => opt.MapFrom(src => src.Asset.Isin))
                .ForMember(dest => dest.AssetId, opt => opt.MapFrom(src => src.AssetId))
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.Currency.Code))
                .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => $"{src.Timestamp:d}"))
                .ReverseMap();
        }
    }
}
