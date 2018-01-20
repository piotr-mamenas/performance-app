using Core.Domain.ExchangeRates;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ExchangeRateRepository<TSpecificEntity> : Repository<TSpecificEntity>, IExchangeRateRepository<TSpecificEntity> where TSpecificEntity : ExchangeRate
    {
        public ExchangeRateRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
