using Core.Interfaces;

namespace Core.Domain
{
    public abstract class BaseEntity : IIdentifiable
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
