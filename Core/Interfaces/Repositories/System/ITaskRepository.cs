using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Tasks;

namespace Core.Interfaces.Repositories.System
{
    public interface ITaskRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : ServerTask
    {
        Task<IEnumerable<TaskRun>> GetAllTaskRunsAsync();
    }
}