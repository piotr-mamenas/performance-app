using System.Collections.Generic;
using Core.Interfaces.Validation;
using Core.Validation;

namespace Core.Domain
{
    public class BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public bool Validate(IValidator validator, out IEnumerable<ValidationRule> brokenRules)
        {
            brokenRules = validator.GetBrokenRules();
            return validator.IsValid();
        }
    }
}
