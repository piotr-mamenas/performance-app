namespace Core.Interfaces.Repositories.Portfolios
{
    public interface IPortfolioAssetPositionRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
    }
}