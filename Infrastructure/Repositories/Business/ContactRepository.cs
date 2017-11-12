using Core.Interfaces;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ContactRepository<TSpecificEntity> : Repository<TSpecificEntity>, IContactRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
        public ContactRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
