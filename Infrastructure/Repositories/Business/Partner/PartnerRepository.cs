using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Partner;

namespace Infrastructure.Repositories.Business.Partner
{
    public class PartnerRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPartnerRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public PartnerRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
