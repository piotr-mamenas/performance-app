using Core.Interfaces;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class PartnerRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPartnerRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
        public PartnerRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
