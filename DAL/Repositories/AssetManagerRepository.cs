using Core.Domain.Partner;
using Core.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class AssetManagerRepository : Repository<AssetManager>, IAssetManagerRepository
    {
        public AssetManagerRepository(AppDbContext context)
            : base(context)
        {
        }

        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
