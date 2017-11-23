using AutoMapper;
using Core.Domain.Reports;
using Service.Dtos.Report;

namespace Infrastructure.AutoMapper.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportDto>().ReverseMap();
        }
    }
}
