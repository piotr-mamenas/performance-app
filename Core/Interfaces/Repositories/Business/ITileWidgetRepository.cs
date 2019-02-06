using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.TileWidgets;

namespace Core.Interfaces.Repositories.Business
{
    public interface ITileWidgetRepository : IRepository<TileWidget>
    {
        Task<IEnumerable<TileWidget>> GetUserWidgetsByUserGuidAsync(string userGuid);
        Task<IEnumerable<WidgetBookmark>> GetUserBookmarksByUserGuidAsync(string userGuid);
    }
}