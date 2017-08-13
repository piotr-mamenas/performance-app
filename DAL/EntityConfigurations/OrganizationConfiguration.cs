using System.ComponentModel.DataAnnotations.Schema;
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

            Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("OrganizationId");

            Property(o => o.Name)
                .IsRequired()
                .HasColumnName("OrganizationName")
                .HasMaxLength(255);

            Map<Bank>(o => o.Requires("OrganizationType").HasValue(1));
        }
    }
}
