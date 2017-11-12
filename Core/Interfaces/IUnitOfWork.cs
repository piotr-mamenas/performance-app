﻿using System;
using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.Institutions;
using Core.Domain.Messages;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Core.Domain.Tasks;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Accounts;
using Core.Interfaces.Repositories.Assets;
using Core.Interfaces.Repositories.BaseData;
using Core.Interfaces.Repositories.Institutions;
using Core.Interfaces.Repositories.Partners;
using Core.Interfaces.Repositories.Portfolios;
using Core.Interfaces.Repositories.System;
using Core.Interfaces.Repositories.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository<Account> Accounts { get; }
        IAssetRepository<Asset> Assets { get; }
        IAssetRepository<Bond> Bonds { get; }
        IAssetPriceRepository<AssetPrice> AssetPrices { get; }
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
        ITaskRunRepository<TaskRun> TaskRuns { get; }
        Task<int> CompleteAsync();
    }
}
