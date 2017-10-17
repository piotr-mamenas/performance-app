using Core.Domain.Currencies;
using Core.Interfaces;

namespace Core.Domain.Countries
{
    public class Country : Entity<Country>, IEntityRoot
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public Currency Currency { get; set; }

        public int CurrencyId { get; set; }

        public bool IsEnabled { get; set; }
    }
}
