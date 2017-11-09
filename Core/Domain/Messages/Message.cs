using Core.Enums;
using Core.Interfaces;

namespace Core.Domain.Messages
{
    public class Message : BaseEntity, IEntityRoot
    {
        public string Token { get; set; }

        public Language Language { get; set; }

        public string Content { get; set; }
    }
}
