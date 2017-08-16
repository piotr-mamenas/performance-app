using Core.Domain.Currency;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class CurrencyRepository : Repository<BaseCurrency>, ICurrencyRepository
    {
        public CurrencyRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext
        {
            get { return Context as PerformanceContext; }
        }
    }
}
