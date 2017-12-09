using Core.Domain.Identity;
using FluentValidation;

namespace Core.Validation.Identity
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Role Name must be specified");
        }
    }
}
