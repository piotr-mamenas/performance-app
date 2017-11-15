using Core.Domain.Tasks;
using Core.Interfaces.Repositories.System;

namespace Infrastructure.Repositories.System
{
    public class TaskRepository<TSpecificEntity> : Repository<TSpecificEntity>, ITaskRepository<TSpecificEntity> where TSpecificEntity : ServerTask
    {
        public TaskRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
