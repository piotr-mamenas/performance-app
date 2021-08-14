using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Contacts;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsWithPartnersAsync()
        {
            return await _context.Contacts
                .Include(p => p.Partner)
                .ToListAsync();
        }
    }
}
