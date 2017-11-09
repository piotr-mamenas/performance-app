using Core.Interfaces;

namespace Core.Domain
{
    public class BaseEntity : IIdentifiable
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
