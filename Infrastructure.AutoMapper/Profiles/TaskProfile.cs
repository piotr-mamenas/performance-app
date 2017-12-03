using AutoMapper;
using Core.Domain.Tasks;
using Service.Dtos.Task;

namespace Infrastructure.AutoMapper.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<ServerTask, ServerTaskDto>()
                .ReverseMap();

            CreateMap<TaskRun, TaskRunDto>()
                .ReverseMap();
        }
    }
}
