namespace Core.Interfaces.Repositories
{
    public interface ICurrencyRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
