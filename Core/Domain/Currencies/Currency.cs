using System.Collections.Generic;
using Core.Domain.Assets;
using Core.Domain.Countries;
using Core.Domain.ExchangeRates;
using Core.Domain.Portfolios;
using Core.Interfaces;

namespace Core.Domain.Currencies
{
    public class Currency : BaseEntity, IEntityRoot
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<Bond> Bonds { get; set; }

        public ICollection<PortfolioAssetPosition> Positions { get; set; }

        public ICollection<ExchangeRate> ExchangeRates { get; set; }

        public Currency()
        {
            Countries = null;
            Bonds = null;
            Positions = null;
            ExchangeRates = null;
        }
    }
}
