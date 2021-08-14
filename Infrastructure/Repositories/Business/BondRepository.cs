using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Assets;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class BondRepository : IBondRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Bond> _bonds;

        public BondRepository(ApplicationDbContext context)
        {
            _context = context;
            _bonds = context.Set<Bond>();
        }

        public async Task<Bond> GetBondAssetWithCurrencyAsync(int bondId)
        {
            return await _bonds
                .Where(b => b.Id == bondId)
                .Include(b => b.Currency)
                .SingleOrDefaultAsync();
        }
    }
}
