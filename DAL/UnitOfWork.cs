using System.Threading.Tasks;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PerformanceContext _context;

        public UnitOfWork(PerformanceContext context)
        {
            _context = context;
            Partners = new PartnerRepository(_context);
            Organizations = new OrganizationRepository(_context);
            Contacts = new ContactRepository(_context);
        }

        public IPartnerRepository Partners { get; }
        public IOrganizationRepository Organizations { get; }
        public IContactRepository Contacts { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
