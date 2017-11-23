using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Partners;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.PartnerConfigurations
{
    public class PartnerConfiguration : BaseEntityConfiguration<Partner>
    {
        public PartnerConfiguration()
        {
            ToTable("Partner");

            Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("PartnerId");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("PartnerName");

            Property(p => p.Number)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("PartnerNumber");

            HasRequired(p => p.Type)
                .WithMany()
                .HasForeignKey(p => p.PartnerTypeId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.Institutions)
                .WithMany(o => o.Partners)
                .Map(m => m.ToTable("PartnerInstitutions")
                .MapLeftKey("PartnerId")
                .MapRightKey("InstitutionId"));

            HasMany(p => p.Contacts)
                .WithRequired(c => c.Partner)
                .HasForeignKey(c => c.PartnerId);

            HasMany(p => p.Accounts)
                .WithRequired(a => a.Partner)
                .HasForeignKey(a => a.PartnerId);
        }
    }
}
