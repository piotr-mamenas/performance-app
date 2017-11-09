using Core.Interfaces.Repositories.Assets;

namespace Infrastructure.Repositories.Business.Asset
{
    class AssetPriceRepository<TSpecificEntity> : Repository<TSpecificEntity>, IAssetPriceRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
        public AssetPriceRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
