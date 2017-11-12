namespace Core.Interfaces.Repositories.Business
{
    public interface IPartnerRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
    }
}
