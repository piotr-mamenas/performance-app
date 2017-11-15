using Core.Domain.Partners;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class PartnerRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPartnerRepository<TSpecificEntity> where TSpecificEntity : Partner
    {
        public PartnerRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
