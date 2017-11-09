using Core.Domain.Assets;

namespace Infrastructure.EntityConfigurations.AssetConfigurations
{
    public class AssetPriceConfiguration : BaseEntityConfiguration<AssetPrice>
    {
        public AssetPriceConfiguration()
        {
            ToTable("AssetPrice");

            Property(ap => ap.Timestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            HasRequired(ap => ap.Asset)
                .WithMany(a => a.Prices)
                .WillCascadeOnDelete(false);
        }
    }
}
