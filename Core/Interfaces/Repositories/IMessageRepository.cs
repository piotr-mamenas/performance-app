namespace Core.Interfaces.Repositories
{
    public interface IMessageRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}