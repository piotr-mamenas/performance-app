using Core.Domain.Tasks;
using FluentValidation;

namespace Core.Validation.Tasks
{
    public class ExportTaskValidator : AbstractValidator<ExportTask>
    {
        public ExportTaskValidator()
        {
            RuleFor(et => et.Path).NotEmpty().WithMessage("Export Task Path must be specified");
        }
    }
}
