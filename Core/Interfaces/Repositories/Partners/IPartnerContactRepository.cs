namespace Core.Interfaces.Repositories.Partners
{
    public interface IPartnerContactRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
    }
}
