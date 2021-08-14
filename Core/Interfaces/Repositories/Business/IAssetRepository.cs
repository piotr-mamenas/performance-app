using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Domain.Assets;

namespace Core.Interfaces.Repositories.Business
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAssetsWithDetailsByPortfolioAsync(int portfolioId);
        Task<IEnumerable<Asset>> GetAllAssetsWithPricesAsync();
    }
}
