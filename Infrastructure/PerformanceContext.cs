﻿using System.Data.Entity;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Domain.Contacts;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.Identity;
using Core.Domain.Institutions;
using Core.Domain.Partners;
using Core.Domain.Positions;
using Infrastructure.ComplexTypesConfigurations;
using Infrastructure.EntityConfigurations.AccountConfiguration;
using Infrastructure.EntityConfigurations.AssetConfigurations;
using Infrastructure.EntityConfigurations.ContactConfigurations;
using Infrastructure.EntityConfigurations.CountryConfigurations;
using Infrastructure.EntityConfigurations.CurrencyConfigurations;
using Infrastructure.EntityConfigurations.IdentityConfigurations;
using Infrastructure.EntityConfigurations.InstitutionConfigurations;
using Infrastructure.EntityConfigurations.PartnerConfigurations;
using Infrastructure.EntityConfigurations.PositionConfigurations;

namespace Infrastructure
{
    public class PerformanceContext : ApplicationDbContext
    {
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Position> Positions { get; set; }

        public PerformanceContext()
            : base("PerformanceApp")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InstitutionConfiguration());
            modelBuilder.Configurations.Add(new BankConfiguration());
            
            modelBuilder.Configurations.Add(new AccountConfiguration());

            modelBuilder.Configurations.Add(new AssetConfiguration());
            modelBuilder.Configurations.Add(new BondCouponConfiguration());
            modelBuilder.Configurations.Add(new BondConfiguration());

            modelBuilder.Configurations.Add(new PartnerConfiguration());
            modelBuilder.Configurations.Add(new AssetManagerConfiguration());

            modelBuilder.Configurations.Add(new ContactConfiguration());

            modelBuilder.Configurations.Add(new CountryConfiguration());

            modelBuilder.Configurations.Add(new CurrencyConfiguration());

            modelBuilder.Configurations.Add(new PositionConfiguration());

            modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserClaimConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserLoginConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserRoleConfiguration());
        }


    }
}
