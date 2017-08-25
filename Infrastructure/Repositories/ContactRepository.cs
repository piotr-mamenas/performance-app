using Core.Domain.Contacts;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(PerformanceContext context)
            : base(context)
        {
            
        }

        public PerformanceContext PerformanceContext => Context as PerformanceContext;
    }
}
