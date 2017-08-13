using System.Data.Entity.ModelConfiguration;
using Core.Domain.Identity;

namespace DAL.EntityConfigurations.IdentityConfigurations
{
    public class ApplicationUserClaimConfiguration : EntityTypeConfiguration<ApplicationUserClaim>
    {
        public ApplicationUserClaimConfiguration()
        {
            Map(c =>
            {
                c.ToTable("UserClaims");
                c.Property(p => p.Id).HasColumnName("UserClaimId");
                c.Properties(p => new
                {
                    p.UserId,
                    p.ClaimValue,
                    p.ClaimType
                });
            }).HasKey(c => c.Id);
        }
    }
}
