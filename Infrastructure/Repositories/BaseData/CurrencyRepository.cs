using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Currencies;
using Core.Interfaces;
using Core.Interfaces.Repositories.BaseData;

namespace Infrastructure.Repositories.BaseData
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Currency>> GetAllCurrenciesAsync()
        {
            return await _context.Currencies.ToListAsync();
        }
    }
}
