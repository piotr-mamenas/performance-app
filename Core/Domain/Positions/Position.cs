using System;
using Core.Domain.Assets;
using Core.Domain.Currencies;
using Core.Interfaces;

namespace Core.Domain.Positions
{
    public class Position : BaseEntity<Position>, IEntityRoot
    {
        public decimal Amount { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public Asset Asset { get; set; }
        public int AssetId { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
