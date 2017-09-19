using System;
using System.ComponentModel;
using Core.Domain.Currencies;

namespace Core.Dtos
{
    public class AssetDto
    {
        public int Id { get; set; }

        [DisplayName("Asset Name")]
        public string Name { get; set; }

        [DisplayName("Asset ISIN")]
        public string Isin { get; set; }

        [DisplayName("Issue Date")]
        public DateTime IssueDate { get; set; }

        [DisplayName("Maturity Date")]
        public DateTime MaturityDate { get; set; }

        public BondCouponDto Coupon { get; set; }

        [DisplayName("Currency")]
        public Currency Currency { get; set; }

        public int CurrencyId { get; set; }

        [DisplayName("Face Value")]
        public decimal FaceValue { get; set; }
    }
}
