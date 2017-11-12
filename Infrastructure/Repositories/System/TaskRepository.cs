using Core.Interfaces;
using Core.Interfaces.Repositories.System;

namespace Infrastructure.Repositories.System
{
    public class TaskRepository<TSpecificEntity> : Repository<TSpecificEntity>, ITaskRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public TaskRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
