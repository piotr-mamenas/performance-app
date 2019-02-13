using AutoMapper;
using Core.Domain.Currencies;
using Service.Dtos.BaseData;

namespace Service.Mapping.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyDto>()
                .ReverseMap();
        }
    }
}
