using AutoMapper;
using Core.Domain.Contacts;
using Service.Dtos.Contact;
using Web.Presentation.ViewModels.ContactViewModels;

namespace Infrastructure.AutoMapper.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>()
                .ReverseMap();

            CreateMap<Contact, ContactViewModel>()
                .ForMember(dest => dest.SelectedPartnerId, opt => opt.MapFrom(src => src.PartnerId))
                .ReverseMap();
        }
    }
}
