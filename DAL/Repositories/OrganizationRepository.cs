using Core.Domain.Organization;
using Core.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class OrganizationRepository : Repository<BaseOrganization>, IOrganizationRepository
    {
        public OrganizationRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext
        {
            get { return Context as PerformanceContext; }
        }
    }
}
