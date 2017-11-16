using System.Collections.Generic;
using Core.Domain.Portfolios;
using Core.Interfaces;

namespace Core.Domain.Assets
{
    public class Asset : BaseEntity, IEntityRoot
    {
        public string Name { get; set; }

        public string Isin { get; set; }

        public AssetClass Class { get; set; }
        public int ClassId { get; set; }

        public ICollection<Portfolio> Portfolios { get; set; }

        public ICollection<AssetPrice> Prices { get; set; }

        public Asset()
        {
            Prices = null;
            Portfolios = null;
        }
    }
}
