using Core.Domain.TileWidgets;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class TileWidgetRepository<TSpecificEntity> : Repository<TSpecificEntity>, ITileWidgetRepository<TSpecificEntity> where TSpecificEntity : TileWidget
    {
        public TileWidgetRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
