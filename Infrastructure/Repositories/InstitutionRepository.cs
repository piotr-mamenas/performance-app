using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class InstitutionRepository<TSpecificEntity> : Repository<TSpecificEntity>, IInstitutionRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public InstitutionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
