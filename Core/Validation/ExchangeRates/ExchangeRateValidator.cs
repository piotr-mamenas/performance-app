using Core.Domain.ExchangeRates;
using FluentValidation;

namespace Core.Validation.ExchangeRates
{
    public class ExchangeRateValidator : AbstractValidator<ExchangeRate>
    {
        public ExchangeRateValidator()
        {
            RuleFor(er => er.BaseCurrencyId).NotEmpty().WithMessage("Base Currency must be specified");
            RuleFor(er => er.TargetCurrencyId).NotEmpty().WithMessage("Target Currency must be specified");
            RuleFor(er => er.Timestamp).NotEmpty().WithMessage("Exchange Rate Timestamp must be specified");

            RuleFor(er => er.Max).GreaterThan(er => er.Min).WithMessage("Exchange Rate Maximum cannot be greater than the Minimum");
            RuleFor(er => er.Min).LessThan(er => er.Max).WithMessage("Exchange Rate Minimum cannot be greater than Maximum");
            RuleFor(er => er.Rate).GreaterThanOrEqualTo(er => er.Min).WithMessage("Exchange Rate cannot be less than the Minimum");
            RuleFor(er => er.Rate).LessThanOrEqualTo(er => er.Max).WithMessage("Exchange Rate cannot be greater than the Maximum Rate");
            RuleFor(er => er.BaseCurrencyId).NotEqual(er => er.TargetCurrencyId).WithMessage("Exchange Rate Base Currency may not be the same as Target Currency");
        }
    }
}