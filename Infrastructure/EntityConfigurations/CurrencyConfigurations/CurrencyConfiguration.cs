using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Currencies;

namespace Infrastructure.EntityConfigurations.CurrencyConfigurations
{
    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            Property(c => c.IsDeleted).HasColumnName("IsDeleted");

            HasKey(c => c.Id);

            ToTable("Currency");

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("CurrencyId");

            Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnName("CurrencyName");

            Property(c => c.Code)
                .HasMaxLength(3)
                .HasColumnName("CurrencyCode");

            Property(c => c.IsEnabled)
                .HasColumnName("CurrencyEnabled");
        }
    }
}
