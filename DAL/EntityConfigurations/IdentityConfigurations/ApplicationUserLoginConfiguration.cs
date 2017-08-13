using System.Data.Entity.ModelConfiguration;
using Core.Domain.Identity;

namespace DAL.EntityConfigurations.IdentityConfigurations
{
    public class ApplicationUserLoginConfiguration : EntityTypeConfiguration<ApplicationUserLogin>
    {
        public ApplicationUserLoginConfiguration()
        {
            Map(c =>
            {
                c.ToTable("UserLogins");
                c.Properties(p => new
                {
                    p.LoginProvider,
                    p.ProviderKey,
                    p.UserId
                });
            }).HasKey(p => new
            {
                p.LoginProvider,
                p.ProviderKey,
                p.UserId
            });
        }

    }
}
