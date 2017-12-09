using Core.Domain.Workflows;
using FluentValidation;

namespace Core.Validation.Workflows
{
    public class WorkflowValidator : AbstractValidator<Workflow>
    {
        public WorkflowValidator()
        {
            RuleFor(wf => wf.StatusId).NotEmpty().WithMessage("Workflow Status must be specified");
            RuleFor(wf => wf.Timestamp).NotEmpty().WithMessage("Workflow Timestamp must be specified");
        }
    }
}
