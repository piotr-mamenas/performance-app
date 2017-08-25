namespace Core.Domain.Position
{
    public class BasePosition<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
    }
}
