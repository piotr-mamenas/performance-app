using Core.Domain.Messages;
using Core.Interfaces.Repositories.System;

namespace Infrastructure.Repositories.System
{
    public class MessageRepository<TSpecificEntity> : Repository<TSpecificEntity>, IMessageRepository<TSpecificEntity> where TSpecificEntity : Message
    {
        public MessageRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
