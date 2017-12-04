using System.Collections.Generic;

namespace Core.Domain.Workflows
{
    public class WorkflowStatus : BaseEntity
    {
        public string Name { get; set; }

        public string Designation { get; set; }

        public int Code { get; set; }

        public ICollection<Workflow> Workflows { get; set; }
    }
}
