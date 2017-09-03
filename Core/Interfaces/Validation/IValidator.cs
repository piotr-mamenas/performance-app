using System.Collections.Generic;
using Core.Validation;

namespace Core.Interfaces.Validation
{
    public interface IValidator
    {
        bool IsValid();
        ICollection<ValidationRule> GetBrokenRules();
    }
}
