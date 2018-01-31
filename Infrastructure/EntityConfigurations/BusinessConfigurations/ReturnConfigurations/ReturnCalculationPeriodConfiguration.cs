using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Returns;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.ReturnConfigurations
{
    public class ReturnCalculationPeriodConfiguration : BaseEntityConfiguration<ReturnCalculationPeriod>
    {
        public ReturnCalculationPeriodConfiguration()
        {
            ToTable("ReturnCalculationPeriod");

            Property(rcp => rcp.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ReturnCalculationPeriodId");

            HasRequired(rcp => rcp.Return)
                .WithMany(r => r.Periods)
                .HasForeignKey(rcp => rcp.ReturnId);

            Property(rcp => rcp.DateFrom)
                .HasColumnName("TimestampFrom")
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            Property(rcp => rcp.DateTo)
                .HasColumnName("TimestampTo")
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();
        }
    }
}
