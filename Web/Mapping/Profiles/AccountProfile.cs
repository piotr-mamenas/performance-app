using AutoMapper;
using Core.Domain.Accounts;
using Web.ViewModels.AccountViewModels;

namespace Web.Mapping.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountViewModel>()
                .ForMember(dest => dest.OpenedDate, opt => opt.MapFrom(src => $"{src.OpenedDate:d}"))
                .ForMember(dest => dest.SelectedPartnerId, opt => opt.MapFrom(src => src.PartnerId));

            CreateMap<AccountViewModel, Account>()
                .ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.SelectedPartnerId));
        }
    }
}
