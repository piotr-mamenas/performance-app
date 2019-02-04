using Core.Domain.Identity;
using Core.Interfaces;

namespace Core.Domain.TileWidgets
{
    public class TileWidget : BaseEntity, IEntityRoot
    {
        public User User { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public FontAwesomeIcon Icon { get; set; }

        public WidgetBookmark Bookmark { get; set; }
        public int BookmarkId { get; set; }

        protected TileWidget()
        {
            Icon = FontAwesomeIcon.Build(FontAwesomeIcon.StickyNote);
        }

        public static TileWidget Build(string userId, string name, string iconName, int bookmarkId)
        {
            return new TileWidget
            {
                UserId = userId,
                Name = name,
                Icon = FontAwesomeIcon.Build(iconName),
                BookmarkId = bookmarkId
            };
        }
    }
}
