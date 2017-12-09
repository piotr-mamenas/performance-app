using Core.Domain.Assets;
using FluentValidation;

namespace Core.Validation.Assets
{
    public class AssetValidator : AbstractValidator<Asset>
    {
        public AssetValidator()
        {
            RuleFor(a => a.ClassId).NotEmpty().WithMessage("Asset Class must be specified");
            RuleFor(a => a.Name).NotEmpty().WithMessage("Asset Name must be specified");
        }
    }
}
