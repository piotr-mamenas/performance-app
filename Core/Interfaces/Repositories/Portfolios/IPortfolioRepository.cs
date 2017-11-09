namespace Core.Interfaces.Repositories.Portfolios
{
    public interface IPortfolioRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}