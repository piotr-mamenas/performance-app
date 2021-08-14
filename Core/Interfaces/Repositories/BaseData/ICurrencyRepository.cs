using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Currencies;

namespace Core.Interfaces.Repositories.BaseData
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllCurrenciesAsync();
    }
}
