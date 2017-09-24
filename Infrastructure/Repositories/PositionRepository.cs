using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class PositionRepository<TSpecificEntity> : Repository<TSpecificEntity>, IPositionRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public PositionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
