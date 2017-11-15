using AutoMapper;
using Core.Domain.Portfolios;
using Service.Dtos.Portfolio;
using Web.Presentation.ViewModels.PortfolioViewModels;

namespace Infrastructure.AutoMapper.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<Portfolio, PortfolioDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.Assets, opt => opt.MapFrom(src => src.Assets))
                .ForMember(dest => dest.Partners, opt => opt.MapFrom(src => src.Partners))
                .ReverseMap();

            CreateMap<Portfolio, PortfolioDetailsViewModel>()
                .ForMember(dest => dest.PortfolioId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PortfolioName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PortfolioNumber, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.PortfolioAccountNumber, opt => opt.MapFrom(src => src.Account.Number))
                .ForMember(dest => dest.PortfolioAccountOwner, opt => opt.MapFrom(src => src.Account.Partner.Name))
                .ReverseMap();
        }
    }
}
