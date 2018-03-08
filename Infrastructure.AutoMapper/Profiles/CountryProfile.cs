using AutoMapper;
using Core.Domain.Countries;
using Service.Dtos.BaseData;

namespace Infrastructure.AutoMapper.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>()
                .ReverseMap();
        }
    }
}
