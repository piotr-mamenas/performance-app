using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Domain.Assets;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class AssetRepository<TSpecificEntity> : Repository<TSpecificEntity>, IAssetRepository<TSpecificEntity> where TSpecificEntity : Asset
    {
        public AssetRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<AssetPrice>> GetPrices(Expression<Func<AssetPrice,bool>> predicate)
        {
            return await Context.Set<AssetPrice>()
                .Where(predicate)
                .Include(ap => ap.Asset)
                .Include(ap => ap.Currency)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsWithDetailsByPortfolioAsync(int portfolioId)
        {
            return await Context.Assets.Where(a => a.Portfolios.Any(p => p.Id == portfolioId))
                .Include(a => a.Class)
                .Include(a => a.Prices)
                .Include(a => a.Prices.Select(p => p.Currency))
                .Include(a => a.Returns)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asset>> GetBondAssetCurrencyAsync(int assetId)
        {
            return await Context.Assets
                .Include(b => b.Currency)
                .SingleOrDefault(b => b.Id == assetDto.Id);
        }
    }
}
