using System;
using System.Threading.Tasks;
using Core.Interfaces.Repositories.BaseData;
using Core.Interfaces.Repositories.Business;
using Core.Interfaces.Repositories.System;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();
    }
}
