using Core.Interfaces;

namespace Core.Domain
{
    public class BaseEntity<T> : IIdentifiable where T : BaseEntity<T>, new()
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
