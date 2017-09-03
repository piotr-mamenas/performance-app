using System.Data.Entity.ModelConfiguration;
using Core.Domain.Assets;

namespace Infrastructure.ComplexTypesConfigurations
{
    public class BondCouponConfiguration : ComplexTypeConfiguration<BondCoupon>
    {
        public BondCouponConfiguration()
        {
            Property(b => b.Rate)
                .IsRequired()
                .HasColumnName("BondCouponRate");

            Property(b => b.Amount)
                .IsRequired()
                .HasColumnName("BondCouponAmount");
        }
    }
}
