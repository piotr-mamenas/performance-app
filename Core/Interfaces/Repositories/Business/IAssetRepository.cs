using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Domain.Assets;

namespace Core.Interfaces.Repositories.Business
{
    public interface IAssetRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Asset
    {
        Task<IEnumerable<AssetPrice>> GetPrices(Expression<Func<AssetPrice, bool>> predicate);
    }
}
