using Core.Interfaces;

namespace Core.Domain.Tasks
{
    public class Task : BaseEntity<Task>, IEntityRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
