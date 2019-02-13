using AutoMapper;
using Core.Domain.Institutions;
using Service.Dtos.Institution;

namespace Service.Mapping.Profiles
{
    public class InstitutionProfile : Profile
    {
        public InstitutionProfile()
        {
            CreateMap<Institution, InstitutionDto>()
                .ReverseMap();

            CreateMap<Bank, InstitutionDto>()
                .ReverseMap();
        }
    }
}
