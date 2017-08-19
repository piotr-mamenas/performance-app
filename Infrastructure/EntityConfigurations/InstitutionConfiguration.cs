using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Institution;

namespace Infrastructure.EntityConfigurations
{
    public class InstitutionConfiguration : EntityTypeConfiguration<BaseInstitution>
    {
        public InstitutionConfiguration()
        {
            HasKey(o => o.Id);

            ToTable("tbl_Institution");

            Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("InstitutionId");

            Property(o => o.Name)
                .IsRequired()
                .HasColumnName("InstitutionName")
                .HasMaxLength(255);

            Map<Bank>(o => o.Requires("InstitutionType").HasValue(1));
        }
    }
}
