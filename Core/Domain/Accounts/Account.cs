using System;
using System.Collections.Generic;
using Core.Domain.Partners;
using Core.Interfaces;
using Core.Interfaces.Validation;
using Core.Validation;
using Core.Validation.Validators;

namespace Core.Domain.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class Account : BaseAccount<Account>, IEntityRoot, IValidatable
    {
        private IEnumerable<ValidationRule> _brokenRules;

        public IEnumerable<ValidationRule> OpenNewAccount(string name, string number, Partner partner)
        {
            if (Validate(new OpenNewAccountValidator(this), out _brokenRules))
            {
                Name = name;
                Number = number;
                OpenedDate = DateTime.Today;
                Partners.Add(partner);
            }
            return _brokenRules;
        }

        public bool Validate(IValidator validator, out IEnumerable<ValidationRule> brokenRules)
        {
            brokenRules = validator.GetBrokenRules();
            return validator.IsValid();
        }
    }
}
