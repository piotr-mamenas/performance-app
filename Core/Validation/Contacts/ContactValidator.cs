using Core.Domain.Contacts;
using FluentValidation;

namespace Core.Validation.Contacts
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.PartnerId).NotEmpty().WithMessage("Contact Partner must be specified");
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Contact First Name must be specified");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Contact Last Name must be specified");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Contact Email must be specified");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Contact Name must be specified");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Incorrect Email Address provided");
        }
    }
}
