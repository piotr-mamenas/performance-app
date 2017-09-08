using System.Data.Entity.ModelConfiguration;
using Core.Domain.Assets;

namespace Infrastructure.EntityConfigurations.AssetConfigurations
{
    public class BondConfiguration : EntityTypeConfiguration<Bond>
    {
        // TODO: Must figure out something with the hardcoded datetime2 for sql server, tight coupling with sqlserver
        public BondConfiguration()
        {
            Property(b => b.IssueDate)
                .HasColumnName("BondIssueDate")
                .IsRequired()
                .HasColumnType(DatabaseVendorTypes.TimestampField);

            Property(b => b.MaturityDate)
                .HasColumnName("BondMaturityDate")
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            HasRequired(b => b.Currency).WithRequiredDependent();

            Property(b => b.Coupon.Rate);

            Property(b => b.Coupon.Amount);

            Property(b => b.FaceValue)
                .HasColumnName("BondFaceValue")
                .IsRequired();
        }
    }
}
