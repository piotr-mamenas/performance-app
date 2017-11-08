using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories.System.Task
{
    public class TaskRepository<TSpecificEntity> : Repository<TSpecificEntity>, ITaskRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public TaskRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
