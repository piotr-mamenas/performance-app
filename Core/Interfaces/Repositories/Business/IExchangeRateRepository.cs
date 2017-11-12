namespace Core.Interfaces.Repositories.Business
{
    public interface IExchangeRateRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot
    {
        
    }
}