namespace Core.Interfaces.Repositories.Asset
{
    public interface IAssetPriceRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
        
    }
}