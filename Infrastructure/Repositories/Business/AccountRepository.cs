using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Interfaces.Repositories.Business;
namespace Infrastructure.Repositories.Business
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllWithPartnerAsync()
        {
            return await _context.Accounts
                .Include(a => a.Partner)
                .ToListAsync();
        }
    }
}
