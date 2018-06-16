using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Interfaces.Repositories.Business;
namespace Infrastructure.Repositories.Business
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Account>> GetAllWithPartnerAsync()
        {
            return await Context.Accounts
                .Include(a => a.Partner)
                .ToListAsync();
        }
    }
}
