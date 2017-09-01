using System;
using Core.Domain.ComplexTypes;
using Core.Domain.Currencies;

namespace Core.Domain.Assets
{
    public class Bond : Asset
    {
        public DateTime IssueDate { get; set; }

        public DateTime MaturityDate { get; set; }

        public BondCoupon Coupon { get; set; }

        public Currency Currency { get; set; }

        public decimal FaceValue { get; set; }

        public void SetCoupon(decimal amount, decimal rate)
        {
            Coupon = new BondCoupon
            {
                Rate = rate,
                Amount = amount
            };
        }
    }
}
