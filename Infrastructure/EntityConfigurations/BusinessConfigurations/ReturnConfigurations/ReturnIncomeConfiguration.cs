using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Returns;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.ReturnConfigurations
{
    public class ReturnIncomeConfiguration : BaseEntityConfiguration<ReturnIncome>
    {
        public ReturnIncomeConfiguration()
        {
            ToTable("InvestmentReturnIncome");

            Property(ri => ri.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ReturnIncomeId");

            Property(ri => ri.Amount)
                .HasColumnName("IncomeAmount")
                .HasPrecision(9, 2)
                .IsRequired();

            HasRequired(ri => ri.Return)
                .WithMany(r => r.Incomes)
                .HasForeignKey(ri => ri.ReturnId);

            Property(ri => ri.Timestamp)
                .HasColumnName("ReturnIncomeTimestamp")
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();
        }
    }
}
