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
            CreateMap<Partner, PartnerDto>()
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name))
                .ReverseMap();

            CreateMap<Partner, PartnerViewModel>()
                .ForMember(dest => dest.SelectedPartnerTypeId, opt => opt.MapFrom(src => src.PartnerTypeId))
                .ReverseMap();
        }
    }
}
