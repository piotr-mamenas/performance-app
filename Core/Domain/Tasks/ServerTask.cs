using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Interfaces;
using FluentValidation.Results;

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

        protected ServerTask()
        {
            Runs = new List<TaskRun>();
        }

        public Task<IList<ValidationFailure>> Run(CancellationToken cancellationToken)
        {
            while (true)
            {
                DoWork();
                if (!cancellationToken.IsCancellationRequested)
                {
                    return null;
                }
            }
        }

        public void DoWork()
        {
            // TODO: call to Windows Service in throttling loop
        }
    }
}
