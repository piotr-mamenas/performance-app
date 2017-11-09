namespace Core.Interfaces.Repositories.BaseData
{
    public interface ICurrencyRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
