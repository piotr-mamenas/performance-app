using Core.Domain.Institutions;
using FluentValidation;

namespace Core.Validation.Institutions
{
    public class BankValidator : AbstractValidator<Bank>
    {
        public BankValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Bank Name must be specified");
            RuleFor(b => b.Bic).NotEmpty().WithMessage("Bank BIC Code must be specified");
        }
    }
}
