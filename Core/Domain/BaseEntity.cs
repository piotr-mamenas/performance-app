namespace Core.Domain
{
    public class BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public int Id { get; set; }
    }
}
