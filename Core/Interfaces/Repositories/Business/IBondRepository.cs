using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Assets;

namespace Core.Interfaces.Repositories.Business
{
    public interface IBondRepository : IRepository<Bond>
    {
        Task<Bond> GetBondAssetWithCurrencyAsync(int bondId);
    }
}