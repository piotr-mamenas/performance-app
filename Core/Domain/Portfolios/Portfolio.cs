using System.Collections.Generic;
using Core.Domain.Accounts;
using Core.Interfaces;

namespace Core.Domain.Portfolios
{
    public class Portfolio : BaseEntity<Portfolio>, IEntityRoot
    {
        public string Number { get; set; }

        public string Name { get; set; }

        public Account Account { get; set; }
        public int AccountId { get; set; }

        public ICollection<PortfolioAssetPosition> Positions { get; set; }
    }
}
