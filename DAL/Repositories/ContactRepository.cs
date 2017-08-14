using Core.Domain.Contact;
using Core.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class ContactRepository : Repository<BaseContact>, IContactRepository
    {
        public ContactRepository(PerformanceContext context)
            : base(context)
        {
            
        }

        public PerformanceContext PerformanceContext
        {
            get { return Context as PerformanceContext; }
        }
    }
}
