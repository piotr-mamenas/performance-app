namespace Core.Interfaces.Repositories
{
    public interface IContactRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
