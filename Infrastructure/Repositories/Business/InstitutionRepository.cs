using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Institutions;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class InstitutionRepository : Repository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Institution>> GetAllInstitutionsAsync()
        {
            return await Context.Institutions.ToListAsync();
        }
    }
}
