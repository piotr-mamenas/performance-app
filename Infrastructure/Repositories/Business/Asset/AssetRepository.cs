using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Assets;

namespace Infrastructure.Repositories.Business.Asset
{
    public class AssetRepository<TSpecificEntity> : Repository<TSpecificEntity>, IAssetRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public AssetRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
