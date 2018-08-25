using System.Data.Entity.ModelConfiguration;
using Core.Domain.Identity;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.IdentityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Map(u =>
            {
                u.ToTable("Users");
                u.Property(p => p.Id).HasColumnName("UserId");
                u.Properties(p => new
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
                    p.UserName,
                    p.SecurityStamp,
                    p.TwoFactorEnabled
                });
            }).HasKey(u => u.Id);

            HasMany(u => u.Logins)
                .WithOptional()
                .HasForeignKey(u => u.UserId);

            HasMany(u => u.Claims)
                .WithOptional()
                .HasForeignKey(c => c.UserId);

            HasMany(u => u.Roles)
                .WithRequired()
                .HasForeignKey(c => c.UserId);

            HasMany(u => u.Sessions)
                .WithRequired(us => us.User)
                .HasForeignKey(us => us.UserId);

            HasMany(u => u.TileWidgets)
                .WithRequired(tw => tw.User)
                .HasForeignKey(tw => tw.UserId);
        }

    }
}
