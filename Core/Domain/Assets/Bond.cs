using System;
using System.Collections.Generic;
using Core.Domain.Currencies;
using Core.Interfaces.Validation;
using Core.Validation;
using Core.Validation.Validators;

namespace Core.Domain.Assets
{
    public class Bond : Asset
    {
        public DateTime IssueDate { get; set; }

        public DateTime MaturityDate { get; set; }

        public BondCoupon Coupon { get; set; }

        public Currency Currency { get; set; }

        public decimal FaceValue { get; set; }

        private IEnumerable<ValidationRule> _brokenRules;

        public IEnumerable<ValidationRule> SetCoupon(decimal amount, decimal rate)
        {
            var newCoupon = new BondCoupon
            {
                Rate = rate,
                Amount = amount
            };

            if (Validate(new SetBondCouponValidator(newCoupon),out _brokenRules))
            {
                Coupon = new BondCoupon
                {
                    Rate = rate,
                    Amount = amount
                };
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
