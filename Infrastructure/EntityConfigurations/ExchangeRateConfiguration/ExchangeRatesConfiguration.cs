using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.BaseData.Currencies;
using Core.Domain.ExchangeRates;

namespace Infrastructure.EntityConfigurations.ExchangeRateConfiguration
{
    public class ExchangeRateConfiguration : BaseEntityConfiguration<ExchangeRate>
    {
        public ExchangeRateConfiguration()
        {
            ToTable("ExchangeRate");
            
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ExchangeRateId");

            Property(e => e.Max)
                .HasPrecision(9,2)
                .IsRequired()
                .HasColumnName("ExchangeRateMax");

            Property(e => e.Min)
                .HasPrecision(9, 2)
                .IsRequired()
                .HasColumnName("ExchangeRateMin");

            Property(e => e.Rate)
                .HasPrecision(9, 2)
                .IsRequired()
                .HasColumnName("ExchangeRateRate");

            HasRequired(c => c.BaseCurrency)
                .WithMany()
                .WillCascadeOnDelete(false);

            HasRequired(c => c.TargetCurrency)
                .WithMany()
                .WillCascadeOnDelete(false);

            Property(e => e.Timestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();
        }

    }
}
