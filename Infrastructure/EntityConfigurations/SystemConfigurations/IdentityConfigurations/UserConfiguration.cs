using System.Data.Entity.ModelConfiguration;
using Core.Domain.Identity;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.IdentityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Map(c =>
            {
                c.ToTable("Users");
                c.Property(p => p.Id).HasColumnName("UserId");
                c.Properties(p => new
                {
                    p.Language,
                    p.AccessFailedCount,
                    p.Email,
                    p.EmailConfirmed,
                    p.PhoneNumber,
                    p.PhoneNumberConfirmed,
                    p.PasswordHash,
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
