using Core.Domain.Organization;
using Core.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class OrganizationRepository : Repository<BaseOrganization>, IOrganizationRepository
    {
        public OrganizationRepository(AppDbContext context)
            : base(context)
        {
        }

        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
