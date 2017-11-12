namespace Core.Interfaces.Repositories.Business
{
    public interface IAccountRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
    }
}
