using System.Collections.Generic;
using Core.Domain.Identity;

namespace Core.Domain.TileWidgets
{
    public class WidgetBookmark : BaseEntity
    {
        public string Url { get; set; }

        public string Name { get; set; }

        public ICollection<TileWidget> Widgets { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        protected WidgetBookmark()
        {
            Widgets = new List<TileWidget>();
        }
    }
}
