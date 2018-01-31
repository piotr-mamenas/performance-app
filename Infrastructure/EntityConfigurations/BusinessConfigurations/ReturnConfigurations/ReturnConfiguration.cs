using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Returns;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.ReturnConfigurations
{
    public class ReturnConfiguration : BaseEntityConfiguration<Return>
    {
        public ReturnConfiguration()
        {
            ToTable("InvestmentReturn");

            Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ReturnId");

            HasRequired(r => r.Asset)
                .WithMany(a => a.Returns)
                .HasForeignKey(r => r.AssetId);

            Property(r => r.Rate)
                .HasColumnName("ReturnRate")
                .HasPrecision(9, 2)
                .IsRequired();

            HasMany(r => r.Incomes)
                .WithRequired(ri => ri.Return)
                .HasForeignKey(ri => ri.ReturnId);

            HasMany(r => r.Periods)
                .WithRequired(p => p.Return)
                .HasForeignKey(p => p.ReturnId);

            Property(r => r.CalculatedTime)
                .HasColumnName("ReturnTimestamp")
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            Map<HoldingPeriodReturn>(r => r.Requires("ReturnType").HasValue((int)ReturnType.HoldingPeriodReturn));
        }
    }
}
