using Core.Domain.Assets;

namespace Core.Interfaces.Repositories.Business
{
    public interface IAssetRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Asset
    {
    }
}
