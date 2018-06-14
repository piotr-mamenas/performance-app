using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Currencies;

namespace Core.Interfaces.Repositories.BaseData
{
    public interface ICurrencyRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
        Task<IEnumerable<Currency>> GetAllCurrenciesAsync();
    }
}
