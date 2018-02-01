using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Currencies;

namespace Core.Domain.Assets
{
    [ComplexType]
    public class BondCoupon
    {
        public decimal Rate { get; set; }
        
        public decimal Amount { get; set; }
    }
}
