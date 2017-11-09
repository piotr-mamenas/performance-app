using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Assets;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.AssetConfigurations
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

            HasMany(a => a.Positions)
                .WithRequired(p => p.Asset)
                .HasForeignKey(p => p.AssetId)
                .WillCascadeOnDelete(false);

            HasMany(a => a.Prices)
                .WithRequired(p => p.Asset)
                .HasForeignKey(p => p.AssetId)
                .WillCascadeOnDelete(false);

            Map<Bond>(a => a.Requires("AssetClass").HasValue((int)AssetClass.Bond));
            Map<Equity>(a => a.Requires("AssetClass").HasValue((int)AssetClass.Equity));
        }
    }
}
