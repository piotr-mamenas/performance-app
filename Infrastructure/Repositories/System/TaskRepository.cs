using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<TaskRun>> GetAllTaskRunsAsync()
        {
            var tasks = Context.Tasks
                .Include(t => t.Runs)
                .Include(t => t.Type);

            return await tasks.SelectMany(tr => tr.Runs).ToListAsync();
        }

        public async Task<IEnumerable<ServerTask>> GetAllTasksAsync()
        {
            return await Context.Tasks.ToListAsync();
        }
    }
}
