using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Domain.BaseData.Countries;
using Core.Domain.BaseData.Currencies;
using Core.Domain.Institutions;
using Core.Domain.Messages;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Core.Domain.Tasks;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Account;
using Core.Interfaces.Repositories.Asset;
using Core.Interfaces.Repositories.BaseData;
using Core.Interfaces.Repositories.Institution;
using Core.Interfaces.Repositories.Partner;
using Core.Interfaces.Repositories.Portfolio;
using Core.Interfaces.Repositories.Portfolios;
using Core.Interfaces.Repositories.System;
using Core.Interfaces.Repositories.Task;
using Infrastructure.Repositories;
using Infrastructure.Repositories.BaseData;
using Infrastructure.Repositories.Business.Account;
using Infrastructure.Repositories.Business.Asset;
using Infrastructure.Repositories.Business.Institution;
using Infrastructure.Repositories.Business.Partner;
using Infrastructure.Repositories.Business.Portfolio;
using Infrastructure.Repositories.System.Message;
using Infrastructure.Repositories.System.Task;

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
            AssetPrices = new AssetPriceRepository<AssetPrice>(_context);
            Partners = new PartnerRepository<Partner>(_context);
            AssetManagers = new PartnerRepository<AssetManager>(_context);
            Institutions = new InstitutionRepository<Institution>(_context);
            Banks = new InstitutionRepository<Bank>(_context);
            Contacts = new PartnerContactRepository<PartnerContact>(_context);
            Currencies = new CurrencyRepository<Currency>(_context);
            Countries = new CountryRepository<Country>(_context);
            Positions = new PortfolioAssetPositionRepository<PortfolioAssetPosition>(_context);
            Messages = new MessageRepository<Message>(_context);
            Portfolios = new PortfolioRepository<Portfolio>(_context);
            Tasks = new TaskRepository<ServerTask>(_context);
            TaskRuns = new TaskRunRepository<TaskRun>(_context);
        }

        public IAccountRepository<Account> Accounts { get; }
        public IAssetRepository<Asset> Assets { get; }
        public IAssetRepository<Bond> Bonds { get; }
        public IAssetPriceRepository<AssetPrice> AssetPrices { get; }
        public IPartnerRepository<Partner> Partners { get; }
        public IPartnerRepository<AssetManager> AssetManagers { get; }
        public IInstitutionRepository<Institution> Institutions { get; }
        public IInstitutionRepository<Bank> Banks { get; }
        public IPartnerContactRepository<PartnerContact> Contacts { get; }
        public ICurrencyRepository<Currency> Currencies { get; }
        public ICountryRepository<Country> Countries { get; }
        public IPortfolioAssetPositionRepository<PortfolioAssetPosition> Positions { get; }
        public IMessageRepository<Message> Messages { get; }
        public IPortfolioRepository<Portfolio> Portfolios { get; }
        public ITaskRepository<ServerTask> Tasks { get; }
        public ITaskRunRepository<TaskRun> TaskRuns { get; }

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
