﻿using System;
using System.Threading.Tasks;
using Core.Domain.Contacts;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.Institutions;
using Core.Domain.Partners;
using Core.Interfaces.Repositories;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPartnerRepository<Partner> Partners { get; }
        IPartnerRepository<AssetManager> AssetManagers { get; }
        IInstitutionRepository<Institution> Institutions { get; }
        IInstitutionRepository<Bank> Banks { get; }
        IContactRepository<Contact> Contacts { get; }
        ICurrencyRepository<Currency> Currencies { get; }
        ICountryRepository<Country> Countries { get; }
        Task<int> CompleteAsync();

        //Repository.Query("SELECT @ FROM PARTNER");
    }
}
