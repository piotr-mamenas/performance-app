using System.Data.Entity.ModelConfiguration;
using Core.Domain.Identity;

namespace Infrastructure.EntityConfigurations.IdentityConfigurations
{
    public class UserClaimConfiguration : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimConfiguration()
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
