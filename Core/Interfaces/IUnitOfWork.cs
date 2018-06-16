using System;
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
using Core.Interfaces.Repositories.BaseData;
using Core.Interfaces.Repositories.Business;
using Core.Interfaces.Repositories.System;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IContactRepository Contacts { get; }
        IAssetRepository Assets { get; }
        IBondRepository Bonds { get; }
        IPartnerRepository Partners { get; }
        IInstitutionRepository Institutions { get; }
        IInstitutionRepository Banks { get; }
        ICurrencyRepository Currencies { get; }
        ICountryRepository Countries { get; }
        IMessageRepository Messages { get; }
        IPortfolioRepository Portfolios { get; }
        ITaskRepository Tasks { get; }
        IReportRepository Reports { get; }
        IExchangeRateRepository ExchangeRates { get; }
        IReturnRepository Returns { get; }
        IReturnRepository HoldingPeriodReturns { get; }
        ITileWidgetRepository TileWidgets { get; }
        Task<int> CompleteAsync();
    }
}
