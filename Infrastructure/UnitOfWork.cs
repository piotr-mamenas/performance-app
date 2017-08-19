using System.Threading.Tasks;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IComplete
    {
        private readonly PerformanceContext _context;

        public UnitOfWork(PerformanceContext context)
        {
            _context = context;
            Partners = new PartnerRepository(_context);
            Institutions = new InstitutionRepository(_context);
            Contacts = new ContactRepository(_context);
            Currencies = new CurrencyRepository(_context);
            Countries = new CountryRepository(_context);
        }

        public IPartnerRepository Partners { get; }
        public IInstitutionRepository Institutions { get; }
        public IContactRepository Contacts { get; }
        public ICurrencyRepository Currencies { get; }
        public ICountryRepository Countries { get; }

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
