namespace Core.Interfaces.Repositories.Task
{
    public interface ITaskRunRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
        
    }
}