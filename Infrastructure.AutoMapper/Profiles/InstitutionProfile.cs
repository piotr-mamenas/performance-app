using AutoMapper;
using Core.Domain.Institutions;
using Service.Dtos;
using Service.Dtos.Institution;

namespace Infrastructure.AutoMapper.Profiles
{
    public class InstitutionProfile : Profile
    {
        public InstitutionProfile()
        {
            CreateMap<Institution, InstitutionDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Bank, InstitutionDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Bic, opt => opt.MapFrom(src => src.Bic))
                .ReverseMap();
        }
    }
}
