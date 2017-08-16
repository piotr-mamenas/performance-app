using Core.Domain.Organization;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class InstitutionRepository : Repository<BaseInstitution>, IInstitutionRepository
    {
        public InstitutionRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext
        {
            get { return Context as PerformanceContext; }
        }
    }
}
