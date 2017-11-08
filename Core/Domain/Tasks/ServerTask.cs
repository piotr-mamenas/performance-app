using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Domain.Tasks
{
    public class ServerTask : BaseEntity<ServerTask>, IEntityRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<TaskRun> Runs { get; set; }
    }
}
