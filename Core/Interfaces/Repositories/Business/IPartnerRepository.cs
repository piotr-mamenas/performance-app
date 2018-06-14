using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Partners;

namespace Core.Interfaces.Repositories.Business
{
    public interface IPartnerRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Partner
    {
        IQueryable<PartnerType> GetTypesAsQueryable();
        Task<IEnumerable<Partner>> GetAllPartnersAsync();
        Task<IEnumerable<Partner>> GetAllPartnersWithTypesAsync();
        Task<IEnumerable<Partner>> GetAccountPartnersAsync(int accountId);
        Task<Partner> GetByIdWithAccountsAndContactsAsync(int id);
    }
}
