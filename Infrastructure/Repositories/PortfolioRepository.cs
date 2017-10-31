using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class PortfolioRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPortfolioRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public PortfolioRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
