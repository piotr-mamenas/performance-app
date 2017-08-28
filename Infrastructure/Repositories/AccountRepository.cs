using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class AccountRepository<TSpecificEntity> : Repository<TSpecificEntity>, IAccountRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public AccountRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
