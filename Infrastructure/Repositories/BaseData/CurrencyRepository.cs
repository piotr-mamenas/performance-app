using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.BaseData;

namespace Infrastructure.Repositories.BaseData
{
    public class CurrencyRepository<TSpecificEntity> : Repository<TSpecificEntity>, ICurrencyRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public CurrencyRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
