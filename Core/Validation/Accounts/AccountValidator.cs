using Core.Domain.Accounts;
using FluentValidation;

namespace Core.Validation.Accounts
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Field account name cannot be empty");
            RuleFor(a => a.Number).NotEmpty().WithMessage("Field account number cannot be empty");
            RuleFor(a => a.PartnerId).NotEmpty().WithMessage("Partner must be selected");
            RuleFor(a => a.OpenedDate).NotEmpty();
        }
    }
}
