using System.Data.Entity.ModelConfiguration;
using Core.Domain.Identity;

namespace DAL.EntityConfigurations.IdentityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Map(c =>
            {
                c.ToTable("Users");
                c.Property(p => p.Id).HasColumnName("UserId");
                c.Properties(p => new
                {
                    p.AccessFailedCount,
                    p.Email,
                    p.EmailConfirmed,
                    p.PasswordHash,
                    p.PhoneNumber,
                    p.PhoneNumberConfirmed,
                    p.TwoFactorEnabled,
                    p.SecurityStamp,
                    p.LockoutEnabled,
                    p.LockoutEndDateUtc,
                    p.UserName
                });
            }).HasKey(c => c.Id);

            HasMany(c => c.Logins).WithOptional().HasForeignKey(c => c.UserId);

            HasMany(c => c.Claims).WithOptional().HasForeignKey(c => c.UserId);

            HasMany(c => c.Roles).WithRequired().HasForeignKey(c => c.UserId);
        }

    }
}
