using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Assets;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.AssetConfigurations
{
    public class AssetConfiguration : EntityTypeConfiguration<Asset>
    {
        public AssetConfiguration()
        {
            Property(a => a.IsDeleted).HasColumnName("IsDeleted");

            HasKey(a => a.Id);

            ToTable("Asset");

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("AssetId");

            Property(a => a.Name)
                .HasColumnName("AssetName")
                .IsRequired();

            Property(a => a.Isin)
                .HasColumnName("AssetISIN");

            Map<Bond>(p => p.Requires("AssetClass").HasValue((int)AssetClass.Bond));
            Map<Equity>(p => p.Requires("AssetClass").HasValue((int)AssetClass.Equity));
        }
    }
}
