using Core.Domain.Tasks;
using FluentValidation;

namespace Core.Validation.Tasks
{
    public class ImportTaskValidator : AbstractValidator<ImportTask>
    {
        public ImportTaskValidator()
        {
            RuleFor(it => it.Path).NotEmpty().WithMessage("Import Task Path must be specified");
        }
    }
}
