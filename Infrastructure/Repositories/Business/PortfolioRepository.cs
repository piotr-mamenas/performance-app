using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Portfolios;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Portfolio>> GetAllPortfoliosWithDetailsAsync()
        {
            return await Context.Portfolios
                .Include(p => p.Account)
                .Include(p => p.Account.Partner)
                .Include(p => p.Assets)
                .ToListAsync();
        }
    }
}
