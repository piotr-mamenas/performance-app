using System;

namespace Core.Domain.Tasks
{
    /// <summary>
    /// Represents a single instance of a run of a predefined task
    /// </summary>
    public class TaskRun : BaseEntity<TaskRun>
    {
        public string Name { get; set; }

        public ServerTask Task { get; set; }
        public int TaskId { get; set; }

        public DateTime StartTimestamp { get; set; }

        public DateTime? EndTimestamp { get; set; }

        public int Progress { get; set; }

        public TaskRun()
        {
            StartTimestamp = DateTime.Now;
            Progress = 0;
        }
    }
}
