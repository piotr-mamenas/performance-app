using AutoMapper;
using Core.Domain.Accounts;
using Service.Dtos.Account;
using Web.Presentation.ViewModels.AccountViewModels;

namespace Infrastructure.AutoMapper.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DateClosed, opt => opt.MapFrom(src => src.ClosedDate))
                .ForMember(dest => dest.DateOpened, opt => opt.MapFrom(src => src.OpenedDate))
                .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
                .ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.PartnerId))
                .ReverseMap();

            CreateMap<Account, AccountViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ReverseMap();
        }
    }
}
