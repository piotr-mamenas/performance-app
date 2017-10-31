using System;
using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Domain.Contacts;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.Institutions;
using Core.Domain.Message;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Core.Domain.Positions;
using Core.Interfaces.Repositories;

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
        IContactRepository<Contact> Contacts { get; }
        ICurrencyRepository<Currency> Currencies { get; }
        ICountryRepository<Country> Countries { get; }
        IPositionRepository<Position> Positions { get; }
        IMessageRepository<Message> Messages { get; }
        IPortfolioRepository<Portfolio> Portfolios { get; }
        Task<int> CompleteAsync();
    }
}
