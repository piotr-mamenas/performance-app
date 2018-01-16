using AutoMapper;
using Core.Domain.Partners;
using Service.Dtos.Partner;
using Web.Presentation.ViewModels.PartnerViewModels;

namespace Infrastructure.AutoMapper.Profiles
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.Accounts, opt => opt.MapFrom(src => src.Accounts))
                .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contacts))
                .ReverseMap();

            CreateMap<Partner, PartnerViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.SelectedPartnerTypeId, opt => opt.MapFrom(src => src.PartnerTypeId))
                .ReverseMap();
        }
    }
}
