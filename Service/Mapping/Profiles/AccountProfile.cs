using AutoMapper;
using Core.Domain.Accounts;
using Service.Dtos.Account;

namespace Service.Mapping.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>()
                .ForMember(dest => dest.DateClosed, opt => opt.MapFrom(src => $"{src.ClosedDate:d}"))
                .ForMember(dest => dest.DateOpened, opt => opt.MapFrom(src => $"{src.OpenedDate:d}"))
                .ReverseMap();
        }
    }
}
