using System.Data.Entity;
using Core.Domain.Identity;
using Core.Domain.Organization;
using Core.Domain.Partner;
using DAL.EntityConfigurations;
using DAL.EntityConfigurations.IdentityConfigurations;

namespace DAL
{
    public class AppDbContext : ApplicationDbContext
    {
        public DbSet<BaseOrganization> Organizations { get; set; }
        public DbSet<BasePartner> Partners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new PartnerConfiguration());
            modelBuilder.Configurations.Add(new ContactConfiguration());

            modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserClaimConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserLoginConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserRoleConfiguration());
        }
    }
}
