using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Countries;

namespace Core.Interfaces.Repositories.BaseData
{
    public interface ICountryRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
    }
}
