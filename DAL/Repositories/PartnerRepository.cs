using Core.Domain.Partner;
using Core.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class PartnerRepository : Repository<BasePartner>, IPartnerRepository
    {
        public PartnerRepository(AppDbContext context)
            : base(context)
        {
        }

        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
