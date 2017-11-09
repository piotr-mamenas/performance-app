using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Institutions;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.InstitutionConfigurations
{
    public class InstitutionConfiguration : BaseEntityConfiguration<Institution>
    {
        public InstitutionConfiguration()
        {
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
