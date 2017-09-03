using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Assets
{
    [ComplexType]
    public class BondCoupon
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }
    }
}
