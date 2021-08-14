using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Partners;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly ApplicationDbContext _context;

        public PartnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Partner>> GetAllPartnersAsync()
        {
            return await _context.Partners.ToListAsync();
        }

        public async Task<IEnumerable<Partner>> GetAllPartnersWithTypesAsync()
        {
            return await _context.Partners.Include(p => p.Type).ToListAsync();
        }

        public async Task<IEnumerable<Partner>> GetAccountPartnersAsync(int accountId)
        {
            return await _context.Partners.Where(a => a.Accounts.Any(p => p.Id == accountId)).ToListAsync();
        }

        public async Task<Partner> GetByIdWithAccountsAndContactsAsync(int id)
        {
            return await _context.Partners.Where(p => p.Id == id)
                .Include(p => p.Accounts)
                .Include(p => p.Contacts)
                .SingleOrDefaultAsync();
        }
    }
}
