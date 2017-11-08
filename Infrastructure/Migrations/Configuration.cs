using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Domain.Contacts;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.Identity;
using Core.Domain.Institutions;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Infrastructure.Identity;
using Infrastructure.SeedData;
using Infrastructure.SeedData.Test;

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

            Task.Run(async () => { await SeedIdentityAsync(context); }).Wait();
            context.SaveChanges();
        }

        private static async Task SeedIdentityAsync(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new ApplicationUserStore(context));
            var roleManager = new ApplicationRoleManager(new ApplicationRoleStore(context));

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role { Name = Role.AdminRole, Id = Guid.NewGuid().ToString()});
                await roleManager.CreateAsync(new Role { Name = Role.AssociateRole, Id = Guid.NewGuid().ToString() });
            }

            if (!userManager.Users.Any(u => u.UserName == "DemoAdmin"))
            {
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "DemoAdmin",
                    Email = "demoadmin@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+41790799495",
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(user, "Secret1#");
                await userManager.AddToRoleAsync(user.Id, Role.AdminRole);
                await userManager.AddToRoleAsync(user.Id, Role.AssociateRole);
            }

            if (!userManager.Users.Any(u => u.UserName == "DemoUser"))
            {
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "DemoUser",
                    Email = "demouser@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+41780349204",
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(user, "Secret1#");
                await userManager.AddToRoleAsync(user.Id, Role.AssociateRole);
            }
        }
    }
}
