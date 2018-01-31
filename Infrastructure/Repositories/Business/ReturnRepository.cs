using System.Linq;
using Core.Domain.Returns;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ReturnRepository<TSpecificEntity> : Repository<TSpecificEntity>, IReturnRepository<TSpecificEntity> where TSpecificEntity : Return
    {
        public ReturnRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public decimal GetLastHoldingPeriodReturnRate(int assetId)
        {
            return Context.Returns
                .OrderByDescending(r => r.CalculatedTime)
                .Where(r => r.AssetId == assetId)
                .Select(r => r.Rate)
                .SingleOrDefault();
        }
    }
}