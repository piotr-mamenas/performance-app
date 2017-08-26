using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class CountryRepository<TSpecificEntity> : Repository<TSpecificEntity>, ICountryRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public CountryRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
