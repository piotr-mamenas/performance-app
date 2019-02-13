using AutoMapper;
using Core.Domain.Partners;
using Service.Dtos.Partner;

namespace Service.Mapping.Profiles
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDto>()
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name))
                .ReverseMap();
        }
    }
}
