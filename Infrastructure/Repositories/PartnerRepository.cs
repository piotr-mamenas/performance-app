using Core.Domain.Partner;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class PartnerRepository : Repository<BasePartner>, IPartnerRepository
    {
        public PartnerRepository(PerformanceContext context)
            : base(context)
        {
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
