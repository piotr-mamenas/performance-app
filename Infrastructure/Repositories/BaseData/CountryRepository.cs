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
    }
}
