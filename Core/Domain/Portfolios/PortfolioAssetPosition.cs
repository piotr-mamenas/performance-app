using System;
using Core.Domain.Assets;
using Core.Domain.Currencies;
using Core.Interfaces;

namespace Core.Domain.Portfolios
{
    public class PortfolioAssetPosition : BaseEntity, IEntityRoot
    {
        public decimal Amount { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public Asset Asset { get; set; }
        public int AssetId { get; set; }

        public Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
