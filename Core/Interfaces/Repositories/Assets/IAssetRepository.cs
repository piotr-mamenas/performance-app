namespace Core.Interfaces.Repositories.Assets
{
    public interface IAssetRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
