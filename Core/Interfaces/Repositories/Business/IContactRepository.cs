using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Contacts;

namespace Core.Interfaces.Repositories.Business
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsWithPartnersAsync();
    }
}