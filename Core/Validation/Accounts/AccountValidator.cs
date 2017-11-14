using Core.Domain.Accounts;
using FluentValidation;

namespace Core.Validation.Accounts
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
        }
    }
}
