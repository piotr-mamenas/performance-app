using AutoMapper;
using Core.Domain.Currencies;
using Web.ViewModels.BaseData;

namespace Web.Mapping.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyViewModel>()
                .ReverseMap();
        }
    }
}