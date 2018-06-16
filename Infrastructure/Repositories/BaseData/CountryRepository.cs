using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Countries;
using Core.Interfaces.Repositories.BaseData;

namespace Infrastructure.Repositories.BaseData
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await Context.Countries.ToListAsync();
        }
    }
}
