using Core.Domain.BaseData.Currencies;
using Core.Interfaces;

namespace Core.Domain.BaseData.Countries
{
    public class Country : BaseEntity<Country>, IEntityRoot
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public bool IsEnabled { get; set; }
    }
}
