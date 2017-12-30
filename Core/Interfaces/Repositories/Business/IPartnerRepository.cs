using System.Linq;
using Core.Domain.Partners;

namespace Core.Interfaces.Repositories.Business
{
    public interface IPartnerRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Partner
    {
        IQueryable<PartnerType> GetTypesAsQueryable();
    }
}
