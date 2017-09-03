using System.Collections.Generic;
using Core.Validation;

namespace Core.Interfaces.Validation
{
    public interface IValidatable
    {
        bool Validate(IValidator validator, out IEnumerable<ValidationRule> brokenRules);
    }
}
