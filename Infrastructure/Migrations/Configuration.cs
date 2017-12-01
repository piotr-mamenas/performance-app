using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using Infrastructure.Seed.BaseData;
using Infrastructure.Seed.BaseData.MessageSeeders;
using Infrastructure.Seed.IdentityData;
using Infrastructure.Seed.TestData;

namespace Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        
        /// <summary>
        /// Temporarily implementing it with hardcoded seeders, I will expand it later with reflection once Integration Tests are needed
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ApplicationDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            var partnerTypeSeeder = new PartnerTypeSeeder(context.PartnerTypes);
            partnerTypeSeeder.Seed();

            var partnerSeeder = new PartnerSeeder(context.Partners);
            partnerSeeder.Seed();

            var contactSeeder = new ContactSeeder(context.Contacts);
            contactSeeder.Seed();

            var accountSeeder = new AccountSeeder(context.Accounts);
            accountSeeder.Seed();
            
            var currencySeeder = new CurrencySeeder(context.Currencies);
            currencySeeder.Seed();

            context.SaveChanges();

            var countrySeeder = new CountrySeeder(context.Countries);
            countrySeeder.Seed();

            var institutionSeeder = new InstitutionSeeder(context.Institutions);
            institutionSeeder.Seed();

            var assetClassSeeder = new AssetClassSeeder(context.AssetClasses);
            assetClassSeeder.Seed();

            var assetSeeder = new AssetSeeder(context.Assets);
            assetSeeder.Seed();

            var assetPrice = new AssetPriceSeeder(context.AssetPrices);
            assetPrice.Seed();

            var portfolioSeeder = new PortfolioSeeder(context.Portfolios);
            portfolioSeeder.Seed();

            MessageSeedingRunner.Run(context.Messages);

            Task.Run(async () => { await StaticIdentitySeeder.SeedIdentityAsync(context); }).Wait();
            context.SaveChanges();
        }
    }
}
