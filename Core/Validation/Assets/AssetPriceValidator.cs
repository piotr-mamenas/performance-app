using Core.Domain.Assets;
using FluentValidation;

namespace Core.Validation.Assets
{
    public class AssetPriceValidator : AbstractValidator<AssetPrice>
    {
        public AssetPriceValidator()
        {
            RuleFor(ap => ap.Amount).LessThanOrEqualTo(0).WithMessage("Asset price cannot be less than or equal 0");
            RuleFor(ap => ap.AssetId).NotEmpty().WithMessage("Asset for the asset price must be present");
            RuleFor(ap => ap.CurrencyId).NotEmpty().WithMessage("Asset price must have Currency specified");
            RuleFor(ap => ap.Timestamp).NotEmpty().WithMessage("Timestamp must be specified");
        }
    }
}
