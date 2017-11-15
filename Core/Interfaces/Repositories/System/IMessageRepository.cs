using Core.Domain.Messages;

namespace Core.Interfaces.Repositories.System
{
    public interface IMessageRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Message
    {
    }
}