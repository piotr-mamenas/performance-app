using Core.Interfaces.Repositories.Portfolios;

namespace Infrastructure.Repositories.Business.Portfolio
{
    public class PortfolioAssetPositionRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPortfolioAssetPositionRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
        public PortfolioAssetPositionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
