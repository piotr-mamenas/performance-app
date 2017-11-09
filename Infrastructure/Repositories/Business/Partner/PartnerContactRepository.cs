using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Partner;

namespace Infrastructure.Repositories.Business.Partner
{
    public class PartnerContactRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPartnerContactRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public PartnerContactRepository(ApplicationDbContext context)
            : base(context)
        {
            
        }
    }
}
