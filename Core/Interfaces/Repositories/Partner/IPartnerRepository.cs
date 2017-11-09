namespace Core.Interfaces.Repositories.Partner
{
    public interface IPartnerRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}
