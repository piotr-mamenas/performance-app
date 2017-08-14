using Core.Domain.Partner;
using Core.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class PartnerRepository : Repository<BasePartner>, IPartnerRepository
    {
        public PartnerRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext
        {
            get { return Context as PerformanceContext; }
        }
    }
}
