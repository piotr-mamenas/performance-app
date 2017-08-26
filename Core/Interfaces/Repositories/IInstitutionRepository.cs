using Core.Domain.Institutions;

namespace Core.Interfaces.Repositories
{
    public interface IInstitutionRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
