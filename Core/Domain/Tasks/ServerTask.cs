using System.Collections.Generic;
using System.Threading;
using Core.Interfaces;

namespace Core.Domain.Tasks
{
    public class ServerTask : BaseEntity, IEntityRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TaskType Type { get; set; }
        public int TypeId { get; set; }

        public ICollection<TaskRun> Runs { get; set; }

        public string Parameters { get; set; }

        public IList<string> Run(CancellationToken cancellationToken)
        {
            //
            // if (!cancellationToken.IsCancellationRequested)
            //
            return new List<string>();
        }
    }
}
