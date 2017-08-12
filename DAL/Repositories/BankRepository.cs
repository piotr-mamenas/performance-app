using Core.Domain.Organization;
using Core.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(AppDbContext context)
            : base(context)
        {
        }

        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
