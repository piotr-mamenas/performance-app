using AutoMapper;
using Core.Domain.Contacts;
using Web.ViewModels.ContactViewModels;

namespace Web.Mapping.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactViewModel>()
                .ForMember(dest => dest.SelectedPartnerId, opt => opt.MapFrom(src => src.PartnerId))
                .ReverseMap();
        }
    }
}
