using System;
using System.ComponentModel.DataAnnotations;
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

        public Bond()
        {
        }

        public Bond(BondCoupon coupon, Currency currency, decimal faceValue, DateTime issueDate, DateTime maturityDate)
        {
            Coupon = coupon;
            Currency = currency;
            FaceValue = faceValue;
            IssueDate = issueDate;
            MaturityDate = maturityDate;
        }

        public void SetCoupon(decimal amount, decimal rate)
        {
            if (rate < 0 || rate > 1)
            {
                throw new ValidationException("Rate cannot be smaller than 0 or larger than 1");
            }

            if (amount <= 0)
            {
                throw new ValidationException("Amount cannot be negative");
            }

            Coupon = new BondCoupon
            {
                Rate = rate,
                Amount = amount
            };
        }
    }
}
