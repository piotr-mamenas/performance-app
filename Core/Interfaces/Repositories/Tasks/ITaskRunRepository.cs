namespace Core.Interfaces.Repositories.Tasks
{
    public interface ITaskRunRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
        
    }
}