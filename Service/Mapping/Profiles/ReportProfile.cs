using AutoMapper;
using Core.Domain.Reports;
using Service.Dtos.Report;

namespace Service.Mapping.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportDto>().ReverseMap();
        }
    }
}
