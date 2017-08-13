using System.Data.Entity.ModelConfiguration;
using Core.Domain.Organization;

namespace DAL.EntityConfigurations
{
    public class OrganizationConfiguration : EntityTypeConfiguration<BaseOrganization>
    {
        public OrganizationConfiguration()
        {
            HasKey(o => o.Id);

            ToTable("tbl_Organization");

            Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(255);

            Map<Bank>(o => o.Requires("OrganizationType").HasValue(1));
        }
    }
}
