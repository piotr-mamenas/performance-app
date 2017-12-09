using Core.Domain.Portfolios;
using FluentValidation;

namespace Core.Validation.Portfolios
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(p => p.AccountId).NotEmpty().WithMessage("Portfolio Account must be specified");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Portfolio Name must be specified");
            RuleFor(p => p.Number).NotEmpty().WithMessage("Portfolio Number must be specified");
        }
    }
}
