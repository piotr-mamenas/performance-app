using Core.Domain.Partners;
using FluentValidation;

namespace Core.Validation.Partners
{
    public class PartnerValidator : AbstractValidator<Partner>
    {
        public PartnerValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Partner Name must be specified");
            RuleFor(p => p.Number).NotEmpty().WithMessage("Partner Number must be specified");
            RuleFor(p => p.PartnerTypeId).NotEmpty().WithMessage("Partner Type must be specified");
        }
    }
}
