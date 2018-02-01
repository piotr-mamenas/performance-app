using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Identity;
using Core.Enums;
using Infrastructure.Identity;
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
            var sqlFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory+"\\Seed", "*.sql");

            var initSqlFile = File.ReadAllText(sqlFiles.SingleOrDefault(s => s.Contains("00")));
            var endSqlFile = File.ReadAllText(sqlFiles.SingleOrDefault(s => s.Contains("01")));

            context.Database.ExecuteSqlCommand(initSqlFile);

            sqlFiles.Where(s => !s.Contains("00") && !s.Contains("01"))
                .ToList()
                .ForEach(x => context.Database.ExecuteSqlCommand(File.ReadAllText(x)));

            context.Database.ExecuteSqlCommand(endSqlFile);

            Task.Run(async () => { await SeedIdentityAsync(context); }).Wait();
            context.SaveChanges();
        }

        /// <summary>
        /// As additional Identity Framework logic needs to be executed, this seed is separate from
        /// the original data seed
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task SeedIdentityAsync(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new ApplicationUserStore(context));
            var roleManager = new ApplicationRoleManager(new ApplicationRoleStore(context));

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role { Name = Role.AdminRole, Id = Guid.NewGuid().ToString() });
                await roleManager.CreateAsync(new Role { Name = Role.AssociateRole, Id = Guid.NewGuid().ToString() });
            }

            if (!userManager.Users.Any(u => u.UserName == "DemoUser"))
            {
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Language = Language.En,
                    UserName = "DemoUser",
                    Email = "demoUser@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+41790788495",
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(user, "Secret1#");
                await userManager.AddToRoleAsync(user.Id, Role.AdminRole);
                await userManager.AddToRoleAsync(user.Id, Role.AssociateRole);
            }

            if (!userManager.Users.Any(u => u.UserName == "niemieckiUser"))
            {
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Language = Language.De,
                    UserName = "niemieckiUser",
                    Email = "demoDE@gmail.com",
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
