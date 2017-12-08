using System;
using System.Collections.Generic;
using Core.Domain.Tasks;

namespace Infrastructure.TaskServer
{
    public class ScheduledTask
    {
        private readonly IRunnableTask _currentTask;

        public Func<IList<string>> RunningOperation { get; set; }

        public ScheduledTask(IRunnableTask task)
        {
            _currentTask = task;
        }

        public void Run()
        {
            RunningOperation = _currentTask.Run;
        }
    }
}
