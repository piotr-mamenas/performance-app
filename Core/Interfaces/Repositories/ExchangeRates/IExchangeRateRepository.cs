namespace Core.Interfaces.Repositories.ExchangeRates
{
    public interface IExchangeRateRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        
    }
}