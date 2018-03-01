using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.TileWidgets;

namespace Core.Interfaces.Repositories.Business
{
    public interface ITileWidgetRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : TileWidget
    {
        Task<IEnumerable<TileWidget>> GetUserWidgets(string userGuid);
    }
}