namespace Core.Interfaces.Repositories.Asset
{
    public interface IAssetRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
