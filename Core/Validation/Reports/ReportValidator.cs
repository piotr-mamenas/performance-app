using Core.Domain.Reports;
using FluentValidation;

namespace Core.Validation.Reports
{
    public class ReportValidator : AbstractValidator<Report>
    {
        public ReportValidator()
        {
            RuleFor(r => r.Description).NotEmpty().WithMessage("Report Description must be specified");
            RuleFor(r => r.Name).NotEmpty().WithMessage("Report Name must be specified");
            RuleFor(r => r.ReportHash).NotEmpty().WithMessage("Report Filename must be specified");
        }
    }
}
