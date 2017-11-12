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

            HasMany(p => p.Institutions)
                .WithMany(o => o.Partners)
                .Map(m => m.ToTable("PartnerInstitutions")
                .MapLeftKey("PartnerId")
                .MapRightKey("InstitutionId"));

            HasMany(p => p.Contacts)
                .WithRequired(c => c.Partner)
                .HasForeignKey(c => c.PartnerId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.Accounts)
                .WithMany(a => a.Partners)
                .Map(m => m.ToTable("PartnerAccounts")
                .MapLeftKey("PartnerId")
                .MapRightKey("AccountId"));

            Map<AssetManager>(p => p.Requires("PartnerType").HasValue((int)PartnerType.AssetManager));
        }
    }
}
