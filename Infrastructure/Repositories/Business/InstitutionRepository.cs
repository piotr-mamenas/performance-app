using Core.Domain.Institutions;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class InstitutionRepository<TSpecificEntity> : Repository<TSpecificEntity>, IInstitutionRepository<TSpecificEntity> where TSpecificEntity : Institution
    {
        public InstitutionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
