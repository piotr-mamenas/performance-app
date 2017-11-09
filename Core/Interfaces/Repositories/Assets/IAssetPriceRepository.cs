namespace Core.Interfaces.Repositories.Assets
{
    public interface IAssetPriceRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
        
    }
}