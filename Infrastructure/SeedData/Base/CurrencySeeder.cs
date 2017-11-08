using System.Data.Entity;
using Core.Domain.Currencies;

namespace Infrastructure.SeedData.Base
{
    public class CurrencySeeder : BaseSeeder<Currency>, IBaseData
    {
        public CurrencySeeder(IDbSet<Currency> currencies)
            : base(currencies)
        {
            SeededEntities.Add(new Currency
            {
                Id = 1,
                Code = "CHF",
                IsEnabled = true,
                Name = "Swiss Franc"
            });

            SeededEntities.Add(new Currency
            {
                Id = 2,
                Code = "PLN",
                IsEnabled = true,
                Name = "Zloty"
            });

            SeededEntities.Add(new Currency
            {
                Id = 3,
                Code = "EUR",
                IsEnabled = true,
                Name = "Euro"
            });

            SeededEntities.Add(new Currency
            {
                Id = 4,
                Code = "GBP",
                IsEnabled = true,
                Name = "Pound"
            });

            SeededEntities.Add(new Currency
            {
                Id = 5,
                Code = "USD",
                IsEnabled = true,
                Name = "US Dollar"
            });
        }
    }
}
