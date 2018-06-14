using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Portfolios;

namespace Core.Interfaces.Repositories.Business
{
    public interface IPortfolioRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Portfolio
    {
        Task<IEnumerable<Portfolio>> GetAllPortfoliosWithDetailsAsync();
    }
}