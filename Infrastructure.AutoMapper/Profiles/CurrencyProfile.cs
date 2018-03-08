using AutoMapper;
using Core.Domain.Currencies;
using Service.Dtos.BaseData;

namespace Infrastructure.AutoMapper.Profiles
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
