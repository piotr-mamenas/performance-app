using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Partners;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.PartnerConfigurations
{
    public class PartnerTypeConfiguration : BaseEntityConfiguration<PartnerType>
    {
        public PartnerTypeConfiguration()
        {
            ToTable("PartnerType");

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("PartnerTypeId");

            Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnName("PartnerTypeName");
        }
    }
}
