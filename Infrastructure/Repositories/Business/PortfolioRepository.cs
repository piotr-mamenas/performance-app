using Core.Domain.Portfolios;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class PortfolioRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPortfolioRepository<TSpecificEntity> where TSpecificEntity : Portfolio
    {
        public PortfolioRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
