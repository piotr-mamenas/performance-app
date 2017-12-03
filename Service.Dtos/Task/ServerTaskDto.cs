using System.Collections.Generic;

namespace Service.Dtos.Task
{
    public class ServerTaskDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public ICollection<TaskRunDto> Runs { get; set; }
    }
}
