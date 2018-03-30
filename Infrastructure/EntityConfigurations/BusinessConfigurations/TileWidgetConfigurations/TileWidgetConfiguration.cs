using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.TileWidgets;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.TileWidgetConfigurations
{
    public class TileWidgetConfiguration : BaseEntityConfiguration<TileWidget>
    {
        public TileWidgetConfiguration()
        {
            ToTable("TileWidgets");

            Property(tw => tw.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("TileWidgetId");

            Property(tw => tw.Name)
                .HasColumnName("TileName")
                .IsRequired();

            Property(tw => tw.Url)
                .HasColumnName("LinkUrl")
                .IsOptional();

            Property(tw => tw.Icon.Name);

            HasRequired(tw => tw.User)
                .WithMany(u => u.TileWidgets)
                .HasForeignKey(tw => tw.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
