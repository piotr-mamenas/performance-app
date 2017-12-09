using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.TaskServer.Interfaces;

namespace Infrastructure.TaskServer
{
    public class TaskManager
    {
        public TaskManager()
        {
            _scheduledTasks = new List<ScheduledTask>();
        }

        public TaskManager(IList<ScheduledTask> scheduledTasks)
        {
            _scheduledTasks = scheduledTasks;
        }

        public void SubmitTask(IRunnableTask task)
        {
            var scheduledTask = new ScheduledTask(task);

            _scheduledTasks.Add(scheduledTask);
        }

        public void CancelTask(ICancellableTask cancelledTask)
        {
            var task = _scheduledTasks.SingleOrDefault(t => t.TaskId == cancelledTask.Id);

            if (task == null)
            {
                throw new NullReferenceException($"TaskId {cancelledTask.Id} could not be found");
            }
            task.Cancel();
        }

        public void CancelTask(int cancelledTaskId)
        {
            var task = _scheduledTasks.SingleOrDefault(t => t.TaskId == cancelledTaskId);

            if (task == null)
            {
                throw new NullReferenceException($"TaskId {cancelledTaskId} could not be found");
            }

            task.Cancel();

            _scheduledTasks.Remove(task);
        }

        public void RunNext()
        {
            var task = _scheduledTasks[0];

            task.Run();

            _scheduledTasks.RemoveAt(0);
        }
        
        private readonly IList<ScheduledTask> _scheduledTasks;
    }
}
