using System;
using Core.Domain.BaseData.Currencies;

namespace Core.Domain.Assets
{
    public class AssetPrice : BaseEntity
    {
        public Asset Asset { get; set; }
        public int AssetId { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal Amount { get; set; }
    }
}
