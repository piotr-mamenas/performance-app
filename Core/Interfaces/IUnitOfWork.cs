using System;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPartnerRepository Partners { get; }
        IInstitutionRepository Institutions { get; }
        IContactRepository Contacts { get; }
        ICurrencyRepository Currencies { get; }
        ICountryRepository Countries { get; }
        Task<int> CompleteAsync();
    }
}
