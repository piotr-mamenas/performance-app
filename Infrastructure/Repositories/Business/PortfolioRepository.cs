using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Portfolios;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Portfolio>> GetAllPortfoliosWithDetailsAsync()
        {
            return await _context.Portfolios
                .Include(p => p.Account)
                .Include(p => p.Account.Partner)
                .Include(p => p.Assets)
                .ToListAsync();
        }
    }
}
