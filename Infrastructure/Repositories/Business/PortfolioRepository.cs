using Core.Interfaces;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class PortfolioRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPortfolioRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
        public PortfolioRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
