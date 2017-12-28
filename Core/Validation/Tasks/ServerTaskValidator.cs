using Core.Domain.Tasks;
using FluentValidation;

namespace Core.Validation.Tasks
{
    public class ServerTaskValidator : AbstractValidator<ServerTask>
    {
        public ServerTaskValidator()
        {
            RuleFor(st => st.Description).NotEmpty().WithMessage("Task Description must be specified");
            RuleFor(st => st.Name).NotEmpty().WithMessage("Task Name must be specified");
            RuleFor(st => st.TypeId).NotEmpty().WithMessage("Task Type must be specified");
        }
    }
}
