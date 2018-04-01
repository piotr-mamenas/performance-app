using Core.Domain.Portfolios;
using Core.Interfaces.Repositories;

namespace Core.Services
{
    public class PortfolioService
    {
        private readonly IRepository<Portfolio> _portfolioRepository;

        public PortfolioService(IRepository<Portfolio> portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }
    }
}
