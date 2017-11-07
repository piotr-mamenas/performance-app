using Core.Enums;
using Core.Interfaces;

namespace Core.Domain.Messages
{
    public class Message : BaseEntity<Message>, IEntityRoot
    {
        public string Token { get; set; }

        public Language Language { get; set; }

        public string Content { get; set; }
    }
}
