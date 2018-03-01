using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Assets
{
    /// <summary>
    /// 
    /// </summary>
    [ComplexType]
    public class BondCoupon : ValueObject<BondCoupon>
    {
        public decimal Rate { get; set; }
        
        public decimal Amount { get; set; }

        protected override bool EqualsCore(BondCoupon comparedCoupon)
        {
            if (Rate == comparedCoupon.Rate && Amount == comparedCoupon.Amount)
            {
                return true;
            }
            return false;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = (int)Rate;
                hashCode = (hashCode * 397) ^ (int)Amount;
                return hashCode;
            }
        }
    }
}
