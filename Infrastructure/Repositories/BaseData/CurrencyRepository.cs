using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Currencies;
using Core.Interfaces;
using Core.Interfaces.Repositories.BaseData;

namespace Infrastructure.Repositories.BaseData
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Currency>> GetAllCurrenciesAsync()
        {
            return await Context.Currencies.ToListAsync();
        }
    }
}
