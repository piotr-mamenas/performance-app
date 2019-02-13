using System.ComponentModel;

namespace Service.Dtos.Asset
{
    public class BondCouponDto
    {
        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }
    }
}
