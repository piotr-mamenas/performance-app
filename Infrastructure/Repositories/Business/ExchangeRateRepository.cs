using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRatesWithCurrenciesAsync()
        {
            return await Context.ExchangeRates
                .Include(er => er.BaseCurrency)
                .Include(er => er.TargetCurrency)
                .ToListAsync();
        }
    }
}
