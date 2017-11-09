namespace Core.Interfaces.Repositories.BaseData
{
    public interface ICountryRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
