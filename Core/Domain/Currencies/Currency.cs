using System.Collections.Generic;
using Core.Domain.Assets;
using Core.Domain.Countries;
using Core.Domain.Positions;
using Core.Interfaces;

namespace Core.Domain.Currencies
{
    public class Currency : BaseEntity<Currency>, IEntityRoot
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<Bond> Bonds { get; set; }

        public ICollection<Position> Positions { get; set; }

        public Currency()
        {
            Countries = null;
            Bonds = null;
            Positions = null;
        }
    }
}
