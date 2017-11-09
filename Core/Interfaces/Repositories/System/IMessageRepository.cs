namespace Core.Interfaces.Repositories.System
{
    public interface IMessageRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}