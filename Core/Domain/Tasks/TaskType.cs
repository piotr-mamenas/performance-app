using System.Collections.Generic;

namespace Core.Domain.Tasks
{
    public class TaskType : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ServerTask> Tasks { get; set; }

        protected TaskType()
        {
            Tasks = new List<ServerTask>();
        }
    }
}
