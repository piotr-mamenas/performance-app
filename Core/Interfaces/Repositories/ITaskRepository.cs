namespace Core.Interfaces.Repositories
{
    public interface ITaskRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}