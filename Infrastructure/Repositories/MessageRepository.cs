﻿using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class MessageRepository<TSpecificEntity> : Repository<TSpecificEntity>, IMessageRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
        public MessageRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
