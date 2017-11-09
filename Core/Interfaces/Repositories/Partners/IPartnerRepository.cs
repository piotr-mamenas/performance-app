namespace Core.Interfaces.Repositories.Partners
{
    public interface IPartnerRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
