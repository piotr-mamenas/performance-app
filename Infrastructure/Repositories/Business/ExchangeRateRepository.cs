using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.ExchangeRates;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly ApplicationDbContext _context;

        public ExchangeRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRatesWithCurrenciesAsync()
        {
            return await _context.ExchangeRates
                .Include(er => er.BaseCurrency)
                .Include(er => er.TargetCurrency)
                .ToListAsync();
        }
    }
}
