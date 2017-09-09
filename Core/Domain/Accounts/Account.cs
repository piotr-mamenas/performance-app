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
        public IEnumerable<ValidationRule> OpenNewAccount(string name, string number, Partner partner)
        {
            if (Validate(new OpenNewAccountValidator(this), out IEnumerable<ValidationRule> brokenRules))
            {
                Name = name;
                Number = number;
                OpenedDate = DateTime.Today;
                Partners.Add(partner);
            }
            return brokenRules;
        }

        private string GetAccountNumber(Partner partner)
        {
            return "";
        }
    }
}
