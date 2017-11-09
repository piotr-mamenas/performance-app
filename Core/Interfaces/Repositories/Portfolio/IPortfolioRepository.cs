namespace Core.Interfaces.Repositories.Portfolio
{
    public interface IPortfolioRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}