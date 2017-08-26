using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class PartnerRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPartnerRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public PartnerRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
