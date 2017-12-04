namespace Core.Domain.Workflows
{
    public class WorkflowTransition : BaseEntity
    {
        public string Name { get; set; }

        public string Caption { get; set; }

        public WorkflowStatus TransitionFrom { get; set; }

        public WorkflowStatus TransitionTo { get; set; }
    }
}
