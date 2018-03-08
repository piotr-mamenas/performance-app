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
            CreateMap<Account, AccountDto>()
                .ForMember(dest => dest.DateClosed, opt => opt.MapFrom(src => $"{src.ClosedDate:d}"))
                .ForMember(dest => dest.DateOpened, opt => opt.MapFrom(src => $"{src.OpenedDate:d}"))
                .ReverseMap();

            CreateMap<Account, AccountViewModel>()
                .ForMember(dest => dest.OpenedDate, opt => opt.MapFrom(src => $"{src.OpenedDate:d}"))
                .ForMember(dest => dest.SelectedPartnerId, opt => opt.MapFrom(src => src.PartnerId));

            CreateMap<AccountViewModel, Account>()
                .ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.SelectedPartnerId));
        }
    }
}
