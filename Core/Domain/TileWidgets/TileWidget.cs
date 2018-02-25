using Core.Domain.Identity;
using Core.Interfaces;

namespace Core.Domain.TileWidgets
{
    public class TileWidget : BaseEntity, IEntityRoot
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public string Icon { get; set; }
        public string Url { get; set; }

        public TileWidget()
        {
            Icon = "fa fa-sticky-note";
        }
    }
}
