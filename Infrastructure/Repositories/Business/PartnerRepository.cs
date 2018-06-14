using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public IQueryable<PartnerType> GetTypesAsQueryable()
        {
            return Context.PartnerTypes.AsQueryable();
        }

        public async Task<IEnumerable<Partner>> GetAllPartnersAsync()
        {
            return await Context.Partners.ToListAsync();
        }

        public async Task<IEnumerable<Partner>> GetAllPartnersWithTypesAsync()
        {
            return await Context.Partners.Include(p => p.Type).ToListAsync();
        }

        public async Task<IEnumerable<Partner>> GetAccountPartnersAsync(int accountId)
        {
            return await Context.Partners.Where(a => a.Accounts.Any(p => p.Id == accountId)).ToListAsync();
        }

        public async Task<Partner> GetByIdWithAccountsAndContactsAsync(int id)
        {
            return await Context.Partners.Where(p => p.Id == id)
                .Include(p => p.Accounts)
                .Include(p => p.Contacts)
                .SingleOrDefaultAsync();
        }
    }
}
