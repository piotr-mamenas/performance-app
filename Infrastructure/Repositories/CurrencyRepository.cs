using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class CurrencyRepository<TSpecificEntity> : Repository<TSpecificEntity>, ICurrencyRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public CurrencyRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
