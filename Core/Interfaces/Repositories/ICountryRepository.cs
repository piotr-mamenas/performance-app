namespace Core.Interfaces.Repositories
{
    public interface ICountryRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
