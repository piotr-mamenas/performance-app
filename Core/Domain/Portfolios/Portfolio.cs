using System.Collections.Generic;
using Core.Domain.Partners;
using Core.Interfaces;

namespace Core.Domain.Portfolios
{
    public class Portfolio : BaseEntity<Portfolio>, IEntityRoot
    {
        public string Number { get; set; }

        public string Name { get; set; }

        public ICollection<Partner> Partners { get; set; }
    }
}
