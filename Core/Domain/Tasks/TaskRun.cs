using System;

namespace Core.Domain.Tasks
{
    public class TaskRun : BaseEntity<TaskRun>
    {
        public DateTime StartTimestamp { get; set; }

        public DateTime? EndTimestamp { get; set; }

        public decimal Progress { get; set; }

        public TaskRun()
        {
            StartTimestamp = DateTime.Now;
            Progress = 0;
        }


    }
}
