using System.Collections.Generic;
using Core.Domain.Currencies;

namespace Core.Domain.Countries
{
    public abstract class BaseCountry<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public Currency Currency { get; set; }

        public int CurrencyId { get; set; }
        
        public bool IsEnabled { get; set; }
    }
}
