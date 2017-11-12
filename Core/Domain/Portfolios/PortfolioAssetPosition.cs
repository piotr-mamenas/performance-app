using System;
using Core.Domain.Assets;
using Core.Domain.Currencies;
using Core.Interfaces;

namespace Core.Domain.Portfolios
{
    public class PortfolioAssetPosition : BaseEntity, IEntityRoot
    {
        /// <summary>
        /// Amount of asset at a given time
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// What is the main currency this asset is denominated in
        /// </summary>
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        /// <summary>
        /// For which asset is the position
        /// </summary>
        public Asset Asset { get; set; }
        public int AssetId { get; set; }

        /// <summary>
        /// Portfolio ti which a position of an asset belongs
        /// </summary>
        public Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }

        /// <summary>
        /// Point of time
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
