namespace Core.Interfaces.Repositories.Account
{
    public interface IAccountRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
