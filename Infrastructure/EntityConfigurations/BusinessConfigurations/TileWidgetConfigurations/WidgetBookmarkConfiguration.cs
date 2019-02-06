using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.TileWidgets;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.TileWidgetConfigurations
{
    public class WidgetBookmarkConfiguration : BaseEntityConfiguration<WidgetBookmark>
    {
        public WidgetBookmarkConfiguration()
        {
            ToTable("TileWidgetBookmark");

            Property(wb => wb.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("TileWidgetBookmarkId");

            Property(wb => wb.Url)
                .HasColumnName("Url")
                .IsRequired();

            Property(wb => wb.Name)
                .HasColumnName("BookmarkName")
                .IsRequired();

            HasMany(wb => wb.Widgets)
                .WithRequired(tw => tw.Bookmark)
                .HasForeignKey(tw => tw.BookmarkId);
        }
    }
}
