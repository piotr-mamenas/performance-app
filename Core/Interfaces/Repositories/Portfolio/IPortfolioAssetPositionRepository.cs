namespace Core.Interfaces.Repositories.Portfolio
{
    public interface IPortfolioAssetPositionRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}