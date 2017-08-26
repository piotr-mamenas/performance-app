using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class InstitutionRepository<TSpecificEntity> : Repository<TSpecificEntity>, IInstitutionRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public InstitutionRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
