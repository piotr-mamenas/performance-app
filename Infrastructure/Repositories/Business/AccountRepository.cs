using Core.Interfaces;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class AccountRepository<TSpecificEntity> : Repository<TSpecificEntity>, IAccountRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public AccountRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
