using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.TileWidgets;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class TileWidgetRepository : ITileWidgetRepository
    {
        private readonly ApplicationDbContext _context;

        public TileWidgetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TileWidget>> GetUserWidgetsByUserGuidAsync(string userGuid)
        {
            return await _context.TileWidgets.Where(w => w.UserId == userGuid)
                .Include(w => w.Bookmark)
                .ToListAsync();
        }

        public async Task<IEnumerable<WidgetBookmark>> GetUserBookmarksByUserGuidAsync(string userGuid)
        {
            return await _context.TileWidgetBookmarks.Where(wb => wb.UserId == userGuid)
                .ToListAsync();
        }
    }
}
