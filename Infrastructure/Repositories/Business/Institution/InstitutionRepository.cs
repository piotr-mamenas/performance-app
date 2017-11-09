using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Institution;

namespace Infrastructure.Repositories.Business.Institution
{
    public class InstitutionRepository<TSpecificEntity> : Repository<TSpecificEntity>, IInstitutionRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public InstitutionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
