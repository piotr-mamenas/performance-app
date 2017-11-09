namespace Core.Interfaces.Repositories.Tasks
{
    public interface ITaskRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}