using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class ContactRepository<TSpecificEntity> : Repository<TSpecificEntity>, IContactRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public ContactRepository(PerformanceContext context)
            : base(context)
        {
            
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
