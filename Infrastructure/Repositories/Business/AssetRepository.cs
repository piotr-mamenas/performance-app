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
    }
}
