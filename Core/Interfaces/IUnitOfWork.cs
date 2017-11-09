using System;
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
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Account;
using Core.Interfaces.Repositories.Asset;
using Core.Interfaces.Repositories.BaseData;
using Core.Interfaces.Repositories.Institution;
using Core.Interfaces.Repositories.Partner;
using Core.Interfaces.Repositories.Portfolio;
using Core.Interfaces.Repositories.System;
using Core.Interfaces.Repositories.Task;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository<Account> Accounts { get; }
        IAssetRepository<Asset> Assets { get; }
        IAssetRepository<Bond> Bonds { get; }
        IPartnerRepository<Partner> Partners { get; }
        IPartnerRepository<AssetManager> AssetManagers { get; }
        IInstitutionRepository<Institution> Institutions { get; }
        IInstitutionRepository<Bank> Banks { get; }
        IPartnerContactRepository<PartnerContact> Contacts { get; }
        ICurrencyRepository<Currency> Currencies { get; }
        ICountryRepository<Country> Countries { get; }
        IPortfolioAssetPositionRepository<PortfolioAssetPosition> Positions { get; }
        IMessageRepository<Message> Messages { get; }
        IPortfolioRepository<Portfolio> Portfolios { get; }
        ITaskRepository<ServerTask> Tasks { get; }
        Task<int> CompleteAsync();
    }
}
