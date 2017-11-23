using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Domain.Contacts;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.Institutions;
using Core.Domain.Messages;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Core.Domain.Reports;
using Core.Domain.Tasks;
using Core.Interfaces;
using Core.Interfaces.Repositories.BaseData;
using Core.Interfaces.Repositories.Business;
using Core.Interfaces.Repositories.System;
using Infrastructure.Repositories.BaseData;
using Infrastructure.Repositories.Business;
using Infrastructure.Repositories.System;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IComplete
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Accounts = new AccountRepository<Account>(_context);
            Assets = new AssetRepository<Asset>(_context);
            Bonds = new AssetRepository<Bond>(_context);
            Contacts = new ContactRepository<Contact>(_context);
            Partners = new PartnerRepository<Partner>(_context);
            Institutions = new InstitutionRepository<Institution>(_context);
            Banks = new InstitutionRepository<Bank>(_context);
            Currencies = new CurrencyRepository<Currency>(_context);
            Countries = new CountryRepository<Country>(_context);
            Messages = new MessageRepository<Message>(_context);
            Portfolios = new PortfolioRepository<Portfolio>(_context);
            Tasks = new TaskRepository<ServerTask>(_context);
            Reports = new ReportRepository<Report>(_context);
        }

        public IAccountRepository<Account> Accounts { get; }
        public IAssetRepository<Asset> Assets { get; }
        public IAssetRepository<Bond> Bonds { get; }
        public IPartnerRepository<Partner> Partners { get; }
        public IInstitutionRepository<Institution> Institutions { get; }
        public IInstitutionRepository<Bank> Banks { get; }
        public IContactRepository<Contact> Contacts { get; }
        public ICurrencyRepository<Currency> Currencies { get; }
        public ICountryRepository<Country> Countries { get; }
        public IMessageRepository<Message> Messages { get; }
        public IPortfolioRepository<Portfolio> Portfolios { get; }
        public ITaskRepository<ServerTask> Tasks { get; }
        public IReportRepository<Report> Reports { get; }

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
