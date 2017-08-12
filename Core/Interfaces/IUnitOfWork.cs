using System;
using Core.Interfaces.Repositories;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAssetManagerRepository AssetManagers { get; }
        IBankRepository Banks { get; }
        int Complete();
    }
}
