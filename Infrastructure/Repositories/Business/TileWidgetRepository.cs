using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.TileWidgets;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class TileWidgetRepository : Repository<TileWidget>, ITileWidgetRepository
    {
        private readonly DbSet<TileWidget> _widgets;

        public TileWidgetRepository(ApplicationDbContext context)
            : base(context)
        {
            _widgets = context.TileWidgets;
        }

        public async Task<IEnumerable<TileWidget>> GetUserWidgets(string userGuid)
        {
            return await _widgets.Where(w => w.UserId == userGuid).ToListAsync();
        }
    }
}
