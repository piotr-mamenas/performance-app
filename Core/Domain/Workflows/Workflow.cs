using System;
using Core.Interfaces;

namespace Core.Domain.Workflows
{
    public class Workflow : BaseEntity, IEntityRoot
    {
        public DateTime Timestamp { get; set; }

        public WorkflowStatus Status { get; set; }
        public int StatusId { get; set; }
    }
}
