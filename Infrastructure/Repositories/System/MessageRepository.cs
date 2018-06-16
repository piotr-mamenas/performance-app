using Core.Domain.Messages;
using Core.Interfaces.Repositories.System;

namespace Infrastructure.Repositories.System
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
