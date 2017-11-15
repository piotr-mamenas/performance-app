using Core.Domain.Accounts;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class AccountRepository<TSpecificEntity> : Repository<TSpecificEntity>, IAccountRepository<TSpecificEntity> where TSpecificEntity : Account
    {
        public AccountRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
