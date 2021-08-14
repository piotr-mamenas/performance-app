using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Institutions;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly ApplicationDbContext _context;

        public InstitutionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Institution>> GetAllInstitutionsAsync()
        {
            return await _context.Institutions.ToListAsync();
        }
    }
}
