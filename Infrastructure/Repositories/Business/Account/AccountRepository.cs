using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Accounts;

namespace Infrastructure.Repositories.Business.Account
{
    public class AccountRepository<TSpecificEntity> : Repository<TSpecificEntity>, IAccountRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public AccountRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
