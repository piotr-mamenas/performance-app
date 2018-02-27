using Core.Domain.TileWidgets;

namespace Core.Interfaces.Repositories.Business
{
    public interface ITileWidgetRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : TileWidget
    {
    }
}