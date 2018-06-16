using Core.Domain.Returns;

namespace Core.Interfaces.Repositories.Business
{
    public interface IReturnRepository : IRepository<Return>
    {
        decimal GetLastHoldingPeriodReturnRate(int assetId);
    }
}