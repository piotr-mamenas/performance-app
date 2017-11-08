using System.Data.Entity;
using Core.Domain.Countries;

namespace Infrastructure.SeedData.Base
{
    public class CountrySeeder : BaseSeeder<Country>, IBaseData
    {
        public CountrySeeder(IDbSet<Country> countries)
            : base(countries)
        {
            SeededEntities.Add(new Country
            {
                Id = 1,
                Name = "Poland",
                Code = "PL",
                CurrencyId = 2,
                IsEnabled = true
            });

            SeededEntities.Add(new Country
            {
                Id = 2,
                Name = "Switzerland",
                Code = "CH",
                CurrencyId = 1,
                IsEnabled = true
            });

            SeededEntities.Add(new Country
            {
                Id = 3,
                Name = "Germany",
                Code = "DE",
                CurrencyId = 3,
                IsEnabled = true
            });

            SeededEntities.Add(new Country
            {
                Id = 4,
                Name = "Great Britain",
                Code = "GB",
                CurrencyId = 4,
                IsEnabled = true
            });

            SeededEntities.Add(new Country
            {
                Id = 5,
                Name = "United States",
                Code = "US",
                CurrencyId = 5,
                IsEnabled = true
            });
        }
    }
}
