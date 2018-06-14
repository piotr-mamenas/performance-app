using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Contacts;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ContactRepository<TSpecificEntity> : Repository<TSpecificEntity>, IContactRepository<TSpecificEntity> where TSpecificEntity : Contact
    {
        public ContactRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Contact>> GetAllContactsWithPartnersAsync()
        {
            return await Context.Contacts
                .Include(p => p.Partner)
                .ToListAsync();
        }
    }
}
