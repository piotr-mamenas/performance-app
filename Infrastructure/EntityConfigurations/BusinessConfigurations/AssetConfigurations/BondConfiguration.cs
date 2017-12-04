using Core.Domain.Assets;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.AssetConfigurations
{
    public class BondConfiguration : BaseEntityConfiguration<Bond>
    {
        public BondConfiguration()
        {
            Property(b => b.IssueDate)
                .HasColumnName("BondIssueDate")
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            Property(b => b.MaturityDate)
                .HasColumnName("BondMaturityDate")
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            Property(b => b.Coupon.Rate);

            Property(b => b.Coupon.Amount);

            HasRequired(b => b.Currency)
                .WithMany(c => c.Bonds)
                .HasForeignKey(b => b.CurrencyId);

            Property(b => b.FaceValue)
                .HasColumnName("BondFaceValue")
                .IsRequired();
        }
    }
}
