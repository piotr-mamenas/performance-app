using System.CodeDom;
using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Domain.Contacts;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.ExchangeRates;
using Core.Domain.Institutions;
using Core.Domain.Messages;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Core.Domain.Reports;
using Core.Domain.Returns;
using Core.Domain.Tasks;
using Core.Domain.TileWidgets;
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

            Accounts = new AccountRepository(_context);
            Assets = new AssetRepository(_context);
            Bonds = new BondRepository(_context);
            Contacts = new ContactRepository(_context);
            Partners = new PartnerRepository(_context);
            Institutions = new InstitutionRepository(_context);
            Banks = new InstitutionRepository(_context);
            Currencies = new CurrencyRepository(_context);
            Countries = new CountryRepository(_context);
            Messages = new MessageRepository(_context);
            Portfolios = new PortfolioRepository(_context);
            Tasks = new TaskRepository(_context);
            Reports = new ReportRepository(_context);
            ExchangeRates = new ExchangeRateRepository(_context);
            Returns = new ReturnRepository(_context);
            HoldingPeriodReturns = new ReturnRepository(_context);
            TileWidgets = new TileWidgetRepository(_context);
        }

        public IAccountRepository Accounts { get; }
        public IAssetRepository Assets { get; }
        public IBondRepository Bonds { get; }
        public IPartnerRepository Partners { get; }
        public IInstitutionRepository Institutions { get; }
        public IInstitutionRepository Banks { get; }
        public IContactRepository Contacts { get; }
        public ICurrencyRepository Currencies { get; }
        public ICountryRepository Countries { get; }
        public IMessageRepository Messages { get; }
        public IPortfolioRepository Portfolios { get; }
        public ITaskRepository Tasks { get; }
        public IReportRepository Reports { get; }
        public IExchangeRateRepository ExchangeRates { get; }
        public IReturnRepository Returns { get; }
        public IReturnRepository HoldingPeriodReturns { get; }
        public ITileWidgetRepository TileWidgets { get; }

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
