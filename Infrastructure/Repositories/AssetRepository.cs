using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class AssetRepository<TSpecificEntity> : Repository<TSpecificEntity>, IAssetRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public AssetRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
