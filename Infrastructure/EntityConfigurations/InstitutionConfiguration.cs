using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Institution;
using Core.Enums;
using Core.Enums.Domain;

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

            Property(o => o.Bic)
                .IsRequired()
                .HasColumnName("InstitutionBicCode")
                .HasMaxLength(11);

            Map<Bank>(o => o.Requires("InstitutionType").HasValue((int)InstitutionType.Bank));
        }
    }
}
