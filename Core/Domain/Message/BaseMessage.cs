using Core.Enums;

namespace Core.Domain.Message
{
    public abstract class BaseMessage<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public string Token { get; set; }
        
        public Language Language { get; set; }

        public string Content { get; set; }
    }
}
