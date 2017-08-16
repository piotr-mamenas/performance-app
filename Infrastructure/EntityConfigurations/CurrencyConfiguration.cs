using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Currency;

namespace Infrastructure.EntityConfigurations
{
    public class CurrencyConfiguration : EntityTypeConfiguration<BaseCurrency>
    {
        public CurrencyConfiguration()
        {
            HasKey(c => c.Id);

            ToTable("tbl_Currency");

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("CurrencyId");

            Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnName("CurrencyName");

            Property(c => c.Code)
                .HasMaxLength(2)
                .HasColumnName("CurrencyCode");

            Property(c => c.IsEnabled)
                .HasColumnName("CurrencyEnabled");
        }
    }
}
