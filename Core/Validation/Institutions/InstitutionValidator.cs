using Core.Domain.Institutions;
using FluentValidation;

namespace Core.Validation.Institutions
{
    public class InstitutionValidator : AbstractValidator<Institution>
    {
        public InstitutionValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Institution Name must be specified");
        }
    }
}
