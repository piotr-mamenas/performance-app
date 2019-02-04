using System.Collections.Generic;

namespace Core.Domain.TileWidgets
{
    public class WidgetBookmark : BaseEntity
    {
        public string Url { get; set; }

        public ICollection<TileWidget> Widgets { get; set; }

        protected WidgetBookmark()
        {
            Widgets = new List<TileWidget>();
        }
    }
}
