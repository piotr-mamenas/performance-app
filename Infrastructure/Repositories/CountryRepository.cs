using Core.Domain.Country;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class CountryRepository : Repository<BaseCountry>, ICountryRepository
    {
        public CountryRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
