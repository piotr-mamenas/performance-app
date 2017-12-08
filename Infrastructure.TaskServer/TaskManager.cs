using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.TaskServer
{
    public class TaskManager
    {
        public TaskManager(Queue<ScheduledTask> scheduledTasks)
        {
            _scheduledTasks = scheduledTasks;
        }

        public void SubmitTask(IRunnableTask task)
        {
            var scheduledTask = new ScheduledTask(task)
            {
                Status = TechnicalTaskStatus.Submitted
            };

            _scheduledTasks.Enqueue(scheduledTask);
        }

        public bool CancelTask(ICancellableTask cancelledTask)
        {
            var task = _scheduledTasks.SingleOrDefault(t => t.TaskId == cancelledTask.Id);

            if (task == null)
            {
                throw new NullReferenceException("No task has been provided for CancelTask in TaskManager");
            }

            task.Cancel();
            task.Status = TechnicalTaskStatus.Cancelled;

            return true;
        }

        // TODO: deque logic
        private readonly Queue<ScheduledTask> _scheduledTasks;
    }
}
