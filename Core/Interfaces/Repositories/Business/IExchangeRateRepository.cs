using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.ExchangeRates;

namespace Core.Interfaces.Repositories.Business
{
    public interface IExchangeRateRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : ExchangeRate
    {
        Task<IEnumerable<ExchangeRate>> GetExchangeRatesWithCurrenciesAsync();
    }
}