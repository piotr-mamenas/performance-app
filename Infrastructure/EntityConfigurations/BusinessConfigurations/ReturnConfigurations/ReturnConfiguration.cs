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

            Property(r => r.CalculatedTime)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            Map<HoldingPeriodReturn>(a => a.Requires("ReturnType").HasValue((int)ReturnType.HoldingPeriodReturn));
        }
    }
}
