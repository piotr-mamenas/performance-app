namespace Core.Interfaces.Repositories
{
    public interface IAccountRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
