using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Infrastructure.SeedData.Identity;

namespace Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        
        protected override void Seed(ApplicationDbContext context)
        {
            //SeedAccount(context.Accounts);
            //SeedContact(context.Contacts);
            //SeedPartner(context.Partners);
            //SeedCurrency(context.Currencies);
            context.SaveChanges();
            //SeedCountry(context.Countries);
            //SeedInstitution(context.Institutions);
            //var assetSeeder = new AssetSeeder();
            //AssetSeeder.Seed(context.Assets);
            //SeedPortfolio(context.Portfolios);

            Task.Run(async () => { await StaticIdentitySeeder.SeedIdentityAsync(context); }).Wait();
            context.SaveChanges();
        }
    }
}
