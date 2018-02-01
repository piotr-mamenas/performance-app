using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Assets;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.AssetConfigurations
{
    public class AssetPriceConfiguration : BaseEntityConfiguration<AssetPrice>
    {
        public AssetPriceConfiguration()
        {
            ToTable("AssetPrice");

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("AssetPriceId");

            Property(ap => ap.Timestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            HasRequired(ap => ap.Asset)
                .WithMany(a => a.Prices);
        }
    }
}
