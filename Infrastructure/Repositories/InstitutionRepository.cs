using Core.Domain.Institution;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class InstitutionRepository : Repository<BaseInstitution>, IInstitutionRepository
    {
        public InstitutionRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
