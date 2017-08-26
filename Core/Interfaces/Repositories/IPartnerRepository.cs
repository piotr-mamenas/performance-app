using Core.Domain;

namespace Core.Interfaces.Repositories
{
    public interface IPartnerRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
