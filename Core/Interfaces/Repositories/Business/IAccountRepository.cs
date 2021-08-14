using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Accounts;

namespace Core.Interfaces.Repositories.Business
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllWithPartnerAsync();
    }
}
