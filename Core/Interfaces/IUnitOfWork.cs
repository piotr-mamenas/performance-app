using System;
using Core.Interfaces.Repositories;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPartnerRepository Partners { get; }
        IOrganizationRepository Organizations { get; }
        int Complete();
    }
}
