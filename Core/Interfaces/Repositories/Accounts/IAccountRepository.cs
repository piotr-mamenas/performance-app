namespace Core.Interfaces.Repositories.Accounts
{
    public interface IAccountRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
