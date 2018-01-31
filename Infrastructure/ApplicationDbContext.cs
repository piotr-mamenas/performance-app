using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Domain.Contacts;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.ExchangeRates;
using Core.Domain.Identity;
using Core.Domain.Institutions;
using Core.Domain.Messages;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Core.Domain.Reports;
using Core.Domain.Returns;
using Core.Domain.Tasks;
using Core.Domain.Workflows;
using Infrastructure.ComplexTypesConfigurations;
using Infrastructure.EntityConfigurations.BusinessConfigurations.AccountConfiguration;
using Infrastructure.EntityConfigurations.BusinessConfigurations.AssetConfigurations;
using Infrastructure.EntityConfigurations.BusinessConfigurations.ContactConfigurations;
using Infrastructure.EntityConfigurations.BusinessConfigurations.CountryConfigurations;
using Infrastructure.EntityConfigurations.BusinessConfigurations.CurrencyConfigurations;
using Infrastructure.EntityConfigurations.BusinessConfigurations.ExchangeRateConfiguration;
using Infrastructure.EntityConfigurations.BusinessConfigurations.InstitutionConfigurations;
using Infrastructure.EntityConfigurations.BusinessConfigurations.PartnerConfigurations;
using Infrastructure.EntityConfigurations.BusinessConfigurations.PortfolioConfigurations;
using Infrastructure.EntityConfigurations.BusinessConfigurations.ReportConfigurations;
using Infrastructure.EntityConfigurations.BusinessConfigurations.ReturnConfigurations;
using Infrastructure.EntityConfigurations.SystemConfigurations.IdentityConfigurations;
using Infrastructure.EntityConfigurations.SystemConfigurations.MessageConfigurations;
using Infrastructure.EntityConfigurations.SystemConfigurations.TaskConfigurations;
using Infrastructure.EntityConfigurations.SystemConfigurations.WorkflowConfigurations;
using Infrastructure.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, UserLogin, UserRole, UserClaim>
    {
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetClass> AssetClasses { get; set; }
        public DbSet<AssetPrice> AssetPrices { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerType> PartnerTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PortfolioAssetPosition> Positions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<ServerTask> Tasks { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Workflow> Worksflows { get; set; }
        public DbSet<WorkflowStatus> WorkflowStatuses { get; set; }
        public DbSet<WorkflowTransition> WorkflowTransitions { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<ReturnIncome> ReturnIncomes { get; set; }
        public DbSet<ReturnCalculationPeriod> ReturnCalculationPeriods { get; set; }

        public ApplicationDbContext()
            : base("PerformanceApp")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new InstitutionConfiguration());
            modelBuilder.Configurations.Add(new BankConfiguration());
            
            modelBuilder.Configurations.Add(new AccountConfiguration());

            modelBuilder.Configurations.Add(new AssetConfiguration());
            modelBuilder.Configurations.Add(new BondCouponConfiguration());
            modelBuilder.Configurations.Add(new BondConfiguration());
            modelBuilder.Configurations.Add(new AssetPriceConfiguration());
            modelBuilder.Configurations.Add(new AssetClassConfiguration());

            modelBuilder.Configurations.Add(new PartnerConfiguration());
            modelBuilder.Configurations.Add(new PartnerTypeConfiguration());

            modelBuilder.Configurations.Add(new ContactConfiguration());

            modelBuilder.Configurations.Add(new CountryConfiguration());

            modelBuilder.Configurations.Add(new CurrencyConfiguration());

            modelBuilder.Configurations.Add(new PortfolioAssetPositionConfiguration());

            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserClaimConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserLoginConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());

            modelBuilder.Configurations.Add(new MessageConfiguration());

            modelBuilder.Configurations.Add(new PortfolioConfiguration());

            modelBuilder.Configurations.Add(new ExchangeRateConfiguration());

            modelBuilder.Configurations.Add(new ServerTaskConfiguration());
            modelBuilder.Configurations.Add(new ExportTaskConfiguration());
            modelBuilder.Configurations.Add(new ImportTaskConfiguration());
            modelBuilder.Configurations.Add(new TaskRunConfiguration());
            modelBuilder.Configurations.Add(new TaskTypeConfiguration());

            modelBuilder.Configurations.Add(new WorkflowStatusConfiguration());
            modelBuilder.Configurations.Add(new WorkflowConfiguration());
            modelBuilder.Configurations.Add(new WorkflowTransitionConfiguration());

            modelBuilder.Configurations.Add(new ReportConfiguration());

            modelBuilder.Configurations.Add(new ReturnConfiguration());
            modelBuilder.Configurations.Add(new HoldingPeriodReturnConfiguration());
            modelBuilder.Configurations.Add(new ReturnIncomeConfiguration());
            modelBuilder.Configurations.Add(new ReturnCalculationPeriodConfiguration());
        }

        /// <summary>
        /// Catching additional validation errors for migration debugging purposes
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEntityValidationException)
            {
                throw ExceptionHelper.CreateFromEntityValidation(dbEntityValidationException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw ExceptionHelper.CreateFromDbUpdateException(dbUpdateException);
            }
        }

        /// <summary>
        /// Same as above but with Async support
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbEntityValidationException dbEntityValidationException)
            {
                throw ExceptionHelper.CreateFromEntityValidation(dbEntityValidationException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw ExceptionHelper.CreateFromDbUpdateException(dbUpdateException);
            }
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
