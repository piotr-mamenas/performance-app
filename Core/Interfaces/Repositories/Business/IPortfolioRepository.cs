using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Portfolios;

namespace Core.Interfaces.Repositories.Business
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<Portfolio>> GetAllPortfoliosWithDetailsAsync();
    }
}