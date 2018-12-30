using System.Collections.Generic;

namespace Core.Domain.Workflows
{
    public class WorkflowStatus : BaseEntity
    {
        public static int Initial = 1;
        public static int InProgress = 2;
        public static int Finished = 3;

        public string Name { get; set; }

        public string Caption { get; set; }

        public int Code { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<Workflow> Workflows { get; set; }

        protected WorkflowStatus()
        {
            Workflows = new List<Workflow>();
        }
    }
}
