namespace Core.Interfaces.Repositories.Task
{
    public interface ITaskRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}