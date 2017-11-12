namespace Core.Interfaces.Repositories.Business
{
    public interface IContactRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
    }
}