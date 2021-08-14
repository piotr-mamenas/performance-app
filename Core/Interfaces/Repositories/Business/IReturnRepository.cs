using Core.Domain.Returns;

namespace Core.Interfaces.Repositories.Business
{
    public interface IReturnRepository
    {
        decimal GetLastHoldingPeriodReturnRate(int assetId);
    }
}