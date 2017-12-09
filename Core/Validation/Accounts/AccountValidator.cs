using Core.Domain.Accounts;
using FluentValidation;

namespace Core.Validation.Accounts
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Account Name must be specified");
            RuleFor(a => a.Number).NotEmpty().WithMessage("Account Number must be specified");
            RuleFor(a => a.PartnerId).NotEmpty().WithMessage("Partner must be specified");
        }
    }
}
