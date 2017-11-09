using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.BaseData.Currencies;

namespace Infrastructure.EntityConfigurations.BaseDataConfigurations
{
    public class CurrencyConfiguration : BaseEntityConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
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

            HasMany(c => c.Countries)
                .WithRequired(c => c.Currency)
                .HasForeignKey(c => c.CurrencyId)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Positions)
                .WithRequired(pa => pa.Currency)
                .HasForeignKey(pa => pa.CurrencyId)
                .WillCascadeOnDelete(false);
        }
    }
}
