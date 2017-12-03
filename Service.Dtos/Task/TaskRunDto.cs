using System;

namespace Service.Dtos.Task
{
    public class TaskRunDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public TaskTypeDto Type { get; set; }

        public DateTime StartTimestamp { get; set; }

        public DateTime? EndTimestamp { get; set; }

        public int Progress { get; set; }
    }
}
