using AutoMapper;
using Core.Domain.Portfolios;
using Service.Dtos.Portfolio;

namespace Service.Mapping.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<Portfolio, PortfolioDto>()
                .ReverseMap();
        }
    }
}
