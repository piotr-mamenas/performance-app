using Core.Interfaces;
using Core.Interfaces.Repositories.Portfolio;

namespace Infrastructure.Repositories.Business.Portfolio
{
    public class PortfolioAssetPositionRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPortfolioAssetPositionRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public PortfolioAssetPositionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
