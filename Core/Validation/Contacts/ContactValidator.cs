using Core.Domain.Contacts;
using FluentValidation;

namespace Core.Validation.Contacts
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.PartnerId).NotEmpty().WithMessage("Partner for Contact must be specified");
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Contact first name must be specified");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Contact last name must be specified");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Contact email must be specified");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Contact name must be specified");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Incorrect email provided");
            //TODO: Phone Number validation
        }
    }
}
