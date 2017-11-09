namespace Core.Interfaces.Repositories.Partner
{
    public interface IPartnerContactRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, new()
    {
    }
}
