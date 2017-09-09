using System.Data.Entity.ModelConfiguration;
using Core.Domain.Identity;

namespace Infrastructure.EntityConfigurations.IdentityConfigurations
{
    public class ApplicationUserRoleConfiguration : EntityTypeConfiguration<ApplicationUserRole>
    {
        public ApplicationUserRoleConfiguration()
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
