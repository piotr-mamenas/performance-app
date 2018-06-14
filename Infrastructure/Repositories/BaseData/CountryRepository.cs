using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Countries;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.BaseData;

namespace Infrastructure.Repositories.BaseData
{
    public class CountryRepository<TSpecificEntity> : Repository<TSpecificEntity>, ICountryRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
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
