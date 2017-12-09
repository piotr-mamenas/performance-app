using Core.Domain.Identity;
using FluentValidation;

namespace Core.Validation.Identity
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("User Email must be specified");
            RuleFor(u => u.PasswordHash).NotEmpty().WithMessage("User Password must be specified");
            RuleFor(u => u.UserName).NotEmpty().WithMessage("User Username must be specified");
            RuleFor(u => u.Language).NotEmpty().WithMessage("User Language must be specified");
            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("User Phone Number must be specified");
        }
    }
}
