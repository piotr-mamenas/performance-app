using Core.Domain.Returns;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ReturnRepository<TSpecificEntity> : Repository<TSpecificEntity>, IReturnRepository<TSpecificEntity> where TSpecificEntity : Return
    {
        public ReturnRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}