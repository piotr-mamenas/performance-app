using AutoMapper;
using Core.Domain.Contacts;
using Service.Dtos.Contact;

namespace Service.Mapping.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>()
                .ReverseMap();
        }
    }
}
