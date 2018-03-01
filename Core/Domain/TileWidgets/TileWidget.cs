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
        public string Url { get; set; }

        public TileWidget()
        {
            Icon = new FontAwesomeIcon(FontAwesomeIcon.StickyNote);
        }
    }
}
