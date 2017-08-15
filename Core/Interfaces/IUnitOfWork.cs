using System;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPartnerRepository Partners { get; }
        IOrganizationRepository Organizations { get; }
        Task<int> CompleteAsync();
    }
}
