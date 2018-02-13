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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparedCoupon"></param>
        /// <returns></returns>
        protected override bool EqualsCore(BondCoupon comparedCoupon)
        {
            if (Rate == comparedCoupon.Rate && Amount == comparedCoupon.Amount)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
