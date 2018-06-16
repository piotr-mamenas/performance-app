using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Assets;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class BondRepository : Repository<Bond>, IBondRepository
    {
        public BondRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Bond> GetBondAssetWithCurrencyAsync(int bondId)
        {
            return await GetAll()
                .Where(b => b.Id == bondId)
                .Include(b => b.Currency)
                .SingleOrDefaultAsync();
        }
    }
}
