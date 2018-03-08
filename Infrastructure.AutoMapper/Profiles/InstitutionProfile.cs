using AutoMapper;
using Core.Domain.Institutions;
using Service.Dtos.Institution;

namespace Infrastructure.AutoMapper.Profiles
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
