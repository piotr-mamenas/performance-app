using AutoMapper;
using Core.Domain.Partners;
using Web.ViewModels.PartnerViewModels;

namespace Web.Mapping.Profiles
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerViewModel>()
                .ForMember(dest => dest.SelectedPartnerTypeId, opt => opt.MapFrom(src => src.PartnerTypeId))
                .ReverseMap();
        }
    }
}
