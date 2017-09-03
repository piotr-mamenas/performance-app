namespace Core.Interfaces.Repositories
{
    public interface IAssetRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
