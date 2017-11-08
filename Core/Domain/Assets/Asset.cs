using System.Collections.Generic;
using Core.Domain.Positions;
using Core.Interfaces;

namespace Core.Domain.Assets
{
    public class Asset : BaseEntity<Asset>, IEntityRoot
    {
        public string Name { get; set; }

        public string Isin { get; set; }

        public ICollection<Position> Positions { get; set; }

        public ICollection<AssetPrice> Prices { get; set; }

        public Asset()
        {
            Positions = null;
            Prices = null;
        }
    }
}
