using AutoMapper;
using Core.Domain.ExchangeRates;
using Service.Dtos.ExchangeRate;

namespace Service.Mapping.Profiles
{
    public class ExchangeRateProfile : Profile
    {
        public ExchangeRateProfile()
        {
            CreateMap<ExchangeRate, ExchangeRateDto>()
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => $"{src.Timestamp:d}"))
                .ReverseMap();
        }
    }
}
