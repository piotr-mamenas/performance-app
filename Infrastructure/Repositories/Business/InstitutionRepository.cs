using Core.Interfaces;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class InstitutionRepository<TSpecificEntity> : Repository<TSpecificEntity>, IInstitutionRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
        public InstitutionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
