using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Identity;
using Core.Enums;
using Infrastructure.Identity;

namespace Infrastructure.Seed.IdentityData
{
    public static class StaticIdentitySeeder
    {
        public static async Task SeedIdentityAsync(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new ApplicationUserStore(context));
            var roleManager = new ApplicationRoleManager(new ApplicationRoleStore(context));

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role { Name = Role.AdminRole, Id = Guid.NewGuid().ToString() });
                await roleManager.CreateAsync(new Role { Name = Role.AssociateRole, Id = Guid.NewGuid().ToString() });
            }

            if (!userManager.Users.Any(u => u.UserName == "polskiAdmin"))
            {
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Language = Language.Pl,
                    UserName = "polskiAdmin",
                    Email = "demoPL@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+41790799495",
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

            if (!userManager.Users.Any(u => u.UserName == "amerykanskiUser"))
            {
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Language = Language.En,
                    UserName = "amerykanskiUser",
                    Email = "demoEN@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+41780349604",
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(user, "Secret1#");
                await userManager.AddToRoleAsync(user.Id, Role.AssociateRole);
            }
        }
    }
}
