using System.Data.Entity.ModelConfiguration;
using Core.Domain.Identity;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.IdentityConfigurations
{
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            Map(c =>
                {
                    c.ToTable("UserRoles");
                    c.Properties(p => new
                    {
                        p.UserId,
                        p.RoleId
                    });
                })
                .HasKey(c => new
                {
                    c.UserId,
                    c.RoleId
                });
        }
    }
}
