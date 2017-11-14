using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Assets;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.AssetConfigurations
{
    public class AssetClassConfiguration : BaseEntityConfiguration<AssetClass>
    {
        public AssetClassConfiguration()
        {
            ToTable("AssetClass");

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("AssetClassId");

            Property(a => a.Name)
                .HasColumnName("AssetClassName")
                .IsRequired();

            Property(c => c.IsEnabled)
                .HasColumnName("AssetClassEnabled");
        }
    }
}
