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
    }
}
