using Core.Interfaces.Repositories.Task;

namespace Infrastructure.Repositories.System.Task
{
    public class TaskRunRepository<TSpecificEntity> : Repository<TSpecificEntity>, ITaskRunRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
        public TaskRunRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
