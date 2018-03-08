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
                .ForMember(dto => dto.TypeName, opt => opt.MapFrom(tr => tr.Task.Type.Name))
                .ReverseMap();

            CreateMap<ServerTask, ServerTaskDto>()
                .ForMember(dto => dto.TypeName, opt => opt.MapFrom(st => st.Type.Name))
                .ReverseMap();
        }
    }
}
