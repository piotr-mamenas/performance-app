using Core.Domain.Returns;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.ReturnConfigurations
{
    public class HoldingPeriodReturnConfiguration : BaseEntityConfiguration<HoldingPeriodReturn>
    {
        public HoldingPeriodReturnConfiguration()
        {
            Property(r => r.Rate)
                .HasColumnName("ReturnRate")
                .IsRequired();

            Property(r => r.Periodicity)
                .HasColumnName("ReturnPeriodicity")
                .IsRequired();

            HasRequired(r => r.Asset)
                .WithMany()
                .HasForeignKey(r => r.AssetId);

            HasRequired(r => r.Portfolio)
                .WithMany()
                .HasForeignKey(r => r.PortfolioId);
        }
    }
}
