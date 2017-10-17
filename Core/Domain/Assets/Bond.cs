using System;
using Core.Domain.Currencies;

namespace Core.Domain.Assets
{
    public class Bond : Asset
    {
        public DateTime IssueDate { get; set; }

        public DateTime MaturityDate { get; set; }

        public BondCoupon Coupon { get; set; }

        public Currency Currency { get; set; }

        public int CurrencyId { get; set; }

        public decimal FaceValue { get; set; }

        public void SetCoupon(decimal amount, decimal rate)
        {
            if (rate < 0 || rate > 1)
            {
                throw new InvalidOperationException("Rate cannot be smaller than 0% or larger than 100%");
            }

            Coupon = new BondCoupon
            {
                Rate = rate,
                Amount = amount
            };
        }
    }
}
