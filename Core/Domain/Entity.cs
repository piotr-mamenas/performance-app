namespace Core.Domain
{
    public abstract class Entity<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
