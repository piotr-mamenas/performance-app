using System.ComponentModel;

namespace Core.Dtos
{
    public class BondCouponDto
    {
        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }
    }
}
