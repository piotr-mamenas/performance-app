using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Countries;

namespace Core.Interfaces.Repositories.BaseData
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
    }
}
