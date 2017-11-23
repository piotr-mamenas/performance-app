using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Assets;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.AssetConfigurations
{
    public class AssetConfiguration : BaseEntityConfiguration<Asset>
    {
        public AssetConfiguration()
        {
            ToTable("Asset");

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("AssetId");

            Property(a => a.Name)
                .HasColumnName("AssetName")
                .IsRequired();

            Property(a => a.Isin)
                .HasColumnName("AssetISIN");

            HasRequired(a => a.Class)
                .WithMany();

            HasMany(a => a.Prices)
                .WithRequired(p => p.Asset)
                .HasForeignKey(p => p.AssetId);

            Map<Bond>(a => a.Requires("AssetType").HasValue((int)AssetType.Bond));
            Map<Equity>(a => a.Requires("AssetType").HasValue((int)AssetType.Equity));
        }
    }
}
