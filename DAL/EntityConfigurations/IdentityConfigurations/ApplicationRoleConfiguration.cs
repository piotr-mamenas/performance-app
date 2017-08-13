using System.Data.Entity.ModelConfiguration;
using Core.Domain.Identity;

namespace DAL.EntityConfigurations.IdentityConfigurations
{
    public class ApplicationRoleConfiguration : EntityTypeConfiguration<ApplicationRole>
    {
        public ApplicationRoleConfiguration()
        {
            Map(c =>
            {
                c.ToTable("tbl_Roles");
                c.Property(p => p.Id).HasColumnName("RoleId");
                c.Properties(p => new
                {
                    p.Name
                });
            }).HasKey(p => p.Id);

            HasMany(c => c.Users).WithRequired().HasForeignKey(c => c.RoleId);
        }
    }
}
