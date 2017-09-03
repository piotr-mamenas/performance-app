using System.Collections.Generic;
using Core.Domain.Assets;
using Core.Interfaces.Validation;

namespace Core.Validation.Validators
{
    public class SetBondCouponValidator : IValidator
    {
        public SetBondCouponValidator(BondCoupon bondCoupon)
        {
            BondCouponValidated = bondCoupon;
        }

        public ICollection<ValidationRule> BrokenRules => GetBrokenRules();
        public BondCoupon BondCouponValidated { get; set; }

        public bool IsValid()
        {
            return BrokenRules.Count < 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICollection<ValidationRule> GetBrokenRules()
        {
            if (BondCouponValidated.Rate < 0 || BondCouponValidated.Rate > 1)
            {
                BrokenRules.Add(new ValidationRule
                {
                    Name = "",
                    Message = "Bond Coupon Rate must be positive"
                });
            }

            if (BondCouponValidated.Rate > 1)
            {
                BrokenRules.Add(new ValidationRule
                {
                    Name = "",
                    Message = "Bond Coupon Rate may not be higher than 100%"
                });
            }

            if (BondCouponValidated.Amount < 0)
            {
                BrokenRules.Add(new ValidationRule
                {
                    Name = "",
                    Message = "A bond payable amount cannot be less than 0"
                });
            }

            return BrokenRules;
        }
    }
}
