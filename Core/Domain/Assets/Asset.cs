using System.Collections.Generic;
using Core.Domain.Positions;
using Core.Interfaces;

namespace Core.Domain.Assets
{
    public class Asset : Entity<Asset>, IEntityRoot
    {
        public string Name { get; set; }

        public string Isin { get; set; }

        public ICollection<Position> Positions { get; set; }

        public Asset()
        {
            Positions = null;
        }
    }
}
