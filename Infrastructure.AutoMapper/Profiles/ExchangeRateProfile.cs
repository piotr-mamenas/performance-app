using AutoMapper;
using Core.Domain.ExchangeRates;
using Service.Dtos.ExchangeRate;

namespace Infrastructure.AutoMapper.Profiles
{
    public class ExchangeRateProfile : Profile
    {
        public ExchangeRateProfile()
        {
            CreateMap<ExchangeRate, ExchangeRateDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BaseCurrency, opt => opt.MapFrom(src => src.BaseCurrency))
                .ForMember(dest => dest.BaseCurrencyId, opt => opt.MapFrom(src => src.BaseCurrencyId))
                .ForMember(dest => dest.TargetCurrency, opt => opt.MapFrom(src => src.TargetCurrency))
                .ForMember(dest => dest.TargetCurrencyId, opt => opt.MapFrom(src => src.TargetCurrencyId))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.Max, opt => opt.MapFrom(src => src.Max))
                .ForMember(dest => dest.Min, opt => opt.MapFrom(src => src.Min))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => $"{src.Timestamp:d}"))
                .ReverseMap();
        }
    }
}
