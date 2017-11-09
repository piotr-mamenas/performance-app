using Core.Interfaces.Repositories.Partner;

namespace Infrastructure.Repositories.Business.Partner
{
    public class PartnerContactRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPartnerContactRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
        public PartnerContactRepository(ApplicationDbContext context)
            : base(context)
        {
            
        }
    }
}
