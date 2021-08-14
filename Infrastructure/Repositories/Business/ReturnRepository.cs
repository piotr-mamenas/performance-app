using System.Linq;
using Core.Domain.Returns;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ReturnRepository : IReturnRepository
    {
        private readonly ApplicationDbContext _context;

        public ReturnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public decimal GetLastHoldingPeriodReturnRate(int assetId)
        {
            return _context.Returns
                .OrderByDescending(r => r.CalculatedTime)
                .Where(r => r.AssetId == assetId)
                .Select(r => r.Rate)
                .SingleOrDefault();
        }
    }
}