using System.Data.Entity;
using Core.Domain.Contact;
using Core.Domain.Country;
using Core.Domain.Currency;
using Core.Domain.Identity;
using Core.Domain.Institution;
using Core.Domain.Partner;
using Infrastructure.EntityConfigurations;
using Infrastructure.EntityConfigurations.IdentityConfigurations;

namespace Infrastructure
{
    public class PerformanceContext : ApplicationDbContext
    {
        public DbSet<BaseInstitution> Institutions { get; set; }
        public DbSet<BasePartner> Partners { get; set; }
        public DbSet<BaseContact> Contacts { get; set; }
        public DbSet<BaseCurrency> Currencies { get; set; }
        public DbSet<BaseCountry> Countries { get; set; }

        // TODO: Implement simple initialization to base later, for now we want defaultconnection
        public PerformanceContext()
            : base("PerformanceApp")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InstitutionConfiguration());
            modelBuilder.Configurations.Add(new PartnerConfiguration());
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new CurrencyConfiguration());

            modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserClaimConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserLoginConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserRoleConfiguration());
        }
    }
}
