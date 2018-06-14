using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Contacts;

namespace Core.Interfaces.Repositories.Business
{
    public interface IContactRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Contact
    {
        Task<IEnumerable<Contact>> GetAllContactsWithPartnersAsync();
    }
}