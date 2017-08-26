using System.Threading.Tasks;
using Core.Domain.Contacts;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.Institutions;
using Core.Domain.Partners;
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
            Partners = new PartnerRepository<Partner>(_context);
            AssetManagers = new PartnerRepository<AssetManager>(_context);
            Institutions = new InstitutionRepository<Institution>(_context);
            Banks = new InstitutionRepository<Bank>(_context);
            Contacts = new ContactRepository<Contact>(_context);
            Currencies = new CurrencyRepository<Currency>(_context);
            Countries = new CountryRepository<Country>(_context);
        }

        public IPartnerRepository<Partner> Partners { get; }
        public IPartnerRepository<AssetManager> AssetManagers { get; }
        public IInstitutionRepository<Institution> Institutions { get; }
        public IInstitutionRepository<Bank> Banks { get; }
        public IContactRepository<Contact> Contacts { get; }
        public ICurrencyRepository<Currency> Currencies { get; }
        public ICountryRepository<Country> Countries { get; }

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
