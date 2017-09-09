using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Institutions;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.InstitutionConfigurations
{
    public class InstitutionConfiguration : EntityTypeConfiguration<Institution>
    {
        public InstitutionConfiguration()
        {
            Property(c => c.IsDeleted).HasColumnName("IsDeleted");

            HasKey(o => o.Id);

            ToTable("Institution");

            Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("InstitutionId");

            Property(o => o.Name)
                .IsRequired()
                .HasColumnName("InstitutionName")
                .HasMaxLength(255);

            Map<Bank>(o => o.Requires("InstitutionType").HasValue((int)InstitutionType.Bank));
        }
    }
}
