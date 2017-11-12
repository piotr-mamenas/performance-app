using System;
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
using Core.Domain.Tasks;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.BaseData;
using Core.Interfaces.Repositories.Business;
using Core.Interfaces.Repositories.System;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository<Account> Accounts { get; }
        IContactRepository<Contact> Contacts { get; }
        IAssetRepository<Asset> Assets { get; }
        IAssetRepository<Bond> Bonds { get; }
        IPartnerRepository<Partner> Partners { get; }
        IPartnerRepository<AssetManager> AssetManagers { get; }
        IInstitutionRepository<Institution> Institutions { get; }
        IInstitutionRepository<Bank> Banks { get; }
        ICurrencyRepository<Currency> Currencies { get; }
        ICountryRepository<Country> Countries { get; }
        IMessageRepository<Message> Messages { get; }
        IPortfolioRepository<Portfolio> Portfolios { get; }
        ITaskRepository<ServerTask> Tasks { get; }
        Task<int> CompleteAsync();
    }
}
