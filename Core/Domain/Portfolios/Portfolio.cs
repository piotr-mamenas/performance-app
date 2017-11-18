using System.Collections.Generic;
using System.Linq;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Interfaces;

namespace Core.Domain.Portfolios
{
    public class Portfolio : BaseEntity, IEntityRoot
    {
        public string Number { get; set; }

        public string Name { get; set; }

        public Account Account { get; set; }
        public int AccountId { get; set; }

        public ICollection<Asset> Assets { get; set; }

        public ICollection<PortfolioAssetPosition> Positions { get; set; }

        public Portfolio()
        {
            Assets = null;
            Positions = null;
        }
    }
}
