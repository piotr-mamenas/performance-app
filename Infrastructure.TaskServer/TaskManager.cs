using System.Collections.Generic;

namespace Infrastructure.TaskServer
{
    public class TaskManager
    {
        public TaskManager(Queue<ScheduledTask> scheduledTasks)
        {
            _scheduledTasks = scheduledTasks;
        }

        private Queue<ScheduledTask> _scheduledTasks;
    }
}
