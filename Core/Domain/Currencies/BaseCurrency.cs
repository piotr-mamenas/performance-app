using System.Collections.Generic;
using Core.Domain.Assets;
using Core.Domain.Countries;
using Core.Domain.Positions;

namespace Core.Domain.Currencies
{
    public abstract class BaseCurrency<T> : BaseEntity<T> where T : BaseCurrency<T>, new()
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<Bond> Bonds { get; set; }

        public ICollection<Position> Positions { get; set; }

        protected BaseCurrency()
        {
            Countries = null;
            Bonds = null;
            Positions = null;
        }
    }
}
