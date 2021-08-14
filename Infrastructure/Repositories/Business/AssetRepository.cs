using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Assets;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public AssetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsWithPricesAsync()
        {
            return await _context.Assets
                .Include(a => a.Prices)
                .Include(a => a.Class)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsWithDetailsByPortfolioAsync(int portfolioId)
        {
            return await _context.Assets.Where(a => a.Portfolios.Any(p => p.Id == portfolioId))
                .Include(a => a.Class)
                .Include(a => a.Prices)
                .Include(a => a.Prices.Select(p => p.Currency))
                .Include(a => a.Returns)
                .ToListAsync();
        }
    }
}
