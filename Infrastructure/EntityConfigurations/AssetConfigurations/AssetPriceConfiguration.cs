using System.Data.Entity.ModelConfiguration;
using Core.Domain.Assets;

namespace Infrastructure.EntityConfigurations.AssetConfigurations
{
    public class AssetPriceConfiguration : EntityTypeConfiguration<AssetPrice>
    {
        public AssetPriceConfiguration()
        {
            Property(p => p.IsDeleted).HasColumnName("IsDeleted");

            HasKey(p => p.Id);

            ToTable("AssetPrice");

            Property(p => p.Timestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            HasRequired(p => p.Asset)
                .WithMany(a => a.Prices)
                .WillCascadeOnDelete(false);
        }
    }
}
