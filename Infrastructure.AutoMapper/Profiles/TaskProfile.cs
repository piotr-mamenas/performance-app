using AutoMapper;
using Core.Domain.Tasks;
using Service.Dtos.Task;

namespace Infrastructure.AutoMapper.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskRun, TaskRunDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(tr => tr.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(tr => tr.Name))
                .ForMember(dto => dto.TypeName, opt => opt.MapFrom(tr => tr.Task.Type.Name))
                .ForMember(dto => dto.StartTimestamp, opt => opt.MapFrom(tr => tr.StartTimestamp))
                .ForMember(dto => dto.EndTimestamp, opt => opt.MapFrom(tr => tr.EndTimestamp))
                .ForMember(dto => dto.Progress, opt => opt.MapFrom(tr => tr.Progress))
                .ReverseMap();

            CreateMap<ServerTask, ServerTaskDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(st => st.Id))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(st => st.Description))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(st => st.Name))
                .ForMember(dto => dto.TypeName, opt => opt.MapFrom(st => st.Type.Name))
                .ForMember(dto => dto.Runs, opt => opt.MapFrom(st => st.Runs))
                .ReverseMap();
        }
    }
}
